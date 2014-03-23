using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using MvvmFx.Windows.Data;

namespace ReceiptScanSandbox
{
    public partial class Form1 : Form
    {
        #region [ Constructors ]

        public Form1()
        {
            InitializeComponent();

            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return;

            ViewModel = new Form1ViewModel();
            BindingManager = new BindingManager();
            ScannerHelper = new ScanHelper(this);
        }

        #endregion

        #region [ Properties ]

        private BindingManager BindingManager { get; set; }
        private ScanHelper ScannerHelper { get; set; }
        private Form1ViewModel ViewModel { get; set; }

        #endregion

        #region [ Methods ]

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            chkShowOptimizedImage.BindData(BindingManager,
                ViewModel, s => s.EnableOptimization);

            imageBox1.BindData(BindingManager,
                ViewModel, s => s.ActiveImage);

            numericUpDown1.BindData(BindingManager,
                ViewModel, s => s.OptimizeSetting);

            chkContrast.BindData(BindingManager,
                ViewModel, s => s.EnableContrast);

            chkStraighten.BindData(BindingManager,
                ViewModel, s => s.EnableStraighten);

            chkCrop.BindData(BindingManager,
                ViewModel, s => s.EnableAutoCrop);
        }

        #endregion

        #region [ Event Handlers ]

        private void ScannerHelper_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "ScannedImage")
                ViewModel.OriginalImage = ScannerHelper.ScannedImage;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ScannerHelper.StartCapture();
            ScannerHelper.PropertyChanged += ScannerHelper_PropertyChanged;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Multiselect = false,
                Filter = "Image Files|*.jp*g"
            };
            DialogResult result = dialog.ShowDialog();

            if (result != DialogResult.OK)
                return;

            ViewModel.OpenImage(dialog.FileName);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ScannerHelper.SetupTwain();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ScannerHelper.ReloadScanners();

            ScannerHelper.SelectedScanner =
                ScannerHelper.Scanners.Last();
        }

        #endregion
    }
}
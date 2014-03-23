using System;
using System.ComponentModel;
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
        }

        #endregion

        #region [ Properties ]

        private BindingManager BindingManager { get; set; }
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

        #endregion
    }
}
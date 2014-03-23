using System.ComponentModel;
using System.Drawing;
using AForge.Imaging.Filters;

namespace ReceiptScanSandbox
{
    public class Form1ViewModel : BaseViewModelEmpty
    {
        #region [ Constructors ]

        public Form1ViewModel()
        {
            OptimizeSetting = 75;
            PropertyChanged += Form1ViewModel_PropertyChanged;
        }

        #endregion

        #region [ Properties ]

        public Image ActiveImage
        {
            get
            {
                if (EnableOptimization)
                    return OptimizedImage;

                return OriginalImage;
            }
        }

        public bool EnableOptimization { get; set; }
        public int OptimizeSetting { get; set; }
        public Image OptimizedImage { get; set; }
        public Image OriginalImage { get; set; }

        #endregion

        #region [ Public Methods ]

        public void OpenImage(string fileName)
        {
            OriginalImage = Image.FromFile(fileName);
        }

        #endregion

        #region [ Methods ]

        private void UpdateOptimizedImage()
        {
            var image = (Bitmap) OriginalImage.Clone();
            var filter = new ContrastCorrection(OptimizeSetting);
            filter.ApplyInPlace(image);

            OptimizedImage = image;
        }

        #endregion

        #region [ Event Handlers ]

        private void Form1ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "OriginalImage":
                case "OptimizeSetting":
                    UpdateOptimizedImage();
                    break;
            }
        }

        #endregion
    }
}
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using AForge.Imaging;
using AForge.Imaging.Filters;
using Image = System.Drawing.Image;

namespace ReceiptScanSandbox
{
    public class Form1ViewModel : BaseViewModelEmpty
    {
        #region [ Constructors ]

        public Form1ViewModel()
        {
            OptimizeSetting = 75;
            EnableContrast = true;
            EnableStraighten = true;
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

        public bool EnableAutoCrop { get; set; }
        public bool EnableContrast { get; set; }
        public bool EnableOptimization { get; set; }
        public bool EnableStraighten { get; set; }
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

        private Image ApplyAutoCrop(Image image)
        {
            var bitmapImage = (Bitmap) image.Clone();
            return new ExtractBiggestBlob().Apply(bitmapImage);
        }

        private Image ApplyContrast(Image image)
        {
            var bitmapImage = (Bitmap) image.Clone();
            var filter = new ContrastCorrection(OptimizeSetting);
            return filter.Apply(bitmapImage);
        }

        private Image ApplyStraightening(Image image)
        {
            var bitmapImage = (Bitmap) image.Clone();
            double angle = new DocumentSkewChecker().GetSkewAngle(EnsureGrayscale(bitmapImage));
            var rotationFilter = new RotateBilinear(-angle) {FillColor = Color.Black};
            return rotationFilter.Apply(bitmapImage);
        }

        private static Bitmap EnsureGrayscale(Bitmap source)
        {
            return source.PixelFormat == PixelFormat.Format8bppIndexed
                ? source
                : Grayscale.CommonAlgorithms.BT709.Apply(source);
        }

        private void UpdateOptimizedImage()
        {
            if (OriginalImage == null)
                return;

            Image image = OriginalImage;

            if (EnableContrast)
                image = ApplyContrast(image);

            if (EnableAutoCrop)
                image = ApplyAutoCrop(image);

            if (EnableStraighten)
                image = ApplyStraightening(image);

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
                case "EnableContrast":
                case "EnableStraighten":
                case "EnableAutoCrop":
                    UpdateOptimizedImage();
                    break;
            }
        }

        #endregion
    }
}
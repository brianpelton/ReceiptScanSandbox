using System;
using System.Globalization;
using MvvmFx.Windows.Data;

namespace ReceiptScanSandbox
{
    public class IntToStringConverter : IValueConverter
    {
        #region [ Static Fields ]

        private static readonly Lazy<IntToStringConverter> LazyInstance =
            new Lazy<IntToStringConverter>(() => new IntToStringConverter());

        #endregion

        #region [ Constructors ]

        private IntToStringConverter()
        {
        }

        #endregion

        #region [ Properties ]

        public static IntToStringConverter Instance
        {
            get { return LazyInstance.Value; }
        }

        #endregion

        #region [ Interface IValueConverter Members ]

        public object Convert(object value, Type type, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;

            return value.ToString();
        }

        public object ConvertBack(object value, Type type, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;

            if (value is string)
            {
                int parsedValue;
                if (!int.TryParse((string) value, out parsedValue))
                    return null;

                return parsedValue;
            }

            return System.Convert.ToDecimal(value);
        }

        #endregion
    }
}
using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using log4net;

namespace ReceiptScanSandbox
{
    public abstract class NotifyPropertyBase : INotifyPropertyChanged
    {
        #region [ Logging ]

        private static readonly ILog Log =
            LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region [ Interface INotifyPropertyChanged Members ]

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region [ Public Methods ]

        public void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            Log.DebugFormat("RaisePropertyChanged '{0}' on [{1}]", propertyName, GetType().Name);

            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void RaisePropertyChangedFor(string name)
        {
            // ReSharper disable ExplicitCallerInfoArgument
            RaisePropertyChanged(name);
            // ReSharper restore ExplicitCallerInfoArgument
        }

        public void RaisePropertyChangedForExp<T>(Expression<Func<T>> propertyExpression)
        {
            var body = propertyExpression.Body as MemberExpression;

            // ReSharper disable ExplicitCallerInfoArgument
            RaisePropertyChanged(body.Member.Name);
            // ReSharper restore ExplicitCallerInfoArgument
        }

        #endregion
    }
}
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace ReceiptScanSandbox
{
    public abstract class BaseViewModelEmpty : BusyNotifyPropertyBase
    {
        #region [ Properties ]

        public virtual bool CanCorrectAny
        {
            get { return false; }
        }

        public virtual bool CanEditAny
        {
            get { return false; }
        }

        public bool No
        {
            get { return false; }
        }

        public bool Yes
        {
            get { return true; }
        }

        #endregion

        #region [ Public Methods ]

        public BindingList<T> CreateBindingList<T>(IEnumerable<T> collection)
        {
            return new BindingList<T>(collection.ToList())
            {
                AllowEdit = false,
                AllowNew = false,
                AllowRemove = false
            };
        }

        #endregion
    }
}
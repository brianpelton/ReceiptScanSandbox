using System;
using System.Linq.Expressions;
using System.Windows.Forms;
using Cyotek.Windows.Forms;
using MvvmFx.Windows.Data;

namespace ReceiptScanSandbox
{
    public static class ControlBindingHelper
    {
        #region [ Public Methods ]

        public static void BindData<TSource>(
            this CheckBox targetObject,
            BindingManager bindingManager,
            TSource sourceObject,
            Expression<Func<TSource, object>> sourceExpression,
            IValueConverter converter = null,
            BindingMode mode = BindingMode.TwoWay)
        {
            bindingManager.Bind(
                targetObject, t => t.Checked,
                sourceObject, sourceExpression, converter, mode);
        }

        public static void BindData<TSource>(
            this ImageBox targetObject,
            BindingManager bindingManager,
            TSource sourceObject,
            Expression<Func<TSource, object>> sourceExpression,
            IValueConverter converter = null,
            BindingMode mode = BindingMode.TwoWay)
        {
            bindingManager.Bind(
                targetObject, t => t.Image,
                sourceObject, sourceExpression, converter, mode);
        }

        public static void BindData<TSource>(
            this NumericUpDown targetObject,
            BindingManager bindingManager,
            TSource sourceObject,
            Expression<Func<TSource, object>> sourceExpression,
            IValueConverter converter = null,
            BindingMode mode = BindingMode.TwoWay)
        {
            bindingManager.Bind(
                targetObject, t => t.Value,
                sourceObject, sourceExpression, converter, mode);
        }

        #endregion
    }
}
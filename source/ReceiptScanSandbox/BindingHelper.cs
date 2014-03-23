using System;
using System.Linq.Expressions;
using System.Windows.Forms;
using MvvmFx.Windows.Data;

namespace ReceiptScanSandbox
{
    public static class BindingHelper
    {
        #region [ Public Methods ]

        public static void Bind<TSource, TTarget>(
            this BindingManager bindingManager,
            TTarget targetObject,
            Expression<Func<TTarget, object>> targetExpression,
            TSource sourceObject,
            Expression<Func<TSource, object>> sourceExpression)
        {
            bindingManager.Bind(
                targetObject, targetExpression,
                sourceObject, sourceExpression,
                null);
        }


        public static void Bind<TSource, TTarget>(
            this BindingManager bindingManager,
            TTarget targetObject,
            Expression<Func<TTarget, object>> targetExpression,
            TSource sourceObject,
            Expression<Func<TSource, object>> sourceExpression,
            IValueConverter converter,
            BindingMode mode)
        {
            var binding = new TypedBinding<TTarget, TSource>(
                targetObject, targetExpression,
                sourceObject, sourceExpression)
            {
                Converter = converter,
                Mode = mode
            };

            bindingManager.Bindings.Add(binding);
        }

        public static void Bind<TSource, TTarget>(
            this BindingManager bindingManager,
            TTarget targetObject,
            Expression<Func<TTarget, object>> targetExpression,
            TSource sourceObject,
            Expression<Func<TSource, object>> sourceExpression,
            IValueConverter converter)
        {
            bindingManager.Bind(
                targetObject, targetExpression,
                sourceObject, sourceExpression,
                converter, BindingMode.TwoWay);
        }


        public static void BindEnabled<TSource>(
            this Control targetObject,
            BindingManager bindingManager,
            TSource sourceObject,
            Expression<Func<TSource, object>> sourceExpression,
            IValueConverter converter = null,
            BindingMode mode = BindingMode.OneWayToTarget)
        {
            bindingManager.Bind(
                targetObject, t => t.Enabled,
                sourceObject, sourceExpression, converter, mode);
        }


        public static void BindVisible<TSource>(
            this Control targetObject,
            BindingManager bindingManager,
            TSource sourceObject,
            Expression<Func<TSource, object>> sourceExpression,
            IValueConverter converter = null,
            BindingMode mode = BindingMode.OneWayToTarget)
        {
            bindingManager.Bind(
                targetObject, t => t.Visible,
                sourceObject, sourceExpression, converter, mode);
        }

        #endregion
    }
}
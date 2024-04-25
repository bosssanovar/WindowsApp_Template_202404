using Microsoft.Xaml.Behaviors;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace WpfLib.Behavior
{
    /// <summary>
    /// TextBoxにフォーカス時に文字列全選択するビヘイビア
    /// </summary>
    public class SelectAllFocusBehavior : Behavior<TextBox>
    {
        /// <summary>
        /// 機能有効/無効プロパティ
        /// </summary>
        public static readonly DependencyProperty EnableProperty =
                 DependencyProperty.RegisterAttached(
                     "Enable",
                     typeof(bool),
                     typeof(SelectAllFocusBehavior),
                     new FrameworkPropertyMetadata(false, OnEnableChanged));

        /// <summary>
        /// 機能有効/無効を取得します。
        /// </summary>
        /// <param name="dependencyObject">対象</param>
        /// <returns>機能有効/無効</returns>
        [AttachedPropertyBrowsableForType(typeof(TextBox))]
        public static bool GetEnable(DependencyObject dependencyObject)
        {
            return (bool)dependencyObject.GetValue(EnableProperty);
        }

        /// <summary>
        /// 機能有効/無効を設定します。
        /// </summary>
        /// <param name="dependencyObject">対象</param>
        /// <param name="value">機能有効/無効</param>
        [AttachedPropertyBrowsableForType(typeof(TextBox))]
        public static void SetEnable(DependencyObject dependencyObject, bool value)
        {
            dependencyObject.SetValue(EnableProperty, value);
        }

        private static void OnEnableChanged(
                   DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var frameworkElement = d as FrameworkElement;
            if (frameworkElement == null)
            {
                return;
            }

            if (e.NewValue is bool == false)
            {
                return;
            }

            if ((bool)e.NewValue)
            {
                frameworkElement.GotFocus += SelectAll;
                frameworkElement.PreviewMouseDown += IgnoreMouseButton;
            }
            else
            {
                frameworkElement.GotFocus -= SelectAll;
                frameworkElement.PreviewMouseDown -= IgnoreMouseButton;
            }
        }

        private static void SelectAll(object sender, RoutedEventArgs e)
        {
            var frameworkElement = e.OriginalSource as FrameworkElement;
            if (frameworkElement is TextBox)
            {
                ((TextBoxBase)frameworkElement).SelectAll();
            }
            else if (frameworkElement is PasswordBox box)
            {
                box.SelectAll();
            }
        }

        private static void IgnoreMouseButton(
                object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var frameworkElement = sender as FrameworkElement;
            if (frameworkElement == null || frameworkElement.IsKeyboardFocusWithin)
            {
                return;
            }

            e.Handled = true;
            frameworkElement.Focus();
        }
    }
}

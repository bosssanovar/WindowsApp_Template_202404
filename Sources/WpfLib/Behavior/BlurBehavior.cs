using Microsoft.Xaml.Behaviors;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace WpfLib.Behavior
{
    /// <summary>
    /// Blurをかけるビヘイビア
    /// </summary>
    public class BlurBehavior : Behavior<UIElement>
    {
        /// <summary>
        /// 機能有効/無効プロパティ
        /// </summary>
        public static readonly DependencyProperty EnableProperty =
                 DependencyProperty.RegisterAttached(
                     "Enable",
                     typeof(bool),
                     typeof(BlurBehavior),
                     new FrameworkPropertyMetadata(false, OnEnableChanged));

        /// <summary>
        /// 機能有効/無効を取得します。
        /// </summary>
        /// <param name="dependencyObject">対象</param>
        /// <returns>機能有効/無効</returns>
        [AttachedPropertyBrowsableForType(typeof(DataGrid))]
        public static bool GetEnable(DependencyObject dependencyObject)
        {
            return (bool)dependencyObject.GetValue(EnableProperty);
        }

        /// <summary>
        /// 機能有効/無効を設定します。
        /// </summary>
        /// <param name="dependencyObject">対象</param>
        /// <param name="value">機能有効/無効</param>
        [AttachedPropertyBrowsableForType(typeof(DataGrid))]
        public static void SetEnable(DependencyObject dependencyObject, bool value)
        {
            dependencyObject.SetValue(EnableProperty, value);
        }

        private static void OnEnableChanged(
                   DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var uiElement = d as UIElement;
            if (uiElement == null)
            {
                return;
            }

            if ((bool)e.NewValue)
            {
                var effect = new BlurEffect()
                {
                    Radius = 8.0,
                    KernelType = KernelType.Gaussian,
                };
                uiElement.Effect = effect;
            }
            else
            {
                uiElement.Effect = null;
            }
        }
    }
}

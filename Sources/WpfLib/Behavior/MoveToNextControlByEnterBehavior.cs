using Microsoft.Xaml.Behaviors;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfLib.Behavior
{
    /// <summary>
    /// Enter押下で次のコントロールにフォーカスを異動するビヘイビア
    /// </summary>
    public class MoveToNextControlByEnterBehavior : Behavior<Control>
    {
        /// <summary>
        /// 機能有効/無効のプロパティ
        /// </summary>
        public static readonly DependencyProperty EnableProperty = DependencyProperty.RegisterAttached(
            "Enable",
            typeof(bool),
            typeof(MoveToNextControlByEnterBehavior),
            new UIPropertyMetadata(false, EnableChanged));

        /// <summary>
        /// 機能有効/無効を取得します。
        /// </summary>
        /// <param name="obj">対象</param>
        /// <returns>機能有効/無効</returns>
        [AttachedPropertyBrowsableForType(typeof(Control))]
        public static bool GetEnable(DependencyObject obj)
        {
            return (bool)obj.GetValue(EnableProperty);
        }

        /// <summary>
        /// 機能有効/無効を設定します。
        /// </summary>
        /// <param name="obj">対象</param>
        /// <param name="value">機能有効/無効</param>
        [AttachedPropertyBrowsableForType(typeof(Control))]
        public static void SetEnable(DependencyObject obj, bool value)
        {
            obj.SetValue(EnableProperty, value);
        }

        /// <summary>
        /// 機能有効/無効の変更時のイベントハンドラ
        /// </summary>
        /// <param name="sender">発行者</param>
        /// <param name="e">イベントデータ</param>
        public static void EnableChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            if (sender is not UIElement element)
            {
                return;
            }

            if (GetEnable(element))
            {
                element.KeyDown += TextBox_KeyDown;
            }
            else
            {
                element.KeyDown -= TextBox_KeyDown;
            }
        }

        private static void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            // Enter キーが押されたら、次のコントロールにフォーカスを移動する
            if ((Keyboard.Modifiers == ModifierKeys.None) && (e.Key == Key.Enter))
            {
                if (sender is not UIElement element)
                {
                    return;
                }

                element.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
            }
        }
    }
}

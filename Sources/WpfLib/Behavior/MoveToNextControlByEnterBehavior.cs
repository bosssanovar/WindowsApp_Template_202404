using Microsoft.Xaml.Behaviors;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfLib.Behavior
{
    public class MoveToNextControlByEnterBehavior : Behavior<Control>
    {
        // 添付プロパティの初期値は false。
        // コールバックを指定しておく。
        public static readonly DependencyProperty EnableProperty = DependencyProperty.RegisterAttached("Enable",
            typeof(bool),
            typeof(MoveToNextControlByEnterBehavior),
            new UIPropertyMetadata(false, EnableChanged));

        [AttachedPropertyBrowsableForType(typeof(Control))]
        public static bool GetEnable(DependencyObject obj)
        {
            return (bool)obj.GetValue(EnableProperty);
        }

        [AttachedPropertyBrowsableForType(typeof(Control))]
        public static void SetEnable(DependencyObject obj, bool value)
        {
            obj.SetValue(EnableProperty, value);
        }

        // Enable の値が変更されたときに呼び出される。
        // KeyDown イベントハンドラの登録＆解除を行う。
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

        // Enter キーが押されたら、次のコントロールにフォーカスを移動する
        private static void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
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

using Microsoft.Xaml.Behaviors;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;

namespace WpfLib.Behavior
{
    /// <summary>
    /// DataGridを水平スクロールするビヘイビア。
    /// タッチパッドの水平スワイプ、Shiftキー押下でのマウスホイールで動作。
    /// </summary>
    public class HorizontalScrollBehavior : Behavior<DataGrid>
    {
        /// <summary>
        /// 機能有効/無効プロパティ
        /// </summary>
        public static readonly DependencyProperty EnableProperty =
                 DependencyProperty.RegisterAttached(
                     "Enable",
                     typeof(bool),
                     typeof(HorizontalScrollBehavior),
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
            var dataGrid = d as DataGrid;
            if (dataGrid == null)
            {
                return;
            }

            if ((bool)e.NewValue)
            {
                dataGrid.Loaded -= DataGrid_Loaded;
                dataGrid.Loaded += DataGrid_Loaded;
                dataGrid.Unloaded -= DataGrid_Unloaded;
                dataGrid.Unloaded += DataGrid_Unloaded;

                dataGrid.PreviewMouseWheel += DataGrid_MouseWheel;
            }
            else
            {
                dataGrid.Loaded -= DataGrid_Loaded;
                dataGrid.Unloaded -= DataGrid_Unloaded;

                ChangeHook(dataGrid, false);

                dataGrid.PreviewMouseWheel -= DataGrid_MouseWheel;
            }
        }

        private static void DataGrid_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (IsShiftKeyPressed)
            {
                DataGrid grid = (DataGrid)sender;

                if (grid.Items.Count > 0)
                {
                    //==== ScrollViewerオブジェクト取得 ====//
                    var child = VisualTreeHelper.GetChild(grid, 0) as Decorator;
                    if (child != null)
                    {
                        var scroll = child.Child as ScrollViewer;
                        if (scroll != null)
                        {
                            if (e.Delta > 0)
                            {
                                scroll.LineLeft();
                            }
                            else
                            {
                                scroll.LineRight();
                            }

                            e.Handled = true;
                        }
                    }
                }
            }
        }

        private static bool IsShiftKeyPressed
        {
            get
            {
                return (Keyboard.GetKeyStates(Key.LeftShift) & KeyStates.Down) == KeyStates.Down ||
                     (Keyboard.GetKeyStates(Key.RightShift) & KeyStates.Down) == KeyStates.Down;
            }
        }

        private static void DataGrid_Unloaded(object sender, RoutedEventArgs e)
        {
            var dataGrid = sender as DataGrid;
            if (dataGrid == null)
            {
                return;
            }

            ChangeHook(dataGrid, false);
        }

        private static void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            var dataGrid = sender as DataGrid;
            if (dataGrid == null)
            {
                return;
            }

            ChangeHook(dataGrid, true);
        }

        private static void ChangeHook(DataGrid dataGrid, bool newValue)
        {
            if (newValue)
            {
                var source = PresentationSource.FromVisual(dataGrid);
                ((HwndSource)source)?.AddHook(Hook);
            }
            else
            {
                var source = PresentationSource.FromVisual(dataGrid);
                ((HwndSource)source)?.RemoveHook(Hook);
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.NamingRules", "SA1310:Field names should not contain underscore", Justification = "<保留中>")]
        private const int WM_MOUSEHWHEEL = 0x020E;

        private static IntPtr Hook(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            switch (msg)
            {
                case WM_MOUSEHWHEEL:
                    int tilt = (short)HIWORD(wParam);
                    OnMouseTilt(tilt);
                    return (IntPtr)1;
            }

            return IntPtr.Zero;
        }

        /// <summary>
        /// Gets high bits values of the pointer.
        /// </summary>
        private static int HIWORD(IntPtr ptr)
        {
            unchecked
            {
                if (Environment.Is64BitOperatingSystem)
                {
                    var val64 = ptr.ToInt64();
                    return (short)((val64 >> 16) & 0xFFFF);
                }

                var val32 = ptr.ToInt32();
                return (short)((val32 >> 16) & 0xFFFF);
            }
        }

        private static void OnMouseTilt(int tilt)
        {
            if (Mouse.DirectlyOver is not UIElement element)
            {
                return;
            }

            ScrollViewer? scrollViewer = element is ScrollViewer viewer ? viewer : FindParent<ScrollViewer>(element);

            if (scrollViewer == null)
            {
                return;
            }

            scrollViewer.ScrollToHorizontalOffset(scrollViewer.HorizontalOffset + tilt);
        }

        private static T? FindParent<T>(DependencyObject child)
            where T : DependencyObject
        {
            if (child == null)
            {
                return null;
            }

            DependencyObject parentObject = VisualTreeHelper.GetParent(child);

            if (parentObject is T parent)
            {
                return parent;
            }
            else
            {
                return FindParent<T>(parentObject);
            }
        }
    }
}

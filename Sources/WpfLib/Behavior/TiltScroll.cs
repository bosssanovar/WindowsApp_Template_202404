using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;

namespace WpfLib.Behavior
{
    /// <summary>
    /// 水平スクロール用クラス
    /// </summary>
    public class TiltScroll
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="dataGrid">対象</param>
        public TiltScroll(DataGrid dataGrid)
        {
            var source = PresentationSource.FromVisual(dataGrid);
            ((HwndSource)source)?.AddHook(Hook);
        }

        /// <summary>
        /// 機能を破棄します。
        /// </summary>
        /// <param name="dataGrid">対象</param>
        public void Release(DataGrid dataGrid)
        {
            var source = PresentationSource.FromVisual(dataGrid);
            ((HwndSource)source)?.RemoveHook(Hook);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.NamingRules", "SA1310:Field names should not contain underscore", Justification = "<保留中>")]
        private const int WM_MOUSEHWHEEL = 0x020E;

        private IntPtr Hook(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
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

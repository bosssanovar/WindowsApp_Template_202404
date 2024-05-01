using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace UiParts.UserControls.CccPage
{
    /// <summary>
    /// プレビュー用単位図形
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:File may only contain a single type", Justification = "<保留中>")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:File name should match first type name", Justification = "<保留中>")]
    public class Square : Control
    {
    }

    /// <summary>
    /// プレビュー用図形
    /// </summary>
    public class Squares : Control
    {
        /// <summary>
        /// 描画領域
        /// </summary>
        public ScrollViewer? ScrollViewer { get; set; }

        /// <summary>
        /// 描画図形リスト
        /// </summary>
        public List<Control> Objects { get; } = [];

        /// <inheritdoc/>
        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            if (ScrollViewer == null || Objects == null)
            {
                return;
            }

            // ScrollViewerで表示されている領域
            var viewRect = new Rect(ScrollViewer.HorizontalOffset, ScrollViewer.VerticalOffset, ScrollViewer.ViewportWidth, ScrollViewer.ViewportHeight);

            foreach (var s in Objects)
            {
                var rect = new Rect(Canvas.GetLeft(s), Canvas.GetTop(s), s.Width, s.Height);
                // 四角形が表示領域内に含まれる場合のみ描画する
                if (viewRect.IntersectsWith(rect))
                {
                    drawingContext.DrawRectangle(Brushes.DarkBlue, new Pen(Brushes.DarkBlue, 1), rect);
                }
            }
        }
    }
}

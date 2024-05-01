using Reactive.Bindings;

using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

using WpfLib;

namespace UiParts.UserControls.CccPage
{
    /// <summary>
    /// CccPageView.xaml の相互作用ロジック
    /// </summary>
    public partial class CccPageView : PageViewBase
    {
        private const int InitCulumnCount = 100;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("CodeQuality", "IDE0052:読み取られていないプライベート メンバーを削除", Justification = "<保留中>")]
        private ScrollSynchronizer? _scrollSynchronizer;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="model">モデル</param>
        public CccPageView(CccPageModel model)
            : base(model)
        {
            CccPageViewModel(model);

            InitializeComponent();

            InitData();

            this.Loaded += CccPageView_Loaded;
        }

        #region 画面の初期化

        private void CccPageView_Loaded(object sender, RoutedEventArgs e)
        {
            Cursor = Cursors.Wait;

            Dispatcher.InvokeAsync(
                () =>
                {
                    InitColumns(InitCulumnCount);

                    squares.ScrollViewer = previewScroll;

                    grid.Visibility = Visibility.Visible;

                    Dispatcher.InvokeAsync(
                        () =>
                        {
                            Cursor = null;

                            InitScrollSynchronizer();
                        },
                        System.Windows.Threading.DispatcherPriority.Background);
                },
                System.Windows.Threading.DispatcherPriority.Background);
        }

        private void InitScrollSynchronizer()
        {
            var scrollList = new List<ScrollViewer>
            {
                previewScroll,
            };
            var gridScroll = DataGridHelper.GetScrollViewer(grid);
            if (gridScroll is not null)
            {
                scrollList.Add(gridScroll);
            }

            _scrollSynchronizer = new ScrollSynchronizer(scrollList);
        }
        #endregion

        #region 行列の初期化

        private void InitColumns(int count)
        {
            grid.Columns.Clear();

            var converter = new BooleanToVisibilityConverter();
            for (int columnIndex = 0; columnIndex < count; ++columnIndex)
            {
                var binding = new Binding($"CCCs[{columnIndex}].Value")
                {
                    Converter = converter,
                };

                var factory = new FrameworkElementFactory(typeof(Rectangle));
                factory.SetValue(Rectangle.HeightProperty, 10.0);
                factory.SetValue(Rectangle.WidthProperty, 10.0);
                factory.SetValue(Rectangle.FillProperty, Brushes.LightSkyBlue);
                factory.SetBinding(Rectangle.VisibilityProperty, binding);

                var dataTemplate = new DataTemplate
                {
                    VisualTree = factory,
                };

                var column = new DataGridTemplateColumn
                {
                    CellTemplate = dataTemplate,
                };

                grid.Columns.Add(column);
            }
        }

        private void InitData()
        {
            // バインドを一時切断
            Binding b = new("CCCs")
            {
                Source = null,
            };
            grid.SetBinding(DataGrid.ItemsSourceProperty, b);

            // TODO : 要実装
            // モデルの再構築

            // バインドを再構築
            b = new Binding("CCCs")
            {
                Source = this,
            };
            grid.SetBinding(DataGrid.ItemsSourceProperty, b);
        }
        #endregion

        #region 設定値変更

        private void DataGridCell_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (grid.SelectedCells.Count == 1)
            {
                var columnIndex = DataGridHelper.GetSelectedColumnIndex(grid);
                var rowIndex = DataGridHelper.GetSelectedRowIndex(grid);

                CCCs[rowIndex].Invert(columnIndex);

                UpdatePreview();
            }
        }

        private void DataGridCell_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (grid.SelectedCells.Count <= 1)
            {
                grid.Focus();
                grid.SelectedCells.Clear();

                DataGridCell? targetCell = DataGridHelper.GetCellAtMousePosition(sender, e);

                if (targetCell is null)
                {
                    return;
                }

                grid.CurrentCell = new DataGridCellInfo(targetCell);
                grid.SelectedCells.Add(grid.CurrentCell);

                ShowContextMenu(false);
            }
            else
            {
                ShowContextMenu(true);
            }
        }

        private void ShowContextMenu(bool isSelectArea)
        {
            ContextMenu contextMenu = new();

            MenuItem menuItem = new()
            {
                Header = "行全部設定",
            };
            menuItem.Click += new RoutedEventHandler(AllOn);
            menuItem.IsEnabled = !isSelectArea;
            contextMenu.Items.Add(menuItem);

            Separator separator = new();
            contextMenu.Items.Add(separator);

            menuItem = new MenuItem
            {
                Header = "選択エリア設定",
            };
            menuItem.Click += new RoutedEventHandler(AreaOn);
            menuItem.IsEnabled = isSelectArea;
            contextMenu.Items.Add(menuItem);

            contextMenu.IsOpen = true;
        }

        private void AllOn(object sender, RoutedEventArgs e)
        {
            var rowIndex = DataGridHelper.GetSelectedRowIndex(grid);
            CCCs[rowIndex].SetAll(true);

            UpdatePreview();
        }

        private void AreaOn(object sender, RoutedEventArgs e)
        {
            var indexes = DataGridHelper.GetSelectedCellsIndex(grid);
            foreach (var index in indexes)
            {
                CCCs[index.RowIndex].SetOn(index.ColumnIndex);
            }

            UpdatePreview();
        }

        #endregion

        #region ミニマップ

        #region 表示位置

        private void Thumb_DragStarted(object sender, DragStartedEventArgs e)
        {
            var thumb = sender as Thumb;
            if (thumb != null)
            {
                var border = thumb.Template.FindName("Thumb_Border", thumb) as Border;
                if (border != null)
                {
                    border.BorderThickness = new Thickness(1);

                    e.Handled = true;
                }
            }
        }

        private void Thumb_DragCompleted(object sender, DragCompletedEventArgs e)
        {
            var thumb = sender as Thumb;
            if (thumb != null)
            {
                var border = thumb.Template.FindName("Thumb_Border", thumb) as Border;
                if (border != null)
                {
                    border.BorderThickness = new Thickness(0);

                    e.Handled = true;
                }
            }
        }

        private void Thumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            var thumb = sender as Thumb;
            if (thumb != null)
            {
                var x = Canvas.GetRight(thumb) - e.HorizontalChange;
                var y = Canvas.GetBottom(thumb) - e.VerticalChange;

                var canvas = thumb.Parent as Canvas;
                if (canvas != null)
                {
                    x = Math.Max(x, 0);
                    y = Math.Max(y, 0);
                    x = Math.Min(x, canvas.ActualWidth - thumb.ActualWidth);
                    y = Math.Min(y, canvas.ActualHeight - thumb.ActualHeight);
                }

                Canvas.SetRight(thumb, x);
                Canvas.SetBottom(thumb, y);

                e.Handled = true;
            }
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            // TODO : スクロールバーのサイズ感を行列サイズ、画面サイズに応じて変更
            squares.InvalidateVisual();
            MoveScroll();
        }

        #endregion

        #region スクロール

        private void Thumb_DragStarted2(object sender, DragStartedEventArgs e)
        {
            var thumb = sender as Thumb;
            if (thumb != null)
            {
                var border = thumb.Template.FindName("Area_Thumb_Border", thumb) as Border;
                if (border != null)
                {
                    border.BorderThickness = new Thickness(1);
                }

                gridPanel.Children.Remove(grid);

                previewScroll.Visibility = Visibility.Visible;

                squares.InvalidateVisual();

                e.Handled = true;
            }
        }

        private void Thumb_DragCompleted2(object sender, DragCompletedEventArgs e)
        {
            Cursor = Cursors.Wait;

            var thumb = sender as Thumb;
            if (thumb != null)
            {
                var border = thumb.Template.FindName("Area_Thumb_Border", thumb) as Border;
                if (border != null)
                {
                    border.BorderThickness = new Thickness(0);
                }

                gridPanel.Children.Insert(1, grid);

                Dispatcher.InvokeAsync(
                    () =>
                    {
                        if (gridPanel.Children.Contains(grid)) // ドラッグ開始終了の連続動作時にプレビュー表示されなくなる問題回避のため
                        {
                            previewScroll.Visibility = Visibility.Collapsed;
                        }

                        Cursor = null;
                    },
                    System.Windows.Threading.DispatcherPriority.Background);

                e.Handled = true;
            }
        }

        private void Thumb_DragDelta2(object sender, DragDeltaEventArgs e)
        {
            VerticalScrollDelta(sender, e);
            HorizontalScrollDelta(sender, e);

            e.Handled = true;
        }

        #endregion

        #endregion

        #region ダミー表示

        private void UpdatePreview()
        {
            squares.Objects.Clear();

            var rowMax = CCCs.Count;
            var colmunMax = CCCs[0].CCCs.Count;

            for (int rowIndex = 0; rowIndex < rowMax; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < colmunMax; columnIndex++)
                {
                    if (CCCs[rowIndex].CCCs[columnIndex].Value)
                    {
                        Square square = CreateSquare(rowIndex, columnIndex);

                        squares.Objects.Add(square);
                    }
                }
            }
        }

        private static Square CreateSquare(int rowIndex, int columnIndex)
        {
            var square = new Square
            {
                Width = 16,
                Height = 16,
            };
            Canvas.SetTop(square, (28 * rowIndex) + 6);
            Canvas.SetLeft(square, (28 * columnIndex) + 6);
            return square;
        }

        private void PreviewScroll_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            squares.InvalidateVisual();

            MoveScroll();
        }

        private void MoveScroll()
        {
            var ratios = GetScrollRatio(previewScroll);
            MoveHorizontalScrollThumb(ratios);
            MoveVerticalScrollThumb(ratios);
        }

        private static (double HorizontalRatio, double VerticalRatio) GetScrollRatio(ScrollViewer scroll)
        {
            var gridWidth = scroll.ScrollableWidth;
            var gridHeight = scroll.ScrollableHeight;

            return (scroll.HorizontalOffset / gridWidth, scroll.VerticalOffset / gridHeight);
        }

        #endregion

        #region スクロールバー　垂直

        private void MoveVerticalScrollThumb((double HorizontalRatio, double VerticalRatio) ratios)
        {
            var y = verticalScrollCanvas.ActualHeight * ratios.VerticalRatio;
            Canvas.SetTop(verticalScrollThumb, y);
        }

        private void VerticalScrollThumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            VerticalScrollDelta(sender, e);

            e.Handled = true;
        }

        private void VerticalScrollDelta(object sender, DragDeltaEventArgs e)
        {
            var thumb = sender as Thumb;
            if (thumb != null)
            {
                var y = Canvas.GetTop(thumb) + e.VerticalChange;

                var canvas = thumb.Parent as Canvas;
                if (canvas != null)
                {
                    y = Math.Max(y, 0);
                    y = Math.Min(y, canvas.ActualHeight - thumb.ActualHeight);

                    Canvas.SetTop(thumb, y);

                    DataGridHelper.MoveVerticalScrollTo(grid, Canvas.GetTop(thumb) / canvas.ActualHeight);

                    previewScroll.ScrollToVerticalOffset(previewScroll.ScrollableHeight * (Canvas.GetTop(thumb) / canvas.ActualHeight));
                }
            }
        }

        #endregion

        #region スクロールバー　水平

        private void MoveHorizontalScrollThumb((double HorizontalRatio, double VerticalRatio) ratios)
        {
            var x = horizontalScrollCanvas.ActualWidth * ratios.HorizontalRatio;
            Canvas.SetLeft(horizontalScrollThumb, x);
        }

        private void HorizontalScrollThumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            HorizontalScrollDelta(sender, e);

            e.Handled = true;
        }

        private void HorizontalScrollDelta(object sender, DragDeltaEventArgs e)
        {
            var thumb = sender as Thumb;
            if (thumb != null)
            {
                var x = Canvas.GetLeft(thumb) + e.HorizontalChange;

                var canvas = thumb.Parent as Canvas;
                if (canvas != null)
                {
                    x = Math.Max(x, 0);
                    x = Math.Min(x, canvas.ActualWidth - thumb.ActualWidth);

                    Canvas.SetLeft(thumb, x);

                    DataGridHelper.MoveHorizontalScrollTo(grid, Canvas.GetLeft(thumb) / canvas.ActualWidth);

                    previewScroll.ScrollToHorizontalOffset(previewScroll.ScrollableWidth * (Canvas.GetLeft(thumb) / canvas.ActualWidth));
                }
            }
        }

        #endregion
    }
}

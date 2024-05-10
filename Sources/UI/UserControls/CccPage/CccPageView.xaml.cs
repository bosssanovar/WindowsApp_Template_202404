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
        private ScrollSynchronizer? _horizontalScrollSynchronizer;
        private ScrollSynchronizer? _verticalScrollSynchronizer;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="model">モデル</param>
        public CccPageView(CccPageModel model)
            : base(model)
        {
            CccPageViewModel(model);

            this.Loaded += CccPageView_Loaded;

            InitializeComponent();
        }

        #region 画面の初期化

        private void CccPageView_Loaded(object sender, RoutedEventArgs e)
        {
            Cursor = Cursors.Wait;

            Dispatcher.InvokeAsync(
                () =>
                {
                    InitColumns(Count.Value);

                    squares.ScrollViewer = previewScroll;

                    initializingText.Visibility = Visibility.Collapsed;

                    grid.Visibility = Visibility.Visible;

                    Dispatcher.InvokeAsync(
                        () =>
                        {
                            Update();

                            InitScrollSynchronizer();

                            Cursor = null;
                        },
                        System.Windows.Threading.DispatcherPriority.Background);
                },
                System.Windows.Threading.DispatcherPriority.Background);
        }

        private void ResizeGridDummy()
        {
            var scrollViewer = DataGridHelper.GetScrollViewer(grid);
            if (scrollViewer != null)
            {
                gridDummy.Width = scrollViewer.ExtentWidth;
                gridDummy.Height = scrollViewer.ExtentHeight;

                previewCanvas.Width = scrollViewer.ExtentWidth;
                previewCanvas.Height = scrollViewer.ExtentHeight;
            }
        }

        private void InitScrollSynchronizer()
        {
            var horizontalScrollList = new List<ScrollViewer>
            {
                previewScroll,
                scroll,
            };
            var verticalScrollList = new List<ScrollViewer>
            {
                previewScroll,
                scroll,
            };

            var gridScroll = DataGridHelper.GetScrollViewer(grid);
            if (gridScroll is not null)
            {
                horizontalScrollList.Add(gridScroll);
                verticalScrollList.Add(gridScroll);
            }

            var rowHeader = DataGridHelper.GetScrollViewer(rowHeaderGrid);
            if (rowHeader is not null)
            {
                verticalScrollList.Add(rowHeader);
            }

            var columnHeader = DataGridHelper.GetScrollViewer(columnHeaderGrid);
            if (columnHeader is not null)
            {
                horizontalScrollList.Add(columnHeader);
            }

            _horizontalScrollSynchronizer = new ScrollSynchronizer(horizontalScrollList, ScrollSynchronizer.SynchronizeDirection.Horizontal);
            _verticalScrollSynchronizer = new ScrollSynchronizer(verticalScrollList, ScrollSynchronizer.SynchronizeDirection.Vertical);
        }
        #endregion

        #region 行列の初期化

        private void InitColumns(int count)
        {
            InitSettingAreaColumns(count);

            InitColumnHeaderColumns(count);
        }

        private void InitSettingAreaColumns(int count)
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

        private void InitColumnHeaderColumns(int count)
        {
            columnHeaderGrid.Columns.Clear();

            for (int columnIndex = 0; columnIndex < count; ++columnIndex)
            {
                var factory = new FrameworkElementFactory(typeof(TextBlock));
                factory.SetValue(TextBlock.VerticalAlignmentProperty, VerticalAlignment.Center);
                factory.SetValue(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Center);
                factory.SetValue(TextBlock.PaddingProperty, new Thickness(5, 0, 5, 0));
                factory.SetValue(TextBlock.LayoutTransformProperty, new RotateTransform(-90));
                factory.SetBinding(TextBlock.TextProperty, new Binding($"Values[{columnIndex}]"));
                factory.SetBinding(TextBlock.WidthProperty, new Binding($"Width"));

                var dataTemplate = new DataTemplate
                {
                    VisualTree = factory,
                };

                var column = new DataGridTemplateColumn
                {
                    CellTemplate = dataTemplate,
                };

                columnHeaderGrid.Columns.Add(column);
            }
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
        }

        #endregion

        #region スクロール

        private void Thumb_DragStarted(object sender, DragStartedEventArgs e)
        {
            gridPanel.Children.Remove(grid);

            previewScroll.Visibility = Visibility.Visible;

            squares.InvalidateVisual();

            e.Handled = true;
        }

        private void Thumb_DragCompleted(object sender, DragCompletedEventArgs e)
        {
            Cursor = Cursors.Wait;

            gridPanel.Children.Insert(3, grid);     // gridPanelの子要素の内、4番目（index = 3）にgridはある

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

        #endregion
    }
}

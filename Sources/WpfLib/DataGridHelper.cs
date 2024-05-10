using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace WpfLib
{
    /// <summary>
    /// DataGridクラスの補助機能クラス
    /// </summary>
    public static class DataGridHelper
    {
        /// <summary>
        /// 選択セルの列インデックスを取得します。
        /// </summary>
        /// <param name="grid">対象グリッド</param>
        /// <returns>列インデックス</returns>
        public static int GetSelectedColumnIndex(DataGrid grid)
        {
            return grid.CurrentCell.Column.DisplayIndex;
        }

        /// <summary>
        /// 選択セルの行インデックスを取得します。
        /// </summary>
        /// <param name="grid">対象グリッド</param>
        /// <returns>行インデックス</returns>
        public static int GetSelectedRowIndex(DataGrid grid)
        {
            return grid.Items.IndexOf(grid.CurrentItem);
        }

        /// <summary>
        /// マウスカーソル位置のセルを取得します。
        /// </summary>
        /// <param name="sender">対象</param>
        /// <param name="e">マウスボタンイベントデータ</param>
        /// <returns>マウスカーソル位置のセル</returns>
        public static DataGridCell? GetCellAtMousePosition(object sender, MouseButtonEventArgs e)
        {
            var hit = VisualTreeHelper.HitTest((Visual)sender, e.GetPosition((IInputElement)sender));
            DependencyObject cell = VisualTreeHelper.GetParent(hit.VisualHit);
            while (cell != null && cell is not System.Windows.Controls.DataGridCell)
            {
                cell = VisualTreeHelper.GetParent(cell);
            }

            System.Windows.Controls.DataGridCell? targetCell = cell as System.Windows.Controls.DataGridCell;
            return targetCell;
        }

        /// <summary>
        /// 選択セルの行列インデックスリストを取得します。
        /// </summary>
        /// <param name="grid">対象</param>
        /// <returns>行列インデックスリスト</returns>
        public static List<RowColumnIndex> GetSelectedCellsIndex(DataGrid grid)
        {
            var ret = new List<RowColumnIndex>();

            var cells = grid.SelectedCells;
            foreach (var cell in cells)
            {
                ret.Add(new(grid.Items.IndexOf(cell.Item), cell.Column.DisplayIndex));
            }

            return ret;
        }

        /// <summary>
        /// 指定位置までスクロールを移動します。
        /// </summary>
        /// <param name="grid">対象</param>
        /// <param name="horizontalRatio">水平比率</param>
        /// <param name="verticalRatio">垂直比率</param>
        public static void MoveScrollTo(DataGrid grid, double horizontalRatio, double verticalRatio)
        {
            MoveVerticalScrollTo(grid, verticalRatio);
            MoveHorizontalScrollTo(grid, horizontalRatio);
        }

        /// <summary>
        /// 指定位置まで垂直スクロールを移動します。
        /// </summary>
        /// <param name="grid">対象</param>
        /// <param name="verticalRatio">垂直比率</param>
        public static void MoveVerticalScrollTo(DataGrid grid, double verticalRatio)
        {
            var scroll = GetScrollViewer(grid);
            if (scroll is null)
            {
                return;
            }

            var gridHeight = scroll.ScrollableHeight;

            scroll.ScrollToVerticalOffset(gridHeight * verticalRatio);
        }

        /// <summary>
        /// 指定位置まで水平スクロールを移動します。
        /// </summary>
        /// <param name="grid">対象</param>
        /// <param name="horizontalRatio">水平比率</param>
        public static void MoveHorizontalScrollTo(DataGrid grid, double horizontalRatio)
        {
            var scroll = GetScrollViewer(grid);
            if (scroll is null)
            {
                return;
            }

            var gridWidth = scroll.ScrollableWidth;

            scroll.ScrollToHorizontalOffset(gridWidth * horizontalRatio);
        }

        /// <summary>
        /// <see cref="DataGrid"/>内部のスクロールビューを取得します。
        /// </summary>
        /// <param name="grid">対象</param>
        /// <returns>スクロールビュー</returns>
        public static ScrollViewer? GetScrollViewer(DataGrid grid)
        {
            var child = VisualTreeHelper.GetChild(grid, 0) as Decorator;
            var scroll = child?.Child as ScrollViewer;

            return scroll;
        }

        /// <summary>
        /// 行列インデックス　クラス
        /// </summary>
        /// <param name="rowIndex">行インデックス</param>
        /// <param name="columnIndex">列インデックス</param>
        public class RowColumnIndex(int rowIndex, int columnIndex)
        {
            /// <summary>
            /// 行インデックス
            /// </summary>
            public int RowIndex { get; } = rowIndex;

            /// <summary>
            /// 列インデックス
            /// </summary>
            public int ColumnIndex { get; } = columnIndex;
        }
    }
}

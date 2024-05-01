using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfLib
{
    /// <summary>
    /// データグリッドスクロール同期クラス
    /// </summary>
    public class ScrollSynchronizer
    {
        //! スクロールビューワーリスト
        private readonly List<ScrollViewer> _scrollViewerList = [];

        //! スクロール方向
        private readonly SynchronizeDirection _direction;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="scrollViewerLiset">同期するデータグリッドリスト</param>
        /// <param name="direction">同期するスクロール方向</param>
        public ScrollSynchronizer(List<ScrollViewer> scrollViewerLiset, SynchronizeDirection direction = SynchronizeDirection.Both)
        {
            // データグリッド数を取得します。
            int count = scrollViewerLiset.Count;

            // 同期するデータグリッド数が1以下の場合、何もしない。
            if (count < 2)
            {
                return;
            }

            // データグリッド数分繰り返します。
            for (int i = 0; i < count; ++i)
            {
                // データグリッドのスクロールビューワーを取得します。
                var scrollViewer = scrollViewerLiset[i];

                // スクロールビューワーにイベントハンドラを設定します。
                scrollViewer.ScrollChanged += ScrollChanged;

                // スクロールビューワーを識別するためタグを設定します。
                scrollViewer.Tag = i;

                // スクロールビューワーリストに保存します。
                _scrollViewerList.Add(scrollViewer);
            }

            // スクロール方向を保存します。
            _direction = direction;
        }

        /// <summary>
        /// スクロールされた時に呼び出されるます。
        /// </summary>
        /// <param name="sender">スクロールビューワー</param>
        /// <param name="e">スクロールチェンジイベント</param>
        private void ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            var srcScrollViewer = sender as ScrollViewer;
            if(srcScrollViewer is null)
            {
                return;
            }

            // 同期するスクロール方向が水平方向の場合
            if (_direction.HasFlag(SynchronizeDirection.Horizontal))
            {
                // スクロールするオフセットを取得します。
                var offset = srcScrollViewer.HorizontalOffset;

                // スクロールビューワー数分繰り返します。
                foreach (var dstScrollVierwer in _scrollViewerList)
                {
                    // スクロールしたスクロールビューワーは無視します。
                    if (dstScrollVierwer.Tag == srcScrollViewer.Tag)
                    {
                        continue;
                    }

                    // 同期するスクロールビューワーをスクロールします。
                    dstScrollVierwer.ScrollToHorizontalOffset(offset);
                }
            }

            // 同期するスクロール方向が垂直方向の場合
            if (_direction.HasFlag(SynchronizeDirection.Vertical))
            {
                // スクロールするオフセットを取得します。
                var offset = srcScrollViewer.VerticalOffset;

                // スクロールビューワー数分繰り返します。
                foreach (var dstScrollVierwer in _scrollViewerList)
                {
                    // スクロールしたスクロールビューワーは無視します。
                    if (dstScrollVierwer.Tag == srcScrollViewer.Tag)
                    {
                        continue;
                    }

                    // 同期するスクロールビューワーをスクロールします。
                    dstScrollVierwer.ScrollToVerticalOffset(offset);
                }
            }
        }

        /// <summary>
        /// スクロールの同期する方向
        /// </summary>
        [Flags]
        public enum SynchronizeDirection
        {
            /// <summary>
            /// 水平方向
            /// </summary>
            Horizontal = 0x01,

            /// <summary>
            /// 垂直方向
            /// </summary>
            Vertical = 0x02,

            /// <summary>
            /// 両方
            /// </summary>
            Both = 0x03,
        }
    }
}

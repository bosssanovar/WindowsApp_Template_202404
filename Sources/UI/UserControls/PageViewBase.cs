using System.ComponentModel;
using System.Reactive.Disposables;
using System.Windows.Controls;

namespace UiParts.UserControls
{
    /// <summary>
    /// Pageのベースクラス
    /// </summary>
    public abstract class PageViewBase : UserControl, INotifyPropertyChanged
    {
        /// <summary>
        /// 変更通知
        /// </summary>
#pragma warning disable CS0067 // イベント 'MainWindowView.PropertyChanged' は使用されていません
        public event PropertyChangedEventHandler? PropertyChanged;
#pragma warning restore CS0067 // イベント 'MainWindowView.PropertyChanged' は使用されていません

        private readonly PageModelBase _modelBase;

        /// <summary>
        /// 破棄予約リスト
        /// </summary>
#pragma warning disable CA1051 // 参照可能なインスタンス フィールドを宣言しません
#pragma warning disable SA1401 // Fields should be private
        protected readonly CompositeDisposable _compositeDisposable = [];
#pragma warning restore SA1401 // Fields should be private
#pragma warning restore CA1051 // 参照可能なインスタンス フィールドを宣言しません

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="modelBase">モデル</param>
        public PageViewBase(PageModelBase modelBase)
        {
            _modelBase = modelBase;

            this.Loaded += PageViewBase_Loaded;
            this.Unloaded += PageViewBase_Unloaded;
        }

        /// <summary>
        /// 表示更新します。
        /// </summary>
        public void Update()
        {
            _modelBase.UpdateEntities();
        }

        /// <summary>
        /// 設定値を確定します。
        /// </summary>
        public void Commit()
        {
            _modelBase.CommitEntities();
        }

        private void PageViewBase_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            _modelBase.UpdateEntities();
        }

        private void PageViewBase_Unloaded(object sender, System.Windows.RoutedEventArgs e)
        {
            Commit();

            _modelBase.Dispose();
            _compositeDisposable.Dispose();
        }
    }
}

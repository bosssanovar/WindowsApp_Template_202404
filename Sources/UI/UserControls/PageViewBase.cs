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
        #region Constants -------------------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Fields ----------------------------------------------------------------------------------------

        private readonly PageModelBase _modelBase;

        /// <summary>
        /// 破棄予約リスト
        /// </summary>
#pragma warning disable CA1051 // 参照可能なインスタンス フィールドを宣言しません
#pragma warning disable SA1401 // Fields should be private
        protected readonly CompositeDisposable _compositeDisposable = [];
#pragma warning restore SA1401 // Fields should be private
#pragma warning restore CA1051 // 参照可能なインスタンス フィールドを宣言しません

        #endregion --------------------------------------------------------------------------------------------

        #region Properties ------------------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Events ----------------------------------------------------------------------------------------

        /// <summary>
        /// 変更通知イベント（ReactiveProperty採用時のメモリリーク対策）
        /// </summary>
#pragma warning disable CS0067 // イベント 'MainWindowView.PropertyChanged' は使用されていません
        public event PropertyChangedEventHandler? PropertyChanged;
#pragma warning restore CS0067 // イベント 'MainWindowView.PropertyChanged' は使用されていません

        #endregion --------------------------------------------------------------------------------------------

        #region Constructor -----------------------------------------------------------------------------------

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

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - public ------------------------------------------------------------------------------

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

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - internal ----------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - protected ---------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - private -----------------------------------------------------------------------------

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

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - override ----------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Inner Class/Enum/etc. -------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------
    }
}

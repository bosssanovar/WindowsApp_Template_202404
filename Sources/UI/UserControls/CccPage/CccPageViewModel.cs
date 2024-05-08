using BBBEntity.ValueObject;

using DomainService;

using Reactive.Bindings;
using Reactive.Bindings.Extensions;

using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace UiParts.UserControls.CccPage
{
    /// <summary>
    /// CCCページの疑似ViewModel
    /// </summary>
    public partial class CccPageView
    {
        #region Constants -------------------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Fields ----------------------------------------------------------------------------------------

        private CccPageModel? _model;

        private readonly CompositeDisposable _disposable = [];

        #endregion --------------------------------------------------------------------------------------------

        #region Properties ------------------------------------------------------------------------------------

        /// <summary>
        /// マトリクス行列数
        /// </summary>
        public ReadOnlyReactivePropertySlim<int> Count { get; private set; }

        /// <summary>
        /// 行ヘッダー
        /// </summary>
        public List<RowHeader> RowHeaders { get; } = [];

        /// <summary>
        /// 列ヘッダー
        /// </summary>
        public List<ColumnHeader> ColumnHeaders { get; } = [];

        /// <summary>
        /// CCC設定
        /// </summary>
        public ReadOnlyReactiveCollection<CccDetailViewModel> CCCs { get; private set; }

        #endregion --------------------------------------------------------------------------------------------

        #region Events ----------------------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Constructor -----------------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - public ------------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - internal ----------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - protected ---------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - private -----------------------------------------------------------------------------

        private void CccPageViewModel(CccPageModel model)
        {
            _model = model;

            Count = _model.AaaEntity.Select(x => x.YYY.Value).ToReadOnlyReactivePropertySlim();

            for (int i = 0; i < Count.Value; i++)
            {
                RowHeaders.Add(new($"{i + 1}", $"スイッチ{i + 1}", "放送階選択", "EL1"));
            }

            ColumnHeaders.Add(new("スピーカー名称"));
            ColumnHeaders.Add(new("SP"));

            CCCs =
                _model.Details.ToReadOnlyReactiveCollection(
                    x => new CccDetailViewModel(x),
                    Scheduler.Immediate)
                .AddTo(_disposable);
        }

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - override ----------------------------------------------------------------------------

        /// <inheritdoc/>
        public override void Update()
        {
            // バインドを一時切断
            Binding b = new("CCCs")
            {
                Source = null,
            };
            grid.SetBinding(DataGrid.ItemsSourceProperty, b);

            base.Update();

            // バインドを再構築
            b = new("CCCs")
            {
                Source = this,
            };
            grid.SetBinding(DataGrid.ItemsSourceProperty, b);

            InitColumns(Count.Value);
            UpdatePreview();
            ResizeGridDummy();
        }

        #endregion --------------------------------------------------------------------------------------------

        #region Inner Class/Enum/etc. -------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------
    }
}

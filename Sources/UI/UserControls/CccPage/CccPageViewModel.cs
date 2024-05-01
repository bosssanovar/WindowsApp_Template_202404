using BBBEntity.ValueObject;

using DomainService;

using Reactive.Bindings;
using Reactive.Bindings.Extensions;

using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Text;
using System.Windows;

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

            CCCs = _model.Details.ToReadOnlyReactiveCollection(x => new CccDetailViewModel(x))
                .AddTo(_disposable);
        }

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - override ----------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Inner Class/Enum/etc. -------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------
    }
}

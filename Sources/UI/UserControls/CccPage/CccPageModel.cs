using Reactive.Bindings;
using Reactive.Bindings.Extensions;

using System.Collections.ObjectModel;

using Usecase;

namespace UiParts.UserControls.CccPage
{
    /// <summary>
    /// CCCページのモデル
    /// </summary>
    public class CccPageModel : PageModelBase
    {
        #region Constants -------------------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Fields ----------------------------------------------------------------------------------------

        private readonly DisplaySettingsUsecase _displaySettingsUsecase;

        private readonly CommitSettingsUsecase _commitSettingsUsecase;

        #endregion --------------------------------------------------------------------------------------------

        #region Properties ------------------------------------------------------------------------------------

        /// <summary>
        /// AAA Entity
        /// </summary>
        public ReactivePropertySlim<AaaEntity.Entity.AaaEntity> AaaEntity { get; }

        /// <summary>
        /// CCC Entity
        /// </summary>
        public ReactivePropertySlim<CccEntity.Entity.CccEntity> CccEntity { get; }

        /// <summary>
        /// コレクション型のModel
        /// </summary>
        public ObservableCollection<CccDetailModel> Details { get; } = [];

        #endregion --------------------------------------------------------------------------------------------

        #region Events ----------------------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Constructor -----------------------------------------------------------------------------------

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="displaySettingsUsecase"><see cref="DisplaySettingsUsecase"/>インスタンス</param>
        /// <param name="commitSettingsUsecase"><see cref="CommitSettingsUsecase"/>インスタンス</param>
        public CccPageModel(
            DisplaySettingsUsecase displaySettingsUsecase,
            CommitSettingsUsecase commitSettingsUsecase)
        {
            _displaySettingsUsecase = displaySettingsUsecase;
            _commitSettingsUsecase = commitSettingsUsecase;

            AaaEntity = new(_displaySettingsUsecase.GetAaaEntity());
            AaaEntity.AddTo(_compositeDisposable);
            CccEntity = new(_displaySettingsUsecase.GetCccEntity());
            CccEntity.AddTo(_compositeDisposable);

            InitDetails();
        }

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - public ------------------------------------------------------------------------------

        /// <summary>
        /// CCC Entityの更新通知を発行します。
        /// </summary>
        public void ForceNotifyCccEntity()
        {
            CccEntity.ForceNotify();
        }

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - internal ----------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - protected ---------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - private -----------------------------------------------------------------------------

        private void InitDetails()
        {
            ClearDetails();
            foreach (var detail in CccEntity.Value.Details)
            {
                var detailModel = new CccDetailModel(detail);
                Details.Add(detailModel);
            }
        }

        private void ClearDetails()
        {
            Details.Clear();
        }

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - override ----------------------------------------------------------------------------

        /// <summary>
        /// 全てのEntityを更新します。
        /// </summary>
        public override void UpdateEntities()
        {
            AaaEntity.Value = _displaySettingsUsecase.GetAaaEntity();
            CccEntity.Value = _displaySettingsUsecase.GetCccEntity();

            InitDetails();
        }

        /// <summary>
        /// BBBEntityの設定値を確定します。
        /// </summary>
        public override void CommitEntities()
        {
            _commitSettingsUsecase.CommitCccEntity(CccEntity.Value);
        }

        #endregion --------------------------------------------------------------------------------------------

        #region Inner Class/Enum/etc. -------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------
    }
}

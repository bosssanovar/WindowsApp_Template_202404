using CCCEntity.Entity;

using Reactive.Bindings;
using Reactive.Bindings.Extensions;

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
        /// CCC Entity
        /// </summary>
        public ReactivePropertySlim<CCCEntity.Entity.CCCEntity> CccEntity { get; }

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

            CccEntity = new(_displaySettingsUsecase.GetCCCEntity());
            CccEntity.AddTo(_compositeDisposable);
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

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - override ----------------------------------------------------------------------------

        /// <summary>
        /// 全てのEntityを更新します。
        /// </summary>
        public override void UpdateEntities()
        {
            CccEntity.Value = _displaySettingsUsecase.GetCCCEntity();
        }

        /// <summary>
        /// BBBEntityの設定値を確定します。
        /// </summary>
        public override void CommitEntities()
        {
            _commitSettingsUsecase.CommitCCCEntity(CccEntity.Value);
        }

        #endregion --------------------------------------------------------------------------------------------

        #region Inner Class/Enum/etc. -------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------
    }
}

using Reactive.Bindings;
using Reactive.Bindings.Extensions;

using Usecase;

namespace UiParts.Page.BbbPage
{
    /// <summary>
    /// BBBページのモデル
    /// </summary>
    public class BbbPageModel : PageModelBase
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
        /// BBB Entity
        /// </summary>
        public ReactivePropertySlim<BbbEntity.Entity.BbbEntity> BbbEntity { get; }

        #endregion --------------------------------------------------------------------------------------------

        #region Events ----------------------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Constructor -----------------------------------------------------------------------------------

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="displaySettingsUsecase"><see cref="DisplaySettingsUsecase"/>インスタンス</param>
        /// <param name="commitSettingsUsecase"><see cref="CommitSettingsUsecase"/>インスタンス</param>
        public BbbPageModel(
            DisplaySettingsUsecase displaySettingsUsecase,
            CommitSettingsUsecase commitSettingsUsecase)
        {
            _displaySettingsUsecase = displaySettingsUsecase;
            _commitSettingsUsecase = commitSettingsUsecase;

            AaaEntity = new(_displaySettingsUsecase.GetAaaEntity());
            AaaEntity.AddTo(_compositeDisposable);

            BbbEntity = new(_displaySettingsUsecase.GetBbbEntity());
            BbbEntity.AddTo(_compositeDisposable);
        }

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - public ------------------------------------------------------------------------------

        /// <summary>
        /// BBB Entityの更新通知を発行します。
        /// </summary>
        public void ForceNotifyBbbEntity()
        {
            BbbEntity.ForceNotify();
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
            AaaEntity.Value = _displaySettingsUsecase.GetAaaEntity();
            BbbEntity.Value = _displaySettingsUsecase.GetBbbEntity();
        }

        /// <summary>
        /// BBBEntityの設定値を確定します。
        /// </summary>
        public override void CommitEntities()
        {
            _commitSettingsUsecase.CommitBbbEntity(BbbEntity.Value);
        }

        #endregion --------------------------------------------------------------------------------------------

        #region Inner Class/Enum/etc. -------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------
    }
}

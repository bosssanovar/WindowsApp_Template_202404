using Reactive.Bindings;
using Reactive.Bindings.Extensions;

using Usecase;

namespace UiParts.UserControls.AaaAndBbbPage
{
    /// <summary>
    /// AAA and BBBページのモデル
    /// </summary>
    public class AaaAndBbbPageModel : PageModelBase
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
        public ReactivePropertySlim<AAAEntity.Entity.AAAEntity> AaaEntity { get; }

        /// <summary>
        /// BBB Entity
        /// </summary>
        public ReactivePropertySlim<BBBEntity.Entity.BBBEntity> BbbEntity { get; }

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
        /// <param name="displaySettingsUsecase">DisplaySettingsUsecaseインスタンス</param>
        /// <param name="commitSettingsUsecase">CommitSettingsUsecaseインスタンス</param>
        public AaaAndBbbPageModel(
            DisplaySettingsUsecase displaySettingsUsecase,
            CommitSettingsUsecase commitSettingsUsecase)
        {
            _displaySettingsUsecase = displaySettingsUsecase;
            _commitSettingsUsecase = commitSettingsUsecase;

            AaaEntity = new(_displaySettingsUsecase.GetAAAEntity());
            AaaEntity.AddTo(_compositeDisposable);

            BbbEntity = new(_displaySettingsUsecase.GetBBBEntity());
            BbbEntity.AddTo(_compositeDisposable);

            CccEntity = new(_displaySettingsUsecase.GetCCCEntity());
            CccEntity.AddTo(_compositeDisposable);
        }

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - public ------------------------------------------------------------------------------

        /// <summary>
        /// AAAEntityの変更通知を発行します。
        /// </summary>
        public void ForceNotifyAaaEntity()
        {
            AaaEntity.ForceNotify();
        }

        /// <summary>
        /// BBBEntityの変更通知を発行します。
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
            AaaEntity.Value = _displaySettingsUsecase.GetAAAEntity();
            BbbEntity.Value = _displaySettingsUsecase.GetBBBEntity();
            CccEntity.Value = _displaySettingsUsecase.GetCCCEntity();
        }

        /// <summary>
        /// 全てのEntityの設定値を確定します。
        /// </summary>
        public override void CommitEntities()
        {
            _commitSettingsUsecase.CommitAAAEntity(AaaEntity.Value);
            _commitSettingsUsecase.CommitBBBEntity(BbbEntity.Value);
            _commitSettingsUsecase.CommitCCCEntity(CccEntity.Value);
        }

        #endregion --------------------------------------------------------------------------------------------

        #region Inner Class/Enum/etc. -------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------
    }
}

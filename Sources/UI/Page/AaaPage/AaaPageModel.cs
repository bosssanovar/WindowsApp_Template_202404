using Reactive.Bindings;
using Reactive.Bindings.Extensions;

using Usecase;

namespace UiParts.Page.AaaPage
{
    /// <summary>
    /// AAAページのモデル
    /// </summary>
    public class AaaPageModel : PageModelBase
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

        /// <summary>
        /// CCC Entity
        /// </summary>
        public ReactivePropertySlim<CccEntity.Entity.CccEntity> CccEntity { get; }

        #endregion --------------------------------------------------------------------------------------------

        #region Events ----------------------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Constructor -----------------------------------------------------------------------------------

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="displaySettingsUsecase"><see cref="DisplaySettingsUsecase"/>インスタンス</param>
        /// <param name="commitSettingsUsecase"><see cref="CommitSettingsUsecase"/>インスタンス</param>
        public AaaPageModel(
            DisplaySettingsUsecase displaySettingsUsecase,
            CommitSettingsUsecase commitSettingsUsecase)
        {
            _displaySettingsUsecase = displaySettingsUsecase;
            _commitSettingsUsecase = commitSettingsUsecase;

            AaaEntity = new(_displaySettingsUsecase.GetAaaEntity());
            AaaEntity.AddTo(_compositeDisposable);

            BbbEntity = new(_displaySettingsUsecase.GetBbbEntity());
            BbbEntity.AddTo(_compositeDisposable);

            CccEntity = new(_displaySettingsUsecase.GetCccEntity());
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
            AaaEntity.Value = _displaySettingsUsecase.GetAaaEntity();
            BbbEntity.Value = _displaySettingsUsecase.GetBbbEntity();
            CccEntity.Value = _displaySettingsUsecase.GetCccEntity();
        }

        /// <summary>
        /// 全てのEntityの設定値を確定します。
        /// </summary>
        public override void CommitEntities()
        {
            _commitSettingsUsecase.CommitAaaEntity(AaaEntity.Value);
            _commitSettingsUsecase.CommitBbbEntity(BbbEntity.Value);
            _commitSettingsUsecase.CommitCccEntity(CccEntity.Value);
        }

        #endregion --------------------------------------------------------------------------------------------

        #region Inner Class/Enum/etc. -------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------
    }
}

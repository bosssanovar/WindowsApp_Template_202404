using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using Usecase;

namespace UiParts.UserControls.BbbPage
{
    public class BbbPageModel : PageModelBase
    {
        private readonly DisplaySettingsUsecase _displaySettingsUsecase;

        private readonly CommitSettingsUsecase _commitSettingsUsecase;

        public ReactivePropertySlim<AAAEntity.Entity.AAAEntity> AaaEntity { get; }
        public ReactivePropertySlim<BBBEntity.Entity.BBBEntity> BbbEntity { get; }

        public BbbPageModel(
            DisplaySettingsUsecase displaySettingsUsecase,
            CommitSettingsUsecase commitSettingsUsecase)
        {
            _displaySettingsUsecase = displaySettingsUsecase;
            _commitSettingsUsecase = commitSettingsUsecase;

            AaaEntity = new(_displaySettingsUsecase.GetAAAEntity());
            AaaEntity.AddTo(_compositeDisposable);

            BbbEntity = new(_displaySettingsUsecase.GetBBBEntity());
            BbbEntity.AddTo(_compositeDisposable);
        }

        public void ForceNotifyBbbEntity()
        {
            BbbEntity.ForceNotify();
        }

        public override void UpdateEntities()
        {
            AaaEntity.Value = _displaySettingsUsecase.GetAAAEntity();
            BbbEntity.Value = _displaySettingsUsecase.GetBBBEntity();
        }

        public override void CommitEntities()
        {
            _commitSettingsUsecase.CommitBBBEntity(BbbEntity.Value);
        }
    }
}

﻿using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using Usecase;

namespace UiParts.UserControls.AaaAndBbbPage
{
    public class AaaAndBbbPageModel : PageModelBase
    {
        private readonly DisplaySettingsUsecase _displaySettingsUsecase;

        private readonly CommitSettingsUsecase _commitSettingsUsecase;

        public ReactivePropertySlim<AAAEntity.Entity.AAAEntity> AaaEntity { get; }
        public ReactivePropertySlim<BBBEntity.Entity.BBBEntity> BbbEntity { get; }

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
        }

        public void ForceNotifyAaaEntity()
        {
            AaaEntity.ForceNotify();
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
            _commitSettingsUsecase.CommitAAAEntity(AaaEntity.Value);
            _commitSettingsUsecase.CommitBBBEntity(BbbEntity.Value);
        }
    }
}
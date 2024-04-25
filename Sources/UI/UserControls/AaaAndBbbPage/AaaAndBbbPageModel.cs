﻿using Reactive.Bindings;
using Reactive.Bindings.Extensions;

using Usecase;

namespace UiParts.UserControls.AaaAndBbbPage
{
    /// <summary>
    /// AAA and BBBページのモデル
    /// </summary>
    public class AaaAndBbbPageModel : PageModelBase
    {
        private readonly DisplaySettingsUsecase _displaySettingsUsecase;

        private readonly CommitSettingsUsecase _commitSettingsUsecase;

        /// <summary>
        /// AAA Entity
        /// </summary>
        public ReactivePropertySlim<AAAEntity.Entity.AAAEntity> AaaEntity { get; }

        /// <summary>
        /// BBB Entity
        /// </summary>
        public ReactivePropertySlim<BBBEntity.Entity.BBBEntity> BbbEntity { get; }

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
        }

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

        /// <summary>
        /// 全てのEntityを更新します。
        /// </summary>
        public override void UpdateEntities()
        {
            AaaEntity.Value = _displaySettingsUsecase.GetAAAEntity();
            BbbEntity.Value = _displaySettingsUsecase.GetBBBEntity();
        }

        /// <summary>
        /// 全てのEntityの設定値を確定します。
        /// </summary>
        public override void CommitEntities()
        {
            _commitSettingsUsecase.CommitAAAEntity(AaaEntity.Value);
            _commitSettingsUsecase.CommitBBBEntity(BbbEntity.Value);
        }
    }
}

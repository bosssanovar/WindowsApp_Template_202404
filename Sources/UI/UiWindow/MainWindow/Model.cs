using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using Usecase;

namespace UiParts.UiWindow.MainWindow
{
    public class Model : ModelBase
    {
        private readonly DisplaySettingsUsecase _displaySettingsUsecase;

        private readonly InitializeUsecase _initializeUsecase;

        private readonly SaveDataUsecase _saveDataUsecase;

        public ReactivePropertySlim<AAAEntity.Entity.AAAEntity> AaaEntity { get; }
        public ReactivePropertySlim<BBBEntity.Entity.BBBEntity> BbbEntity { get; }

        public Model(
            DisplaySettingsUsecase displaySettingsUsecase,
            InitializeUsecase initializeUsecase,
            SaveDataUsecase saveDataUsecase)
        {
            _displaySettingsUsecase = displaySettingsUsecase;
            _initializeUsecase = initializeUsecase;
            _saveDataUsecase = saveDataUsecase;

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

        public void Initialize()
        {
            _initializeUsecase.Execute();

            AaaEntity.Value = _displaySettingsUsecase.GetAAAEntity();
            BbbEntity.Value = _displaySettingsUsecase.GetBBBEntity();
        }

        public void Save()
        {
            _saveDataUsecase.Execute();
        }
    }
}

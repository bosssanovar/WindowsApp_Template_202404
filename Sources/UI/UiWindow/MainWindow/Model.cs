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

        private readonly OpenDataUsecase _openDataUsecase;

        private readonly CommitSettingsUsecase _commitSettingsUsecase;

        public ReactivePropertySlim<AAAEntity.Entity.AAAEntity> AaaEntity { get; }
        public ReactivePropertySlim<BBBEntity.Entity.BBBEntity> BbbEntity { get; }

        public Model(
            DisplaySettingsUsecase displaySettingsUsecase,
            InitializeUsecase initializeUsecase,
            SaveDataUsecase saveDataUsecase,
            OpenDataUsecase openDataUsecase,
            CommitSettingsUsecase commitSettingsUsecase)
        {
            _displaySettingsUsecase = displaySettingsUsecase;
            _initializeUsecase = initializeUsecase;
            _saveDataUsecase = saveDataUsecase;
            _openDataUsecase = openDataUsecase;
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

        public void Initialize()
        {
            _initializeUsecase.Execute();
            UpdateEntities();
        }

        private void UpdateEntities()
        {
            AaaEntity.Value = _displaySettingsUsecase.GetAAAEntity();
            BbbEntity.Value = _displaySettingsUsecase.GetBBBEntity();
        }

        public bool SaveDataFile()
        {
            CommitEntities();

            return _saveDataUsecase.Execute();
        }

        private void CommitEntities()
        {
            _commitSettingsUsecase.CommitAAAEntity(AaaEntity.Value);
            _commitSettingsUsecase.CommitBBBEntity(BbbEntity.Value);
        }

        public OpenDataUsecase.OpenResult OpenDataFile()
        {
            var result = _openDataUsecase.Execute();
            if (result is not OpenDataUsecase.OpenResult.Completed) return result;

            UpdateEntities();

            return OpenDataUsecase.OpenResult.Completed;
        }
    }
}

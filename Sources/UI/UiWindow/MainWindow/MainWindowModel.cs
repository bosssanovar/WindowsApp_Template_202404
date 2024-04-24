using Usecase;

namespace UiParts.UiWindow.MainWindow
{
    public class MainWindowModel : WindowModelBase
    {
        private readonly InitializeUsecase _initializeUsecase;

        private readonly SaveDataUsecase _saveDataUsecase;

        private readonly OpenDataUsecase _openDataUsecase;

#pragma warning disable IDE0290 // プライマリ コンストラクターの使用
        public MainWindowModel(
#pragma warning restore IDE0290 // プライマリ コンストラクターの使用
            InitializeUsecase initializeUsecase,
            SaveDataUsecase saveDataUsecase,
            OpenDataUsecase openDataUsecase)
        {
            _initializeUsecase = initializeUsecase;
            _saveDataUsecase = saveDataUsecase;
            _openDataUsecase = openDataUsecase;
        }

        public void Initialize()
        {
            _initializeUsecase.Execute();
        }

        public bool SaveDataFile()
        {
            return _saveDataUsecase.Execute();
        }

        public OpenDataUsecase.OpenResult OpenDataFile()
        {
            return _openDataUsecase.Execute();
        }
    }
}

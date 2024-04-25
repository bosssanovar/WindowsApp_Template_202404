using Usecase;

namespace UiParts.UiWindow.MainWindow
{
    /// <summary>
    /// MainWindowのModelクラス
    /// </summary>
    public class MainWindowModel : WindowModelBase
    {
        private readonly InitializeUsecase _initializeUsecase;

        private readonly SaveDataUsecase _saveDataUsecase;

        private readonly OpenDataUsecase _openDataUsecase;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="initializeUsecase">InitializeUsecaseインスタンス</param>
        /// <param name="saveDataUsecase">SaveDataUsecaseインスタンス</param>
        /// <param name="openDataUsecase">OpenDataUsecaseインスタンス</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0290:プライマリ コンストラクターの使用", Justification = "<保留中>")]
        public MainWindowModel(
            InitializeUsecase initializeUsecase,
            SaveDataUsecase saveDataUsecase,
            OpenDataUsecase openDataUsecase)
        {
            _initializeUsecase = initializeUsecase;
            _saveDataUsecase = saveDataUsecase;
            _openDataUsecase = openDataUsecase;
        }

        /// <summary>
        /// 初期化します。
        /// </summary>
        public void Initialize()
        {
            _initializeUsecase.Execute();
        }

        /// <summary>
        /// 設定をファイルに保存します。
        /// </summary>
        /// <returns>成功したらtrue</returns>
        public bool SaveDataFile()
        {
            return _saveDataUsecase.Execute();
        }

        /// <summary>
        /// 設定をファイルから読み込みます。
        /// </summary>
        /// <returns>読み込み処理結果</returns>
        public OpenDataUsecase.OpenResult OpenDataFile()
        {
            return _openDataUsecase.Execute();
        }
    }
}

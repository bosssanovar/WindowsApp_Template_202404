using Usecase;

namespace UiParts.UiWindow.MainWindow
{
    /// <summary>
    /// MainWindowのModelクラス
    /// </summary>
    public class MainWindowModel : WindowModelBase
    {
        #region Constants -------------------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Fields ----------------------------------------------------------------------------------------

        private readonly InitializeUsecase _initializeUsecase;

        private readonly SaveDataUsecase _saveDataUsecase;

        private readonly OpenDataUsecase _openDataUsecase;

        #endregion --------------------------------------------------------------------------------------------

        #region Properties ------------------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Events ----------------------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Constructor -----------------------------------------------------------------------------------

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

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - public ------------------------------------------------------------------------------

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

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - internal ----------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - protected ---------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - private -----------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - override ----------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Inner Class/Enum/etc. -------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------
    }
}

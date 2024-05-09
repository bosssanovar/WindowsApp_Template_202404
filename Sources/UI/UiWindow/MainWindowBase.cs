using Reactive.Bindings;

using System.Windows;

namespace UiParts.UiWindow
{
    /// <summary>
    /// MainWindowのベースクラス
    /// </summary>
    public abstract class MainWindowBase : WindowBase
    {
        #region Constants -------------------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Fields ----------------------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Properties ------------------------------------------------------------------------------------

        /// <summary>
        /// サイドメニューを開くコマンド
        /// </summary>
        public ReactiveCommand OpenSideMenuCommand { get; } = new();

        /// <summary>
        /// Homeに移動するコマンド
        /// </summary>
        public ReactiveCommand MoveHomeCommand { get; } = new();

        /// <summary>
        /// 設定値を初期化するコマンド
        /// </summary>
        public ReactiveCommand InitializeCommand { get; } = new();

        /// <summary>
        /// 設定をファイルに保存するコマンド
        /// </summary>
        public ReactiveCommand SaveCommand { get; } = new();

        /// <summary>
        /// 設定をファイルから読み込むコマンド
        /// </summary>
        public ReactiveCommand OpenCommand { get; } = new();

        #endregion --------------------------------------------------------------------------------------------

        #region Events ----------------------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Constructor -----------------------------------------------------------------------------------

        static MainWindowBase()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MainWindowBase), new FrameworkPropertyMetadata(typeof(MainWindowBase)));
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="model">モデル</param>
#pragma warning disable IDE0290 // プライマリ コンストラクターの使用
        public MainWindowBase(WindowModelBase model)
#pragma warning restore IDE0290 // プライマリ コンストラクターの使用
            : base(model)
        {
        }

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - public ------------------------------------------------------------------------------

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

using System.Windows;
using System.Windows.Threading;

namespace UiParts.UiWindow.Message
{
    /// <summary>
    /// MessageWindowView.xaml の相互作用ロジック
    /// </summary>
    public partial class MessageWindow : Window
    {
        #region Constants -------------------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Fields ----------------------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Properties ------------------------------------------------------------------------------------

        /// <summary>
        /// キャプション
        /// </summary>
        public string Caption { get; }

        /// <summary>
        /// メッセージ
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// 結果
        /// </summary>
        public MessageBoxResult Result { get; private set; } = MessageBoxResult.None;

        /// <summary>
        /// ウィンドウ幅
        /// </summary>
        public double WindowWidth { get; private set; }

        /// <summary>
        /// ウィンドウ高さ
        /// </summary>
        public double WindowHeight { get; private set; }

        #endregion --------------------------------------------------------------------------------------------

        #region Events ----------------------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Constructor -----------------------------------------------------------------------------------

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="message">メッセージ文言</param>
        /// <param name="caption">キャプション文言</param>
        public MessageWindow(string message, string caption)
        {
            Caption = caption;
            Message = message;

            CalculateWindowSize();

            InitializeComponent();
        }

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - public ------------------------------------------------------------------------------

        /// <summary>
        /// 表示します。
        /// </summary>
        /// <param name="owner">親ウィンドウ</param>
        /// <param name="message">メッセージ文言</param>
        /// <param name="caption">キャプション文言</param>
        /// <returns>結果</returns>
        public static MessageBoxResult Show(Window owner, string message, string caption)
        {
            var messageWindowView = new MessageWindow(message, caption);
            messageWindowView.Owner = owner;
            messageWindowView.ShowDialog();

            return messageWindowView.Result;
        }

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - internal ----------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - protected ---------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - private -----------------------------------------------------------------------------

        private void CalculateWindowSize()
        {
            WindowWidth = 400.0;
            WindowHeight = 300.0;
        }

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - override ----------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Inner Class/Enum/etc. -------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------
    }
}

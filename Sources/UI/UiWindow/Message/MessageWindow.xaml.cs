using Reactive.Bindings;

using System.Windows;
using System.Windows.Media.Animation;
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
        /// 閉じるコマンド
        /// </summary>
        public ReactiveCommand CloseCommand { get; } = new();

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

            CloseCommand.Subscribe(() =>
            {
                BeginDismissAnimation(() => Close());
            });

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
            IBlur? blur = owner as IBlur;
            blur?.BlurOn();

            var messageWindowView = new MessageWindow(message, caption);
            messageWindowView.Owner = owner;
            messageWindowView.ShowDialog();

            blur?.BlurOff();

            return messageWindowView.Result;
        }

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - internal ----------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - protected ---------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - private -----------------------------------------------------------------------------

        private void BeginShowAnimation()
        {
            var sb = FindResource("Show") as Storyboard;
            if (sb is not null)
            {
                sb.Begin();
            }
        }

        private void BeginDismissAnimation(Action onCompleted)
        {
            var sb = FindResource("Dismiss") as Storyboard;
            if (sb is not null)
            {
                sb.Completed += (sender, e) =>
                {
                    onCompleted?.Invoke();
                };

                sb.Begin();
            }
        }

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - override ----------------------------------------------------------------------------

        /// <inheritdoc/>
        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);

            BeginShowAnimation();
        }

        #endregion --------------------------------------------------------------------------------------------

        #region Inner Class/Enum/etc. -------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------
    }
}

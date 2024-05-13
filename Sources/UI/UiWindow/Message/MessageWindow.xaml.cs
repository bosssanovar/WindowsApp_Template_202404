using Reactive.Bindings;

using System.Reactive.Linq;
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

        private readonly ReactivePropertySlim<MessageBoxButton> _buttonType = new();

        private MessageBoxImage _imageType;

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
        /// OKコマンド
        /// </summary>
        public ReactiveCommand OkCommand { get; } = new();

        /// <summary>
        /// Cancelコマンド
        /// </summary>
        public ReactiveCommand CancelCommand { get; } = new();

        /// <summary>
        /// Yesコマンド
        /// </summary>
        public ReactiveCommand YesCommand { get; } = new();

        /// <summary>
        /// Noコマンド
        /// </summary>
        public ReactiveCommand NoCommand { get; } = new();

        /// <summary>
        /// OK
        /// </summary>
        public ReadOnlyReactivePropertySlim<bool> IsButtonOk { get; }

        /// <summary>
        /// OK/Cancel
        /// </summary>
        public ReadOnlyReactivePropertySlim<bool> IsButtonOkCancel { get; }

        /// <summary>
        /// Yes/No/Cancel
        /// </summary>
        public ReadOnlyReactivePropertySlim<bool> IsButtonYesNoCancel { get; }

        /// <summary>
        /// Yes/No
        /// </summary>
        public ReadOnlyReactivePropertySlim<bool> IsButtonYesNo { get; }

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

            OkCommand.Subscribe(() =>
            {
                Result = MessageBoxResult.OK;
                BeginDismissAnimation(() => Close());
            });

            CancelCommand.Subscribe(() =>
            {
                Result = MessageBoxResult.Cancel;
                BeginDismissAnimation(() => Close());
            });

            YesCommand.Subscribe(() =>
            {
                Result = MessageBoxResult.Yes;
                BeginDismissAnimation(() => Close());
            });

            NoCommand.Subscribe(() =>
            {
                Result = MessageBoxResult.No;
                BeginDismissAnimation(() => Close());
            });

            IsButtonOk = _buttonType.Select(x => x == MessageBoxButton.OK)
                .ToReadOnlyReactivePropertySlim();

            IsButtonOkCancel = _buttonType.Select(x => x == MessageBoxButton.OKCancel)
                .ToReadOnlyReactivePropertySlim();

            IsButtonYesNoCancel = _buttonType.Select(x => x == MessageBoxButton.YesNoCancel)
                .ToReadOnlyReactivePropertySlim();

            IsButtonYesNo = _buttonType.Select(x => x == MessageBoxButton.YesNo)
                .ToReadOnlyReactivePropertySlim();

            InitializeComponent();
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="message">メッセージ文言</param>
        /// <param name="caption">キャプション文言</param>
        /// <param name="buttonType">ボタン種別</param>
        /// <param name="imageType">画像種別</param>
        public MessageWindow(string message, string caption, MessageBoxButton buttonType, MessageBoxImage imageType)
            : this(message, caption)
        {
            _buttonType.Value = buttonType;
            _imageType = imageType;
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
        public static async Task<MessageBoxResult> ShowAsync(Window owner, string message, string caption)
        {
            IBlur? blur = owner as IBlur;
            if (blur is not null)
            {
                await blur.BlurOnAsync();
            }

            var messageWindowView = new MessageWindow(message, caption);
            messageWindowView.Owner = owner;
            messageWindowView.ShowDialog();

            if (blur is not null)
            {
                await blur.BlurOffAsync();
            }

            return messageWindowView.Result;
        }

        /// <summary>
        /// 表示します。
        /// </summary>
        /// <param name="owner">親ウィンドウ</param>
        /// <param name="message">メッセージ文言</param>
        /// <param name="caption">キャプション文言</param>
        /// <param name="button">ボタン種別</param>
        /// <param name="image">画像種別</param>
        /// <returns>結果</returns>
        public static async Task<MessageBoxResult> ShowAsync(
            Window owner,
            string message,
            string caption,
            MessageBoxButton button,
            MessageBoxImage image)
        {
            IBlur? blur = owner as IBlur;
            if (blur is not null)
            {
                await blur.BlurOnAsync();
            }

            var messageWindowView = new MessageWindow(message, caption, button, image);
            messageWindowView.Owner = owner;
            messageWindowView.ShowDialog();

            if (blur is not null)
            {
                await blur.BlurOffAsync();
            }

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

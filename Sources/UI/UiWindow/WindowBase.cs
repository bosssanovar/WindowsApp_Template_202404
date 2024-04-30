using Reactive.Bindings;
using Reactive.Bindings.Extensions;

using System.ComponentModel;
using System.Reactive.Disposables;
using System.Windows;

namespace UiParts.UiWindow
{
    /// <summary>
    /// Windowのベースクラス
    /// </summary>
    public abstract class WindowBase : Window, INotifyPropertyChanged
    {
        #region Constants -------------------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Fields ----------------------------------------------------------------------------------------

        private readonly WindowModelBase _model;

        /// <summary>
        /// 破棄予約リスト
        /// </summary>
#pragma warning disable CA1051 // 参照可能なインスタンス フィールドを宣言しません
#pragma warning disable SA1401 // Fields should be private
        protected readonly CompositeDisposable _compositeDisposable = [];
#pragma warning restore SA1401 // Fields should be private
#pragma warning restore CA1051 // 参照可能なインスタンス フィールドを宣言しません

        #endregion --------------------------------------------------------------------------------------------

        #region Properties ------------------------------------------------------------------------------------

        /// <summary>
        /// ウィンドウ最小化コマンド
        /// </summary>
        public ReactiveCommand WindowMinimumCommand { get; } = new();

        /// <summary>
        /// ウィンドウのサイズ切り替えコマンド
        /// </summary>
        public ReactiveCommand WindowSizeCommand { get; } = new();

        /// <summary>
        /// ウィンドウを閉じるコマンド
        /// </summary>
        public ReactiveCommand WindowCloseCommand { get; } = new();

        /// <summary>
        /// 最大化、通常サイズのボタンデザイン指定
        /// </summary>
        public ReactivePropertySlim<string> ButtonStyle { get; } = new("1");

        #endregion --------------------------------------------------------------------------------------------

        #region Events ----------------------------------------------------------------------------------------

        /// <summary>
        /// 変更通知イベント（ReactiveProperty採用時のメモリリーク対策）
        /// </summary>
#pragma warning disable CS0067 // イベント 'MainWindowView.PropertyChanged' は使用されていません
        public event PropertyChangedEventHandler? PropertyChanged;
#pragma warning restore CS0067 // イベント 'MainWindowView.PropertyChanged' は使用されていません

        #endregion --------------------------------------------------------------------------------------------

        #region Constructor -----------------------------------------------------------------------------------

        static WindowBase()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(WindowBase), new FrameworkPropertyMetadata(typeof(WindowBase)));
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="model">モデル</param>
        public WindowBase(WindowModelBase model)
        {
            _model = model;

            this.Closing += WindowBase_Closing;
            this.StateChanged += WindowBase_StateChanged;

            WindowMinimumCommand.Subscribe(
                () =>
                {
                    this.WindowState = WindowState.Minimized;
                })
                .AddTo(_compositeDisposable);

            WindowSizeCommand.Subscribe(
                () =>
                {
                    this.WindowState =
                        this.WindowState == WindowState.Normal ?
                        WindowState.Maximized :
                        WindowState.Normal;
                }
                )
                .AddTo(_compositeDisposable);

            WindowCloseCommand.Subscribe(
                () =>
                {
                    Window.GetWindow(this).Close();
                })
                .AddTo(_compositeDisposable);
        }

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - public ------------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - internal ----------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - protected ---------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - private -----------------------------------------------------------------------------

        private void WindowBase_Closing(object? sender, System.ComponentModel.CancelEventArgs e)
        {
            _model.Dispose();
            _compositeDisposable.Dispose();
        }

        private void WindowBase_StateChanged(object? sender, EventArgs e)
        {
            ButtonStyle.Value = this.WindowState == WindowState.Normal ? "1" : "2";
        }

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - override ----------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Inner Class/Enum/etc. -------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------
    }
}

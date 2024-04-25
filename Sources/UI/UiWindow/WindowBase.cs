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
#pragma warning disable CS0067 // イベント 'MainWindowView.PropertyChanged' は使用されていません
        /// <summary>
        /// 変更通知
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;
#pragma warning restore CS0067 // イベント 'MainWindowView.PropertyChanged' は使用されていません

        private readonly WindowModelBase _model;

        /// <summary>
        /// 破棄予約リスト
        /// </summary>
#pragma warning disable CA1051 // 参照可能なインスタンス フィールドを宣言しません
#pragma warning disable SA1401 // Fields should be private
        protected readonly CompositeDisposable _compositeDisposable = [];
#pragma warning restore SA1401 // Fields should be private
#pragma warning restore CA1051 // 参照可能なインスタンス フィールドを宣言しません

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

        private void WindowBase_Closing(object? sender, System.ComponentModel.CancelEventArgs e)
        {
            _model.Dispose();
            _compositeDisposable.Dispose();
        }

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

        static WindowBase()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(WindowBase), new FrameworkPropertyMetadata(typeof(WindowBase)));
        }

        private void WindowBase_StateChanged(object? sender, EventArgs e)
        {
            ButtonStyle.Value = this.WindowState == WindowState.Normal ? "1" : "2";
        }
    }
}

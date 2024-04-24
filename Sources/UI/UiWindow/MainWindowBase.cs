using Reactive.Bindings;
using Reactive.Bindings.Extensions;

using System.ComponentModel;
using System.Reactive.Disposables;
using System.Windows;

namespace UiParts.UiWindow
{
    public abstract class MainWindowBase : Window, INotifyPropertyChanged
    {
#pragma warning disable CS0067 // イベント 'MainWindowView.PropertyChanged' は使用されていません
        public event PropertyChangedEventHandler? PropertyChanged;
#pragma warning restore CS0067 // イベント 'MainWindowView.PropertyChanged' は使用されていません

        private readonly WindowModelBase _disposableModel;

        protected readonly CompositeDisposable _compositeDisposable = [];

        public MainWindowBase(WindowModelBase disposableModel)
        {
            _disposableModel = disposableModel;

            this.Closing += WindowBase_Closing;
            this.StateChanged += WindowBase_StateChanged;

            // 最小化ボタンが押された
            WindowMinimum.Subscribe(_ => this.WindowState = WindowState.Minimized).AddTo(_compositeDisposable);
            // 最大化、通常サイズボタンが押された
            WindowSize.Subscribe(_ => this.WindowState = this.WindowState == WindowState.Normal ? WindowState.Maximized : WindowState.Normal).AddTo(_compositeDisposable);
            // 閉じるボタンが押された
            WindowClose.Subscribe(_ => Window.GetWindow(this).Close()).AddTo(_compositeDisposable);
        }

        private void WindowBase_Closing(object? sender, System.ComponentModel.CancelEventArgs e)
        {
            _disposableModel.Dispose();
            _compositeDisposable.Dispose();
        }








        // 最小化ボタンが押された時
        public ReactiveCommand WindowMinimum { get; } = new();

        // 最大化、通常サイズのボタンが押された時
        public ReactiveCommand WindowSize { get; } = new();

        // ウインドウを閉じるボタンが押された時
        public ReactiveCommand WindowClose { get; } = new();

        // 最大化、通常サイズのボタンデザイン切り替え
        public ReactivePropertySlim<string> ButtonStyle { get; } = new("1");

        static MainWindowBase()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MainWindowBase), new FrameworkPropertyMetadata(typeof(MainWindowBase)));
        }

        private void WindowBase_StateChanged(object? sender, EventArgs e)
        {
            ButtonStyle.Value = this.WindowState == WindowState.Normal ? "1" : "2";
        }
    }
}

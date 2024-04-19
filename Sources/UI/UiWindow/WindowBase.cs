using System.ComponentModel;
using System.Reactive.Disposables;
using System.Windows;

namespace UiParts.UiWindow
{
    public abstract class WindowBase : Window, INotifyPropertyChanged
    {
#pragma warning disable CS0067 // イベント 'MainWindowView.PropertyChanged' は使用されていません
        public event PropertyChangedEventHandler? PropertyChanged;
#pragma warning restore CS0067 // イベント 'MainWindowView.PropertyChanged' は使用されていません

        private readonly IDisposable _disposableModel;

        protected readonly CompositeDisposable _compositeDisposable = [];

        public WindowBase(IDisposable disposableModel)
        {
            _disposableModel = disposableModel;

            this.Closing += WindowBase_Closing;
        }

        private void WindowBase_Closing(object? sender, System.ComponentModel.CancelEventArgs e)
        {
            _disposableModel.Dispose();
            _compositeDisposable.Dispose();
        }
    }
}

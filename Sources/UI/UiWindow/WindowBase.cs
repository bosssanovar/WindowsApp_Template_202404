using System.Reactive.Disposables;
using System.Windows;

namespace UiParts.UiWindow
{
    public abstract class WindowBase : Window
    {
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

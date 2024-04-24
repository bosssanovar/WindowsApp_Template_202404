using System.Reactive.Disposables;

namespace UiParts.UiWindow
{
    public abstract class WindowModelBase : IDisposable
    {
        protected readonly CompositeDisposable _compositeDisposable = [];

        public void Dispose()
        {
            _compositeDisposable.Dispose();
        }
    }
}

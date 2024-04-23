using System.Reactive.Disposables;

namespace UiParts.UiWindow
{
    public abstract class ModelBase : IDisposable
    {
        protected readonly CompositeDisposable _compositeDisposable = [];

        public void Dispose()
        {
            _compositeDisposable.Dispose();
        }
    }
}

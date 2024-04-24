using System.Reactive.Disposables;

namespace UiParts.UserControls
{
    public abstract class PageModelBase : IDisposable
    {
        protected readonly CompositeDisposable _compositeDisposable = [];

        public abstract void UpdateEntities();

        public abstract void CommitEntities();

        public void Dispose()
        {
            _compositeDisposable.Dispose();
        }
    }
}

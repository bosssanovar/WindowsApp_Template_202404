using Reactive.Bindings;
using Reactive.Bindings.Extensions;

using System.Reactive.Disposables;

using Usecase;

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

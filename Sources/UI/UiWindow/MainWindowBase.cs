using Reactive.Bindings;
using Reactive.Bindings.Extensions;

using System.ComponentModel;
using System.Reactive.Disposables;
using System.Windows;

namespace UiParts.UiWindow
{
    public abstract class MainWindowBase : WindowBase
    {
        public MainWindowBase(WindowModelBase model)
            : base(model)
        {
        }

        static MainWindowBase()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MainWindowBase), new FrameworkPropertyMetadata(typeof(MainWindowBase)));
        }
    }
}

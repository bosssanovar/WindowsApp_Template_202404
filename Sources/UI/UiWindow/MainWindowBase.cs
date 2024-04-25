using System.Windows;

namespace UiParts.UiWindow
{
    public abstract class MainWindowBase : WindowBase
    {
#pragma warning disable IDE0290 // プライマリ コンストラクターの使用
        public MainWindowBase(WindowModelBase model)
#pragma warning restore IDE0290 // プライマリ コンストラクターの使用
            : base(model)
        {
        }

        static MainWindowBase()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MainWindowBase), new FrameworkPropertyMetadata(typeof(MainWindowBase)));
        }
    }
}

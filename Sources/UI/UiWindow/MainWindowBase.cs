using System.Windows;

namespace UiParts.UiWindow
{
    /// <summary>
    /// MainWindowのベースクラス
    /// </summary>
    public abstract class MainWindowBase : WindowBase
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="model">モデル</param>
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

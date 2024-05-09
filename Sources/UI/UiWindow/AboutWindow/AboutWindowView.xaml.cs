namespace UiParts.UiWindow.AboutWindow
{
    /// <summary>
    /// AboutWindowView.xaml の相互作用ロジック
    /// </summary>
    public partial class AboutWindowView : WindowBase
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="model">モデル</param>
        public AboutWindowView(AboutWindowModel model)
            : base(model)
        {
            AboutWindowViewModel(model);

            InitializeComponent();
        }
    }
}

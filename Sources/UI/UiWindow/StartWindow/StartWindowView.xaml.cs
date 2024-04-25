namespace UiParts.UiWindow.StartWindow
{
    /// <summary>
    /// StartWindowView.xaml の相互作用ロジック
    /// </summary>
    public partial class StartWindowView : WindowBase
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="model">モデル</param>
        public StartWindowView(StartWindowModel model)
            : base(model)
        {
            StartWindowViewModel(model);

            InitializeComponent();
        }
    }
}

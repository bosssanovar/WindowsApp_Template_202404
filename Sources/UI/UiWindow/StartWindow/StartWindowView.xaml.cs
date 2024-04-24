namespace UiParts.UiWindow.StartWindow
{
    /// <summary>
    /// StartWindowView.xaml の相互作用ロジック
    /// </summary>
    public partial class StartWindowView : WindowBase
    {
        public StartWindowView(StartWindowModel model)
            : base(model)
        {
            StartWindowViewModel(model);

            InitializeComponent();
        }
    }
}

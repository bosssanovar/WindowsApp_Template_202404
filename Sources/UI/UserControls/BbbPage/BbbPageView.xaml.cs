namespace UiParts.UserControls.BbbPage
{
    /// <summary>
    /// AaaAndBbbPageView.xaml の相互作用ロジック
    /// </summary>
    public partial class BbbPageView : PageViewBase
    {
        public BbbPageView(BbbPageModel model)
            : base(model)
        {
            BbbPageViewModel(model);

            InitializeComponent();
        }
    }
}

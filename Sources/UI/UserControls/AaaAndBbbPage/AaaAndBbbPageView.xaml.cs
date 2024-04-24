namespace UiParts.UserControls.AaaAndBbbPage
{
    /// <summary>
    /// AaaAndBbbPageView.xaml の相互作用ロジック
    /// </summary>
    public partial class AaaAndBbbPageView : PageViewBase
    {
        public AaaAndBbbPageView(AaaAndBbbPageModel model)
            : base(model)
        {
            AaaAndBbbPageViewModel(model);

            InitializeComponent();
        }
    }
}

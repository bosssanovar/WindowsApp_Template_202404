namespace UiParts.UserControls.AaaPage
{
    /// <summary>
    /// AaaAndBbbPageView.xaml の相互作用ロジック
    /// </summary>
    public partial class AaaPageView : PageViewBase
    {
        public AaaPageView(AaaPageModel model)
            : base(model)
        {
            AaaPageViewModel(model);

            InitializeComponent();
        }
    }
}

namespace UiParts.Page.AaaPage
{
    /// <summary>
    /// AaaAndBbbPageView.xaml の相互作用ロジック
    /// </summary>
    public partial class AaaPageView : PageViewBase
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="model">モデル</param>
        public AaaPageView(AaaPageModel model)
            : base(model)
        {
            AaaPageViewModel(model);

            InitializeComponent();
        }
    }
}

namespace UiParts.Page.AaaAndBbbPage
{
    /// <summary>
    /// AaaAndBbbPageView.xaml の相互作用ロジック
    /// </summary>
    public partial class AaaAndBbbPageView : PageViewBase
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="model">モデル</param>
        public AaaAndBbbPageView(AaaAndBbbPageModel model)
            : base(model)
        {
            AaaAndBbbPageViewModel(model);

            InitializeComponent();
        }
    }
}

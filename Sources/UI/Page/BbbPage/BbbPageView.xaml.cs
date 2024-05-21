namespace UiParts.Page.BbbPage
{
    /// <summary>
    /// AaaAndBbbPageView.xaml の相互作用ロジック
    /// </summary>
    public partial class BbbPageView : PageViewBase
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="model">モデル</param>
        public BbbPageView(BbbPageModel model)
            : base(model)
        {
            BbbPageViewModel(model);

            InitializeComponent();
        }
    }
}

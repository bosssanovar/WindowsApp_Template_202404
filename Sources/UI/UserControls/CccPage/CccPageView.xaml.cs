namespace UiParts.UserControls.CccPage
{
    /// <summary>
    /// CccPageView.xaml の相互作用ロジック
    /// </summary>
    public partial class CccPageView : PageViewBase
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="model">モデル</param>
        public CccPageView(CccPageModel model)
            : base(model)
        {
            CccPageViewModel(model);

            InitializeComponent();
        }
    }
}

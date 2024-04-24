namespace UiParts.UiWindow.MainWindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindowView : WindowBase
    {

        public MainWindowView(MainWindowModel model)
            : base(model)
        {
            MainWindowViewModel(model);

            InitializeComponent();
        }
    }
}
using System.Windows;
using System.Windows.Media.Animation;

using UiParts.UiWindow.AboutWindow;

using WpfLib;

namespace UiParts.UiWindow.MainWindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindowView : MainWindowBase, IBlur
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="model">モデル</param>
        public MainWindowView(MainWindowModel model)
            : base(model)
        {
            MainWindowViewModel(model);

            InitializeComponent();
        }

        /// <inheritdoc/>
        public void BlurOff()
        {
            var sb = blurBorder.FindResource("CloseAnimation") as Storyboard;
            if (sb is not null)
            {
                sb.Completed += (sender, e) =>
                {
                    blurBorder.Visibility = Visibility.Collapsed;
                    IsBlur.Value = false;
                };

                sb.Begin();
            }
            else
            {
                IsBlur.Value = false;
                blurBorder.Visibility = Visibility.Collapsed;
            }
        }

        /// <inheritdoc/>
        public void BlurOn()
        {
            blurBorder.Visibility = Visibility.Visible;

            var sb = blurBorder.FindResource("OpenAnimation") as Storyboard;
            if (sb is not null)
            {
                sb.Completed += (sender, e) =>
                {
                    blurBorder.Visibility = Visibility.Visible;
                    IsBlur.Value = true;
                };

                sb.Begin();
            }
            else
            {
                IsBlur.Value = true;
            }
        }

        private void PopupOnBlur(Action popupAction)
        {
            var blur = this as IBlur;
            blur?.BlurOn();

            WpfDoEvents.Execute();

            popupAction();

            blur?.BlurOff();
        }
    }
}
using Reactive.Bindings;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace UiParts.UserControls.HamburgerMenu
{
    /// <summary>
    /// HamburgerMenu.xaml の相互作用ロジック
    /// </summary>
    public partial class HamburgerMenu : UserControl
    {
        #region Constants -------------------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Fields ----------------------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Properties ------------------------------------------------------------------------------------

        #region 公開依存プロパティ

        #region Page AAA

        /// <summary>
        /// AAAページを表示するコマンドプロパティ
        /// </summary>
        public static readonly DependencyProperty ShowPageAaaCommandProperty =
            DependencyProperty.Register(nameof(ShowPageAaaCommand), typeof(ICommand), typeof(HamburgerMenu));

        /// <summary>
        /// AAAページを表示するコマンド
        /// </summary>
        public ICommand ShowPageAaaCommand
        {
            get { return (ICommand)GetValue(ShowPageAaaCommandProperty); }
            set { SetValue(ShowPageAaaCommandProperty, value); }
        }

        #endregion

        #region Page BBB

        /// <summary>
        /// BBBページを表示するコマンドプロパティ
        /// </summary>
        public static readonly DependencyProperty ShowPageBbbCommandProperty =
            DependencyProperty.Register(nameof(ShowPageBbbCommand), typeof(ICommand), typeof(HamburgerMenu));

        /// <summary>
        /// BBBページを表示するコマンド
        /// </summary>
        public ICommand ShowPageBbbCommand
        {
            get { return (ICommand)GetValue(ShowPageBbbCommandProperty); }
            set { SetValue(ShowPageBbbCommandProperty, value); }
        }

        #endregion

        #region Page AAA and BBB

        /// <summary>
        /// aaa and BBBページを表示するコマンドプロパティ
        /// </summary>
        public static readonly DependencyProperty ShowPageAaaAndBbbCommandProperty =
            DependencyProperty.Register(nameof(ShowPageAaaAndBbbCommand), typeof(ICommand), typeof(HamburgerMenu));

        /// <summary>
        /// Aaa and BBBページを表示するコマンド
        /// </summary>
        public ICommand ShowPageAaaAndBbbCommand
        {
            get { return (ICommand)GetValue(ShowPageAaaAndBbbCommandProperty); }
            set { SetValue(ShowPageAaaAndBbbCommandProperty, value); }
        }

        #endregion

        #region Page CCC

        /// <summary>
        /// CCCページを表示するコマンドプロパティ
        /// </summary>
        public static readonly DependencyProperty ShowPageCccCommandProperty =
            DependencyProperty.Register(nameof(ShowPageCccCommand), typeof(ICommand), typeof(HamburgerMenu));

        /// <summary>
        /// Cccページを表示するコマンド
        /// </summary>
        public ICommand ShowPageCccCommand
        {
            get { return (ICommand)GetValue(ShowPageCccCommandProperty); }
            set { SetValue(ShowPageCccCommandProperty, value); }
        }

        #endregion

        #endregion

        /// <summary>
        /// AAAページを表示するコマンド
        /// </summary>
        public ReactiveCommand ShowPageAaaCommandInner { get; } = new();

        /// <summary>
        /// BBBページを表示するコマンド
        /// </summary>
        public ReactiveCommand ShowPageBbbCommandInner { get; } = new();

        /// <summary>
        /// Aaa and BBBページを表示するコマンド
        /// </summary>
        public ReactiveCommand ShowPageAaaAndBbbCommandInner { get; } = new();

        /// <summary>
        /// CCCページを表示するコマンド
        /// </summary>
        public ReactiveCommand ShowPageCccCommandInner { get; } = new();

        #endregion --------------------------------------------------------------------------------------------

        #region Events ----------------------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Constructor -----------------------------------------------------------------------------------

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public HamburgerMenu()
        {
            ShowPageAaaCommandInner.Subscribe(
                () =>
                {
                    Close(
                        () =>
                        {
                            ShowPageAaaCommand.Execute(null);
                        });
                });

            ShowPageBbbCommandInner.Subscribe(
                () =>
                {
                    Close(
                        () =>
                        {
                            ShowPageBbbCommand.Execute(null);
                        });
                });

            ShowPageAaaAndBbbCommandInner.Subscribe(
                () =>
                {
                    Close(
                        () =>
                        {
                            ShowPageAaaAndBbbCommand.Execute(null);
                        });
                });

            ShowPageCccCommandInner.Subscribe(
                () =>
                {
                    Close(
                        () =>
                        {
                            ShowPageCccCommand.Execute(null);
                        });
                });

            InitializeComponent();
        }

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - public ------------------------------------------------------------------------------

        /// <summary>
        /// ハンバーガーメニューを開きます。
        /// </summary>
        public void Open()
        {
            Visibility = Visibility.Visible;

            var sb = FindResource("OpenAnimation") as Storyboard;
            if (sb is not null)
            {
                sb.Completed += (sender, e) =>
                {
                    aaaButton.Focus();
                };

                sb.Begin();
            }
        }

        /// <summary>
        /// ハンバーガーメニューを閉じます
        /// </summary>
        /// <param name="onCompleted">メニューClose完了後アクション</param>
        public void Close(Action? onCompleted = null)
        {
            var sb = FindResource("CloseAnimation") as Storyboard;
            if (sb is not null)
            {
                sb.Completed += (sender, e) =>
                {
                    Visibility = Visibility.Collapsed;

                    onCompleted?.Invoke();
                };

                sb.Begin();
            }
            else
            {
                Visibility = Visibility.Collapsed;
            }
        }

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - internal ----------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - protected ---------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - private -----------------------------------------------------------------------------

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void Grid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Close();
            }
        }

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - override ----------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Inner Class/Enum/etc. -------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------
    }
}

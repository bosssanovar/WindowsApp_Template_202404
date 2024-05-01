using Reactive.Bindings;
using Reactive.Bindings.Extensions;

using System.Windows;

using UiParts.UiWindow.StartWindow;
using UiParts.UserControls;
using UiParts.UserControls.AaaAndBbbPage;
using UiParts.UserControls.AaaPage;
using UiParts.UserControls.BbbPage;
using UiParts.UserControls.CccPage;

namespace UiParts.UiWindow.MainWindow
{
    /// <summary>
    /// MainWindowの疑似ViewModel
    /// </summary>
    public partial class MainWindowView
    {
        #region Constants -------------------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Fields ----------------------------------------------------------------------------------------

        private MainWindowModel? _model;

        #endregion --------------------------------------------------------------------------------------------

        #region Properties ------------------------------------------------------------------------------------

        /// <summary>
        /// Pageコンテンツ
        /// </summary>
        public ReactivePropertySlim<PageViewBase?> Page { get; } = new();

        /// <summary>
        /// スクロール対応Pageコンテンツ
        /// </summary>
        public ReactivePropertySlim<PageViewBase?> ScrollablePage { get; } = new();

        /// <summary>
        /// Homeに異動するコマンド
        /// </summary>
        public ReactiveCommand MoveHomeCommand { get; } = new();

        /// <summary>
        /// 設定値を初期化するコマンド
        /// </summary>
        public ReactiveCommand InitializeCommand { get; } = new();

        /// <summary>
        /// 設定をファイルに保存するコマンド
        /// </summary>
        public ReactiveCommand SaveCommand { get; } = new();

        /// <summary>
        /// 設定をファイルから読み込むコマンド
        /// </summary>
        public ReactiveCommand OpenCommand { get; } = new();

        /// <summary>
        /// Aaaページに遷移するコマンド
        /// </summary>
        public ReactiveCommand PageAaaCommand { get; } = new();

        /// <summary>
        /// Bbbページに遷移するコマンド
        /// </summary>
        public ReactiveCommand PageBbbCommand { get; } = new();

        /// <summary>
        /// Aaa and Bbbページに遷移するコマンド
        /// </summary>
        public ReactiveCommand PageAaaAndBbbCommand { get; } = new();

        /// <summary>
        /// Cccページに遷移するコマンド
        /// </summary>
        public ReactiveCommand PageCccCommand { get; } = new();

        #endregion --------------------------------------------------------------------------------------------

        #region Events ----------------------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Constructor -----------------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - public ------------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - internal ----------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - protected ---------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - private -----------------------------------------------------------------------------

        private void MainWindowViewModel(MainWindowModel model)
        {
            _model = model;

            Page.Value = GlobalServiceProvider.GetRequiredService<AaaPageView>();

            MoveHomeCommand.Subscribe(() =>
            {
                var homeWindow = GlobalServiceProvider.GetRequiredService<StartWindowView>();
                homeWindow.Show();

                Close();
            });

            InitializeCommand.Subscribe(() =>
            {
                if (MessageBox.Show(
                            "初期化を実行しますか？",
                            "確認",
                            MessageBoxButton.YesNo,
                            MessageBoxImage.Question,
                            MessageBoxResult.No) == MessageBoxResult.Yes)
                {
                    _model.Initialize();

                    Page.Value?.Update();
                    ScrollablePage.Value?.Update();
                }
            })
                .AddTo(_compositeDisposable);

            SaveCommand.Subscribe(() =>
            {
                Page.Value?.Commit();
                ScrollablePage.Value?.Commit();

                var result = _model.SaveDataFile();

                if (result)
                {
                    MessageBox.Show("データを保存しました。", "情報");
                }
            })
                .AddTo(_compositeDisposable);

            OpenCommand.Subscribe(() =>
            {
                var result = _model.OpenDataFile();

                switch (result)
                {
                    case Usecase.OpenDataUsecase.OpenResult.Completed:
                        Page.Value?.Update();
                        ScrollablePage.Value?.Update();
                        MessageBox.Show("データを開きました。", "情報");
                        break;
                    case Usecase.OpenDataUsecase.OpenResult.Canceled:
                        MessageBox.Show("キャンセルしました。", "情報");
                        break;
                    case Usecase.OpenDataUsecase.OpenResult.Error_InvalidData:
                        MessageBox.Show(
                            "データが不正のため、処理を中断しました。",
                            "情報",
                            MessageBoxButton.OK,
                            MessageBoxImage.Error);
                        break;
                }
            })
                .AddTo(_compositeDisposable);

            PageAaaCommand.Subscribe(() =>
            {
                SetPage(GlobalServiceProvider.GetRequiredService<AaaPageView>());
            });

            PageBbbCommand.Subscribe(() =>
            {
                SetPage(GlobalServiceProvider.GetRequiredService<BbbPageView>());
            });

            PageAaaAndBbbCommand.Subscribe(() =>
            {
                SetPage(GlobalServiceProvider.GetRequiredService<AaaAndBbbPageView>());
            });

            PageCccCommand.Subscribe(() =>
            {
                SetScrollablePage(GlobalServiceProvider.GetRequiredService<CccPageView>());
            });
        }

        private void SetPage(PageViewBase page)
        {
            InitPageContent();
            Page.Value = page;
        }

        private void SetScrollablePage(PageViewBase page)
        {
            InitPageContent();
            ScrollablePage.Value = page;
        }

        private void InitPageContent()
        {
            Page.Value = null;
            ScrollablePage.Value = null;
        }

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - override ----------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Inner Class/Enum/etc. -------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------
    }
}

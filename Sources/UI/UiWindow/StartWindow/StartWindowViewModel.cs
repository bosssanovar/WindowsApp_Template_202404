using Reactive.Bindings;

using System.Windows;

using UiParts.UiWindow.MainWindow;

namespace UiParts.UiWindow.StartWindow
{
    /// <summary>
    /// Home画面の疑似ViewModelクラス
    /// </summary>
    public partial class StartWindowView
    {
        #region Constants -------------------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Fields ----------------------------------------------------------------------------------------

        private StartWindowModel? _model;

        #endregion --------------------------------------------------------------------------------------------

        #region Properties ------------------------------------------------------------------------------------

        /// <summary>
        /// 新規作成コマンド
        /// </summary>
        public ReactiveCommand NewCommand { get; } = new();

        /// <summary>
        /// ファイル開くコマンド
        /// </summary>
        public ReactiveCommand OpenCommand { get; } = new();

        /// <summary>
        /// ダウンロードコマンド
        /// </summary>
        public ReactiveCommand DownloadCommand { get; } = new();

        #endregion --------------------------------------------------------------------------------------------

        #region Events ----------------------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Constructor -----------------------------------------------------------------------------------

        private void StartWindowViewModel(StartWindowModel model)
        {
            _model = model;

            NewCommand.Subscribe(() =>
            {
                var mainWindow = GlobalServiceProvider.GetRequiredService<MainWindowView>();
                Application.Current.MainWindow = mainWindow;
                mainWindow.Show();

                this.Close();
            });
        }

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - public ------------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - internal ----------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - protected ---------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - private -----------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - override ----------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------
    }
}

using Reactive.Bindings;

using System.Windows;

using UiParts.UiWindow.MainWindow;

namespace UiParts.UiWindow.AboutWindow
{
    /// <summary>
    /// AboutWindowの疑似ViewModelクラス
    /// </summary>
    public partial class AboutWindowView
    {
        #region Constants -------------------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Fields ----------------------------------------------------------------------------------------

#pragma warning disable IDE0052 // 読み取られていないプライベート メンバーを削除
        private AboutWindowModel? _model;
#pragma warning restore IDE0052 // 読み取られていないプライベート メンバーを削除

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

        private void AboutWindowViewModel(AboutWindowModel model)
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

﻿using Reactive.Bindings;

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

#pragma warning disable IDE0052 // 読み取られていないプライベート メンバーを削除
        private StartWindowModel? _model;
#pragma warning restore IDE0052 // 読み取られていないプライベート メンバーを削除

        #endregion --------------------------------------------------------------------------------------------

        #region Properties ------------------------------------------------------------------------------------

        /// <summary>
        /// 新規作成コマンド
        /// </summary>
        public ReactiveCommand StartCommand { get; } = new();

        /// <summary>
        /// 簡単新規作成コマンド
        /// </summary>
        public ReactiveCommand EasyStartCommand { get; } = new();

        #endregion --------------------------------------------------------------------------------------------

        #region Events ----------------------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Constructor -----------------------------------------------------------------------------------

        private void StartWindowViewModel(StartWindowModel model)
        {
            _model = model;

            StartCommand.Subscribe(() =>
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

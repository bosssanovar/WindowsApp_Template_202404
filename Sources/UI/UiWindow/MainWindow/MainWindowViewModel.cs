﻿using Microsoft.Win32;

using Reactive.Bindings;
using Reactive.Bindings.Extensions;

using System.Windows;

using UiParts.Page;
using UiParts.Page.AaaAndBbbPage;
using UiParts.Page.AaaPage;
using UiParts.Page.BbbPage;
using UiParts.Page.CccPage;
using UiParts.UiWindow.AboutWindow;
using UiParts.UiWindow.Message;
using UiParts.UiWindow.StartWindow;

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

        /// <summary>
        /// Blur On/Off
        /// </summary>
        public ReactivePropertySlim<bool> IsBlur { get; } = new(false);

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

            OpenHamburgerMenuCommand.Subscribe(() =>
            {
                if (hamburgerMenu.Visibility is Visibility.Collapsed)
                {
                    hamburgerMenu.Open(() =>
                    {
                        IsBlur.Value = false;
                    });
                    IsBlur.Value = true;
                }
                else
                {
                    hamburgerMenu.Close();
                }
            });

            MoveHomeCommand.Subscribe(() =>
            {
                var homeWindow = GlobalServiceProvider.GetRequiredService<StartWindowView>();
                homeWindow.Show();

                Close();
            });

            InitializeCommand.Subscribe(() =>
            {
                if (MessageWindow.Show(
                            "初期化を実行しますか？",
                            "確認",
                            MessageBoxButton.YesNo,
                            MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    _model.Initialize();

                    Page.Value?.Update();
                    ScrollablePage.Value?.Update();

                    MessageWindow.Show("初期化が完了しました。", "情報");
                }
            })
                .AddTo(_compositeDisposable);

            SaveCommand.Subscribe(() =>
            {
                Page.Value?.Commit();
                ScrollablePage.Value?.Commit();

                bool result = true;

                PopupOnBlur(
                    () =>
                    {
                        SaveFileDialog sfd = new()
                        {
                            Filter = "Data file (*.dat)|*.dat",
                        };
                        if (sfd.ShowDialog() == false)
                        {
                            result = false;
                            return;
                        }

                        result = _model.SaveDataFile(sfd.FileName);
                    });

                if (result)
                {
                    MessageWindow.Show("データを保存しました。", "情報");
                }
            })
                .AddTo(_compositeDisposable);

            OpenCommand.Subscribe(() =>
            {
                Usecase.OpenDataUsecase.OpenResult result = Usecase.OpenDataUsecase.OpenResult.Completed;

                PopupOnBlur(
                    () =>
                    {
                        OpenFileDialog openFileDialog = new()
                        {
                            Filter = "Data file (*.dat)|*.dat",
                        };
                        if (openFileDialog.ShowDialog() == false)
                        {
                            result = Usecase.OpenDataUsecase.OpenResult.Canceled;
                            return;
                        }

                        result = _model.OpenDataFile(openFileDialog.FileName);
                    });

                switch (result)
                {
                    case Usecase.OpenDataUsecase.OpenResult.Completed:
                        Page.Value?.Update();
                        ScrollablePage.Value?.Update();
                        MessageWindow.Show("データを開きました。", "情報");
                        break;
                    case Usecase.OpenDataUsecase.OpenResult.Canceled:
                        MessageWindow.Show("キャンセルしました。", "情報");
                        break;
                    case Usecase.OpenDataUsecase.OpenResult.Error_InvalidData:
                        MessageWindow.Show(
                            "データが不正のため、処理を中断しました。",
                            "情報",
                            MessageBoxButton.OK,
                            MessageBoxImage.Error);
                        break;
                }
            })
                .AddTo(_compositeDisposable);

            AboutCommand.Subscribe(() =>
            {
                var about = GlobalServiceProvider.GetRequiredService<AboutWindowView>();
                about.Owner = this;

                PopupOnBlur(
                    () =>
                    {
                        about.ShowDialog();
                    });
            })
                .AddTo(_compositeDisposable);

            PageAaaCommand.Subscribe(() =>
            {
                SetPage<AaaPageView>();
            });

            PageBbbCommand.Subscribe(() =>
            {
                SetPage<BbbPageView>();
            });

            PageAaaAndBbbCommand.Subscribe(() =>
            {
                SetPage<AaaAndBbbPageView>();
            });

            PageCccCommand.Subscribe(() =>
            {
                SetScrollablePage<CccPageView>();
            });
        }

        private void SetPage<T>()
            where T : PageViewBase
        {
            InitPageContent();

            var page = GlobalServiceProvider.GetRequiredService<T>();
            Page.Value = page;
        }

        private void SetScrollablePage<T>()
            where T : PageViewBase
        {
            InitPageContent();

            var page = GlobalServiceProvider.GetRequiredService<T>();
            ScrollablePage.Value = page;
        }

        private void InitPageContent()
        {
            Page.Value?.Commit();
            Page.Value = null;

            ScrollablePage.Value?.Commit();
            ScrollablePage.Value = null;
        }

        #endregion --------------------------------------------------------------------------------------------

        #region Methods - override ----------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------

        #region Inner Class/Enum/etc. -------------------------------------------------------------------------

        #endregion --------------------------------------------------------------------------------------------
    }
}

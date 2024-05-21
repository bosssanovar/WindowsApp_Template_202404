using Feature.DataFile;

using InMemoryRepository;

using Microsoft.Extensions.DependencyInjection;

using Repository;

using System.Windows;

using UiParts;
using UiParts.Page.AaaAndBbbPage;
using UiParts.Page.AaaPage;
using UiParts.Page.BbbPage;
using UiParts.Page.CccPage;
using UiParts.UiWindow.AboutWindow;
using UiParts.UiWindow.MainWindow;
using UiParts.UiWindow.StartWindow;

using Usecase;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// 起動時イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            CreateDiServiceProvider();

            var mainWindow = GlobalServiceProvider.GetRequiredService<StartWindowView>();

            mainWindow.Show();
        }

        private static void CreateDiServiceProvider()
        {
            var services = new ServiceCollection();
            services.AddSingleton<IAaaRepository, AaaRepository>();
            services.AddSingleton<IBbbRepository, BbbRepository>();
            services.AddSingleton<ICccRepository, CccRepository>();

            services.AddTransient<Feature.DataFile.DataFileAccessor>();

            services.AddTransient<IDataFileAccessor, FileAccessor.DataFileAccessor>();

            services.AddTransient<DisplaySettingsUsecase>();
            services.AddTransient<InitializeUsecase>();
            services.AddTransient<SaveDataUsecase>();
            services.AddTransient<OpenDataUsecase>();
            services.AddTransient<CommitSettingsUsecase>();

            services.AddTransient<MainWindowModel>();
            services.AddTransient<MainWindowView>();
            services.AddTransient<StartWindowModel>();
            services.AddTransient<StartWindowView>();
            services.AddTransient<AboutWindowModel>();
            services.AddTransient<AboutWindowView>();

            services.AddTransient<AaaPageModel>();
            services.AddTransient<AaaPageView>();
            services.AddTransient<BbbPageModel>();
            services.AddTransient<BbbPageView>();
            services.AddTransient<AaaAndBbbPageModel>();
            services.AddTransient<AaaAndBbbPageView>();
            services.AddTransient<CccPageModel>();
            services.AddTransient<CccPageView>();

            GlobalServiceProvider.SetProvider(services.BuildServiceProvider());
        }

        /// <summary>
        /// 通常終了時イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Application_Exit(object sender, ExitEventArgs e)
        {

        }

        /// <summary>
        /// 予期しない例外がスローされたときなどの、異常な条件下でのシャットダウン時イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {

        }

        /// <summary>
        /// ログオフ、シャット ダウン、再起動、休止のWindows セッションの終了時イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Application_SessionEnding(object sender, SessionEndingCancelEventArgs e)
        {

        }
    }

}

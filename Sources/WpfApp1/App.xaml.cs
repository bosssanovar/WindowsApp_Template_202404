using Feature.DataFile;

using InMemoryRepository;

using Microsoft.Extensions.DependencyInjection;

using Repository;

using System.Windows;

using UiParts;
using UiParts.UiWindow.AboutWindow;
using UiParts.UiWindow.MainWindow;
using UiParts.UiWindow.StartWindow;
using UiParts.UserControls.AaaAndBbbPage;
using UiParts.UserControls.AaaPage;
using UiParts.UserControls.BbbPage;
using UiParts.UserControls.CccPage;

using Usecase;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            CreateDependencyInjectionProvider();

            var mainWindow = GlobalServiceProvider.GetRequiredService<StartWindowView>();

            mainWindow.Show();
        }

        private static void CreateDependencyInjectionProvider()
        {
            var services = new ServiceCollection();
            services.AddSingleton<IAAARepository, AAARepository>();
            services.AddSingleton<IBBBRepository, BBBRepository>();
            services.AddSingleton<ICCCRepository, CCCRepository>();

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
    }

}

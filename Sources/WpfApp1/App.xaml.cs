using Feature.DataFile;

using InMemoryRepository;

using Microsoft.Extensions.DependencyInjection;

using Repository;

using System.Windows;

using UiParts;
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

            services.AddTransient<Feature.DataFile.DataFileAccessor>();

            services.AddTransient<IDataFileAccessor, FileAccessor.DataFileAccessor>();

            services.AddTransient<DisplaySettingsUsecase>();
            services.AddTransient<InitializeUsecase>();
            services.AddTransient<SaveDataUsecase>();
            services.AddTransient<OpenDataUsecase>();
            services.AddTransient<CommitSettingsUsecase>();

            services.AddTransient<Model>();
            services.AddTransient<MainWindowView>();
            services.AddTransient<StartWindowModel>();
            services.AddTransient<StartWindowView>();

            GlobalServiceProvider.SetProvider(services.BuildServiceProvider());
        }
    }

}

using Microsoft.Extensions.DependencyInjection;
using Navigation_Dictionary.Services;
using Navigation_Dictionary.ViewModels;
using Navigation_Dictionary.Views;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Navigation_Dictionary
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary> 
    public partial class App : Application
    {
        public static new App Current = (App)Application.Current;
        public readonly IServiceProvider Services;
        public App()
        {
            var container = new ServiceCollection();

            //container.AddSingleton<Frame>(new Frame());

            // 注册Frame的单例，方便使用。
            container.AddSingleton<Frame>( _ 
                 => new Frame { NavigationUIVisibility = NavigationUIVisibility.Hidden}); 

            container.AddSingleton<MainView>();
            container.AddSingleton<MainViewModel>();
            container.AddSingleton<LoginView>();
            container.AddSingleton<LoginViewModel>(); 
            container.AddSingleton<HomeView>();
            container.AddSingleton<HomeViewModel>();
            container.AddSingleton<Services.NavigationService>();

            Services = container.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            MainWindow = Services.GetService<MainView>();
            MainWindow!.Show();
        }

        //override
    }

}

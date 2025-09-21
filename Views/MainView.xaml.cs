using Navigation_Dictionary.Services;
using Navigation_Dictionary.ViewModels;
using System.Windows;
//using System.Windows.Navigation;

namespace Navigation_Dictionary.Views
{
    /// <summary>
    /// MainView.xaml 的交互逻辑
    /// </summary>
    public partial class MainView : Window
    {
        public MainView(MainViewModel mainViewModel, 
            NavigationService navigationService,
            System.Windows.Controls.Frame frame)
        {
            InitializeComponent();
            this.DataContext = mainViewModel;
            //navigationService.SetMainFrame(this.MainFrame);
            //Action test = mainViewModel.OnLoadedCommand;
            this.AddChild(frame);
        }
    }
}

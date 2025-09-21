using CommunityToolkit.Mvvm.Input;
using Navigation_Dictionary.Services;

namespace Navigation_Dictionary.ViewModels
{
    public partial class MainViewModel : ViewModelBase
    {
        public NavigationService navigator;

        public MainViewModel(NavigationService navigator)
        {
            this.navigator = navigator;
        }

        /// <summary>
        /// 这个也太坑了吧，写的是OnLoaded，结果需要Binding的命令是LoadedCommand而不是OnLoadedCommand？
        /// </summary>
        [RelayCommand]
        void OnLoaded()
        {
            navigator.Navigate<LoginViewModel>();
        }
    }
}

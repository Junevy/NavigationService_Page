using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Navigation_Dictionary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navigation_Dictionary.ViewModels
{
    public partial class LoginViewModel : ViewModelBase
    {
        [ObservableProperty]
        private string message = "hello world";
        private readonly NavigationService navigationService;

        [ObservableProperty]
        private string userName;
        [ObservableProperty]
        private string password;

        public LoginViewModel(NavigationService navigationService)
        {
            this.navigationService = navigationService;
        }

        [RelayCommand]
        void Login()
        {
            navigationService.Navigate<HomeViewModel>(new Dictionary<string, object?>
            {
                [nameof(HomeViewModel.UserName)] = UserName,
                [nameof(HomeViewModel.Password)] = Password,
                // 属性必须有Set方法
                //[nameof(HomeViewModel.Message)] = "Hello"
            });
        }
    }
}

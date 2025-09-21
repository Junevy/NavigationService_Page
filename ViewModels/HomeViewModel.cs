using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navigation_Dictionary.ViewModels
{
    public partial class HomeViewModel : ViewModelBase
    {

        [ObservableProperty]
        private string userName;
        [ObservableProperty]
        private string password;

        //[obser]
        public string Message => $"Halo {UserName} and user password : {Password} ";

    }
}

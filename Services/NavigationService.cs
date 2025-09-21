using Navigation_Dictionary.ViewModels;
using Navigation_Dictionary.Views;
using System.Windows.Controls;

namespace Navigation_Dictionary.Services
{
    public class NavigationService
    {
        private Frame? mainFrame;

        /// <summary>
        /// 程序运行时注入mainFrame，再通过手动AddChild的方法添加到 MainView 中。
        /// </summary>
        /// <param name="frame">承载所有Page的Frame</param>
        public NavigationService(Frame frame)
        {
            this.mainFrame = frame;
        }

        private readonly Dictionary<Type, Type> mapping = new()
        {
            [typeof(LoginViewModel)] = typeof(LoginView),
        };

        public void Navigate<T>() where T : ViewModelBase
        {
            if (!mapping.TryGetValue(typeof(T), out Type? view))
                return;
            var page = App.Current.Services.GetService(view) as Page;
            mainFrame?.Navigate(page);
        }

        //public void SetMainFrame(Frame frame) => mainFrame = frame;

    }
}

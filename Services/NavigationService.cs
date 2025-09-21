using Navigation_Dictionary.ViewModels;
using Navigation_Dictionary.Views;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

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
            this.mainFrame.LoadCompleted += MainFrameLoaded;
        }

        /// <summary>
        /// 当 LoadComplete，该mainFrame的C Content已变化为新的Page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">Navigate时传递的参数</param>
        private void MainFrameLoaded(object sender, NavigationEventArgs e)
        {
            if (e.ExtraData is not Dictionary<string, object> extraData || e.ExtraData is null)
                return;

            if ((mainFrame?.Content as FrameworkElement)?.DataContext is not ViewModelBase viewModel)
                return;

            // 反射获取导航到页面的viewModel，并获取ViewModel中的Property
            // 如果和extraData中的Key有相同名称的属性，则将value赋值给这个Property
            // 属性必须有Set方法，否则 ArgumentException：Property Set method not found.
            foreach (var item in extraData) 
            { 
                viewModel.GetType().GetProperty(item.Key)?.SetValue(viewModel, item.Value);
            }
        }

        /// <summary>
        /// 维护字典，用于导航
        /// </summary>
        private readonly Dictionary<Type, Type> mapping = new()
        {
            [typeof(LoginViewModel)] = typeof(LoginView),
            [typeof(HomeViewModel)] = typeof(HomeView),
        };

        public void Navigate<T>(Dictionary<string, object?>? extraData = null) 
            where T : ViewModelBase
        {
            if (!mapping.TryGetValue(typeof(T), out Type? view))
                return;
            var page = App.Current.Services.GetService(view) as Page;
            mainFrame?.Navigate(page, extraData);
        }

        //public void SetMainFrame(Frame frame) => mainFrame = frame;

    }
}

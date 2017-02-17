using Microsoft.Practices.Unity;
using System.Windows;

namespace WpfMvvmUnityDi
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            var container = DiContainer.DIContainer.Container;
            this.DataContext = container.Resolve<ViewModels.MainViewModel>();

            InitializeComponent();
        }
    }
}

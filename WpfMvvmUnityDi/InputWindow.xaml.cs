using Microsoft.Practices.Unity;
using System.Windows;

namespace WpfMvvmUnityDi
{
    /// <summary>
    /// InputWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class InputWindow : Window
    {
        public InputWindow()
        {
            var container = DiContainer.DIContainer.Container;
            this.DataContext = container.Resolve<ViewModels.InputViewModel>();

            InitializeComponent();
        }
    }
}

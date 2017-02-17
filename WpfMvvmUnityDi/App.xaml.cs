using System.Windows;

namespace WpfMvvmUnityDi
{
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : Application
    {
        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            // ハンドリングできていない例外の発生を表示/記録する場合は、ここに記述する。
            MessageBox.Show("例外が発生したので終了します。", "例外が発生", MessageBoxButton.OK, MessageBoxImage.Stop);

            // アプリケーションを終了させる。
            e.Handled = true;
            Shutdown();
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            System.Diagnostics.Trace.WriteLine("DIContainer instance: Dispose!");
            DiContainer.DIContainer.Container.Dispose();
        }
    }
}

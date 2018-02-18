using System.Windows;

namespace MaxBootstrap.Core.View.MainWindow
{
    public interface IBootstrapperMainWindowViewmodel
    {
        IBootstrapperController BootstrapperController { get; }

        FrameworkElement CurrentView { get; }
    }
}

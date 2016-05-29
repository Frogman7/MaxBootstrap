using System.Windows;

namespace MaxBootstrap.Core.View
{
    public interface IBootstrapperMainWindowViewmodel
    {
        IBootstrapperController BootstrapperController { get; }

        FrameworkElement CurrentPage { get; }
    }
}

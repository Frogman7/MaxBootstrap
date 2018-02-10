using System.Windows;
using MaxBootstrap.Core.Pages;

namespace MaxBootstrap.Core.View
{
    public class BootstrapperMainWindowViewmodel : ObservableBase, IBootstrapperMainWindowViewmodel
    {
        public IBootstrapperController BootstrapperController { get; protected set; }

        public BootstrapperMainWindowViewmodel(IBootstrapperController bootstrapperController)
        {
            this.BootstrapperController = bootstrapperController;

            BootstrapperController.ViewController.ViewChange += (view) => 
            {
                this.NotifyPropertyChanged(nameof(CurrentView));
            };
        }

        public FrameworkElement CurrentView
        {
            get
            {
                return this.BootstrapperController.ViewController.CurrentView as FrameworkElement;
            }
        }
    }
}

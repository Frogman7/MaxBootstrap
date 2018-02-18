using System.Windows;

namespace MaxBootstrap.Core.View.MainWindow
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

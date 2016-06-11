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

            ((PageController) BootstrapperController.PageController).PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName.Equals("CurrentPage"))
                {
                    this.NotifyPropertyChanged("CurrentPage");
                }
            };
        }

        public FrameworkElement CurrentPage
        {
            get
            {
                return this.BootstrapperController.PageController.CurrentPage.ViewContent;
            }
        }
    }
}

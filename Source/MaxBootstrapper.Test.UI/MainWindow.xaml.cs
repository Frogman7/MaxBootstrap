using System.Collections.Generic;

namespace MaxBootstrapper.Test.UI
{
    using MaxBootstrap.Core;
    using MaxBootstrap.Core.View;
    using MaxBootstrap.UI.Extensions;
    using MaxBootstrap.UI.Models;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : IBootstrapperMainWindow
    {
        private readonly IBootstrapperController bootstrapperController;

        public MainWindow(IBootstrapperController bootstrapperController)
        {
            this.bootstrapperController = bootstrapperController;

            IBootstrapperMainWindowViewmodel viewModel = new BootstrapperMainWindowViewmodel(bootstrapperController);

            this.Viewmodel = viewModel;

            this.InitializePageController();

            this.InitializeComponent();
        }

        public IBootstrapperMainWindowViewmodel Viewmodel
        {
            get
            {
                return (IBootstrapperMainWindowViewmodel)DataContext;
            }

            set
            {
                this.DataContext = value;
            }
        }

        private void InitializePageController()
        {
            ViewControllerExtensions.SetDefaultSequences(this.Viewmodel.BootstrapperController.ViewController, this.bootstrapperController);
        }
    }
}

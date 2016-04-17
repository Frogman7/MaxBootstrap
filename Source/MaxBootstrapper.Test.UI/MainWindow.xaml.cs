using System.Collections.Generic;
using MaxBootstrap.UI.Pages;

namespace MaxBootstrapper.Test.UI
{
    using MaxBootstrap.Core;
    using MaxBootstrap.Core.View;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : IBootstrapperMainWindow
    {
        private IBootstrapperController bootstrapperController;

        public MainWindow(IBootstrapperController bootstrapperController)
        {
            this.bootstrapperController = bootstrapperController;

            IBootstrapperMainWindowViewmodel viewModel = new BootstrapperMainWindowViewmodel(bootstrapperController);

            this.Viewmodel = viewModel;

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
            var pageController = this.Viewmodel.BootstrapperController.PageController;

            //pageController.PageCollection.CancelPage = new CancelP

            IList<IPage> installPages = new List<IPage>();
            installPages.Add(new OptionPage(this.bootstrapperController));
            installPages.Add(new FeaturePage(this.bootstrapperController));
            installPages.Add(new ProgressPage(this.bootstrapperController));
            installPages.Add(new FinishPage(this.bootstrapperController));

            pageController.PageCollection.StartPage = new WelcomePage(this.bootstrapperController);
            pageController.PageCollection.ErrorPage = new ErrorPage(this.bootstrapperController);
        }
    }
}

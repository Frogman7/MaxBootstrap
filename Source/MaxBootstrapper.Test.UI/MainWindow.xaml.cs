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
            var pageController = this.Viewmodel.BootstrapperController.PageController;

            pageController.PageCollection.RegisterPage(new OptionPage(this.bootstrapperController));
            pageController.PageCollection.RegisterPage(new FeaturePage(this.bootstrapperController));
            pageController.PageCollection.RegisterPage(new ProgressPage(this.bootstrapperController));
            pageController.PageCollection.RegisterPage(new FinishPage(this.bootstrapperController));

            pageController.PageCollection.StartPage = new WelcomePage(this.bootstrapperController);
            pageController.PageCollection.ErrorPage = new ErrorPage(this.bootstrapperController);
            pageController.PageCollection.CancelPage = new CancelPage(this.bootstrapperController);

            pageController.PageCollection.SetInstallSequence(new List<string>() { "OptionPage", "FeaturePage", "ProgressPage", "FinishPage"});
        }
    }
}

using System.Collections.Generic;
using MaxBootstrap.UI.Pages;

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
            PageControllerExtensions.SetDefaultSequences(this.Viewmodel.BootstrapperController.PageController, this.bootstrapperController);

            //var pageController = this.Viewmodel.BootstrapperController.PageController;

            //pageController.PageCollection.RegisterPage<OptionPage>(false, this.bootstrapperController);
            //pageController.PageCollection.RegisterPage<FeaturePage>(false, this.bootstrapperController);
            //pageController.PageCollection.RegisterPage<ConfigurationPage>(false, this.bootstrapperController, new ConfigurationItem[] { new ConfigurationItem( "Tacos", "What the F?", "Burritos" ), new ConfigurationItem("SomeVariable", "Herp", "Derp") });
            //pageController.PageCollection.RegisterPage<ProgressPage>(false, this.bootstrapperController);
            //pageController.PageCollection.RegisterPage<FinishPage>(false, this.bootstrapperController);

            //pageController.PageCollection.RegisterPage<WelcomePage>(true, this.bootstrapperController);
            //pageController.PageCollection.RegisterPage<ErrorPage>(false, this.bootstrapperController);
            //pageController.PageCollection.RegisterPage<CancelPage>(false, this.bootstrapperController);

            //pageController.PageCollection.StartPage = "WelcomePage";
            //pageController.PageCollection.CancelPage = "CancelPage";
            //pageController.PageCollection.ErrorPage = "ErrorPage";

            //pageController.PageCollection.SetInstallSequence(new List<string>() { "OptionPage", "FeaturePage", "ConfigurationPage", "ProgressPage", "FinishPage"});
        }
    }
}

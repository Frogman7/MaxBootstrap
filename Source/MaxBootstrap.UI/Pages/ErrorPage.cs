namespace MaxBootstrap.UI.Pages
{
    using System.Windows;
    using Core;
    using Core.Pages;
    using Viewmodels.Concretes;
    using Viewmodels.Interfaces;
    using Views;

    public class ErrorPage : PageBase
    {
        protected ErrorView ErrorView;

        public ErrorPage(IBootstrapperController bootstrapperController) : base(bootstrapperController)
        {
            this.ErrorView = new ErrorView(new ErrorViewmodel(bootstrapperController));
        }

        public override FrameworkElement ViewContent
        {
            get { return this.ErrorView; }
        }

        public override void OnNavigatedTo()
        {
            this.bootstrapperController.PageController.ButtonStateManager.NextButton.Text = "Close";
        }
    }
}

using System.Windows;
using MaxBootstrap.UI.Viewmodels.Concretes;

namespace MaxBootstrap.UI.Pages
{
    using Core;
    using Core.Pages;
    using Views;

    public class WelcomePage : PageBase
    {
        protected WelcomeView WelcomeView;

        public WelcomePage(IBootstrapperController bootstrapperController)
            : base(bootstrapperController)
        {
            this.WelcomeView = new WelcomeView(new WelcomeViewmodel(bootstrapperController));
        }

        public override FrameworkElement ViewContent
        {
            get
            {
                return this.WelcomeView;
            }
        }

        public override void OnNavigatedTo()
        {
            var buttonManager = this.bootstrapperController.PageController.ButtonStateManager;
            buttonManager.BackButton.Visible = false;
            buttonManager.CancelButton.Visible = false;

            if (!this.bootstrapperController.UpgradeDetected)
            {
                buttonManager.UpgradeButton.Visible = false;
            }

            if (!this.bootstrapperController.PreviouslyInstalled)
            {
                buttonManager.ModifyButton.Visible = false;
                buttonManager.RepairButton.Visible = false;
            }
        }
    }
}

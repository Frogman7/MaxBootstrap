using System.Windows;
using MaxBootstrap.Core;
using MaxBootstrap.Core.Pages;
using MaxBootstrap.UI.Viewmodels.Concretes;
using MaxBootstrap.UI.Views;

namespace MaxBootstrap.UI.Pages
{
    public class FinishPage : PageBase
    {
        protected FinishView FinishView;

        public FinishPage(IBootstrapperController bootstrapperController) : base(bootstrapperController)
        {
            this.FinishView = new FinishView(new FinishViewmodel(bootstrapperController));
        }

        public override FrameworkElement ViewContent
        {
            get { return this.FinishView; }
        }

        public override void OnNavigatedTo()
        {
            this.bootstrapperController.PageController.ButtonStateManager.NextButton.Text = "Finish";
        }
    }
}

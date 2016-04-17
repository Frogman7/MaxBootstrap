using System.Windows;
using MaxBootstrap.Core;
using MaxBootstrap.Core.Pages;
using MaxBootstrap.UI.Viewmodels.Concretes;
using MaxBootstrap.UI.Views;

namespace MaxBootstrap.UI.Pages
{
    public class ProgressPage : PageBase
    {
        protected ProgressView ProgressView;

        public ProgressPage(IBootstrapperController bootstrapperController) : base(bootstrapperController)
        {
            this.ProgressView = new ProgressView(new ProgressViewmodel(bootstrapperController));
        }

        public override FrameworkElement ViewContent
        {
            get { return this.ProgressView; }
        }
    }
}

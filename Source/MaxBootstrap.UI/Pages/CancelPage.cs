using System.Windows;
using MaxBootstrap.UI.Viewmodels.Concretes;
using MaxBootstrap.UI.Views;

namespace MaxBootstrap.UI.Pages
{
    using Core;
    using Core.Pages;

    public class CancelPage : PageBase
    {
        protected CancelView CancelView;

        public CancelPage(IBootstrapperController bootstrapperController) : base(bootstrapperController)
        {
            this.CancelView = new CancelView(new CancelViewmodel(bootstrapperController));
        }

        public override FrameworkElement ViewContent
        {
            get
            {
                return this.CancelView;
            }
        }
    }
}

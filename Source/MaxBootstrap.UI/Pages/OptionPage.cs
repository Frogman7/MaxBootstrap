using System.Windows;
using MaxBootstrap.Core;
using MaxBootstrap.Core.Pages;
using MaxBootstrap.UI.Viewmodels.Concretes;
using MaxBootstrap.UI.Views;

namespace MaxBootstrap.UI.Pages
{
    public class OptionPage : PageBase
    {
        protected OptionView OptionView;

        public OptionPage(IBootstrapperController bootstrapperController) : base(bootstrapperController)
        {
            this.OptionView = new OptionView(new OptionViewmodel(bootstrapperController));

        }

        public override FrameworkElement ViewContent
        {
            get { return this.OptionView; }
        }
    }
}

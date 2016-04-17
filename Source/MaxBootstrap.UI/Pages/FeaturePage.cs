using MaxBootstrap.UI.Viewmodels.Concretes;
using MaxBootstrap.UI.Views;

namespace MaxBootstrap.UI.Pages
{
    using System.Windows;
    using Core;
    using Core.Pages;

    public class FeaturePage : PageBase
    {
        protected FeatureView FeatureView;

        public FeaturePage(IBootstrapperController bootstrapperController) : base(bootstrapperController)
        {
            this.FeatureView = new FeatureView(new FeatureViewmodel(bootstrapperController));
        }

        public override FrameworkElement ViewContent
        {
            get { return this.FeatureView; }
        }
    }
}

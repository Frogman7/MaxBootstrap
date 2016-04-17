namespace MaxBootstrap.UI.Pages
{
    using System.Windows;
    using Core;
    using Core.Pages;
    using Viewmodels.Concretes;
    using Views;

    class ConfigurationPage : PageBase
    {
        protected ConfigurationView ConfigurationView;

        public ConfigurationPage(IBootstrapperController bootstrapperController) : base(bootstrapperController)
        {
            this.ConfigurationView = new ConfigurationView(new ConfigurationViewmodel(bootstrapperController));
        }

        public override FrameworkElement ViewContent
        {
            get
            {
                return ConfigurationView;
            }
        }
    }
}

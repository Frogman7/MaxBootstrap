namespace MaxBootstrap.UI.Pages
{
    using System.Windows;
    using Core;
    using Core.Pages;
    using Viewmodels.Concretes;
    using Views;
    using Models;
    using System.Collections.Generic;

    public class ConfigurationPage : PageBase
    {
        protected ConfigurationView ConfigurationView;

        public ConfigurationPage(IBootstrapperController bootstrapperController, IEnumerable<ConfigurationItem> configurationItems) : base(bootstrapperController)
        {
            this.ConfigurationView = new ConfigurationView(new ConfigurationViewmodel(bootstrapperController, configurationItems));
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

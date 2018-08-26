using System.Collections.Generic;
using MaxBootstrap.Core;
using MaxBootstrap.Core.View;
using MaxBootstrap.UI.Models;

namespace MaxBootstrap.UI.Views.Configuration
{
    public class ConfigurationViewmodel : ViewmodelBase, IConfigurationViewmodel
    {
        public ConfigurationViewmodel(IBootstrapperController bootstrapperController, IView view, IEnumerable<ConfigurationItem> configurationItems) : base(bootstrapperController, view)
        {
            this.ConfigurationItems = configurationItems;
        }

        public override void OnNavigatedTo()
        {
            this.BootstrapperController.ViewController.ButtonStateManager.NextButton.Text = "Next";
        }

        public IEnumerable<ConfigurationItem> ConfigurationItems { get; }
    }
}

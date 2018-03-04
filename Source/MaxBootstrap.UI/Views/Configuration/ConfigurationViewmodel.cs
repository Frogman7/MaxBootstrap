using System.Collections.Generic;
using MaxBootstrap.Core;
using MaxBootstrap.UI.Models;

namespace MaxBootstrap.UI.Views.Configuration
{
    public class ConfigurationViewmodel : ViewmodelBase, IConfigurationViewmodel
    {
        public ConfigurationViewmodel(IBootstrapperController bootstrapperController, IEnumerable<ConfigurationItem> configurationItems) : base(bootstrapperController)
        {
            this.ConfigurationItems = configurationItems;
        }

        public IEnumerable<ConfigurationItem> ConfigurationItems { get; }
    }
}

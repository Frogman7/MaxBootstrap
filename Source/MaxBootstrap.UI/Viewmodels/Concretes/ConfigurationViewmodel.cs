using System;
using System.Collections.Generic;
using MaxBootstrap.Core;
using MaxBootstrap.Core.View;
using MaxBootstrap.UI.Models;
using MaxBootstrap.UI.Viewmodels.Interfaces;

namespace MaxBootstrap.UI.Viewmodels.Concretes
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

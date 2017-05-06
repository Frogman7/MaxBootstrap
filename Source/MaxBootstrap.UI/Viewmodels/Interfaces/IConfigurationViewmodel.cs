using MaxBootstrap.Core.View;
using MaxBootstrap.UI.Models;
using System.Collections.Generic;

namespace MaxBootstrap.UI.Viewmodels.Interfaces
{
    public interface IConfigurationViewmodel : IViewmodel
    {
        IEnumerable<ConfigurationItem> ConfigurationItems { get; }
    }
}

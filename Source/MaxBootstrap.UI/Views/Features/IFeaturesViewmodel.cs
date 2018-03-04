using System.Collections.Generic;
using MaxBootstrap.Core.View;

namespace MaxBootstrap.UI.Views.Features
{
    public interface IFeaturesViewmodel : IViewmodel
    {
        IEnumerable<PackageViewmodel> Packages { get; }
    }
}

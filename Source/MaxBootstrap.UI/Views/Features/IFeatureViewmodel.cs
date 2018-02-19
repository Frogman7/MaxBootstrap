using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaxBootstrap.Core.Packages;
using MaxBootstrap.Core.View;

namespace MaxBootstrap.UI.Views.Feature
{
    public interface IFeatureViewmodel : IViewmodel
    {
        IEnumerable<IPackage> Packages { get; }
    }
}

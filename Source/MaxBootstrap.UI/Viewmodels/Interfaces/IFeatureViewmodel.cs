using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaxBootstrap.Core.Packages;
using MaxBootstrap.Core.View;

namespace MaxBootstrap.UI.Viewmodels.Interfaces
{
    public interface IFeatureViewmodel : IViewmodel
    {
        IEnumerable<IPackage> Packages { get; }
    }
}

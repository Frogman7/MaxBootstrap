using MaxBootstrap.Core.Packages.Features;
using System.Collections.Generic;

namespace MaxBootstrap.Core.Packages
{
    public interface IPackage
    {
        IEnumerable<IFeature> Features { get; }

        string ID { get; }

        string DisplayName { get; }

        bool IsSelected { get; set; }

        void AddFeature(IFeature feature);

        IFeature SearchFeature(string featureId);
    }
}
using System.Collections.Generic;
using MaxBootstrap.Core.Enums;

namespace MaxBootstrap.Core.Packages.Features
{
    public interface IFeature
    {
        int SubFeatureCount { get; }

        string FeatureId { get; }

        uint Size { get; }

        string Title { get; }

        string Description { get; }

        FeatureEnums.Display Display { get; }

        IEnumerable<IFeature> SubFeatures { get; }

        void AddSubFeature(IFeature feature);

        IFeature SearchSubFeatures(string featureId);
    }
}

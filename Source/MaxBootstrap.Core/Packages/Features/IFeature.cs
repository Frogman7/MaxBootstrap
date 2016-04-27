using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaxBootstrap.Core.Enums;

namespace MaxBootstrap.Core.Packages.Features
{
    public interface IFeature
    {
        event Action<FeatureSelectedState.SelectedState> OnFeatureStateChange;

        IEnumerable<IFeature> SubFeatures { get; }

        int SubFeatureCount { get; }

        string FeatureId { get; }

        uint Size { get; }

        string Title { get; }

        string Description { get; }

        FeatureEnums.Display Display { get;  }

        FeatureSelectedState.SelectedState SelectedState { get; }

        void AddSubFeature(IFeature feature);

        IFeature SearchSubFeatures(string featureId);
    }
}

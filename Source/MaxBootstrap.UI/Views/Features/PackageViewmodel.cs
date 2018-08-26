using MaxBootstrap.Core;
using MaxBootstrap.Core.Packages;
using Microsoft.Tools.WindowsInstallerXml.Bootstrapper;
using System.Collections.Generic;
using System.Linq;

namespace MaxBootstrap.UI.Views.Features
{
    public class PackageViewmodel : ObservableBase
    {
        public IPackage Package { get; }

        public IEnumerable<FeatureViewmodel> Features { get => this.features; }

        // TODO Put more thought into this considering some of the other states
        public bool Enabled { get => this.Package.PackageState != PackageState.Present; }

        protected IList<FeatureViewmodel> features;

        private bool selected;

        public PackageViewmodel(IPackage package)
        {
            this.Package = package;

            this.features = new List<FeatureViewmodel>();

            if (package.Features != null)
            {
                foreach (var feature in package.Features)
                {
                    var featureViewmodel = new FeatureViewmodel(feature);

                    featureViewmodel.OnFeatureStateChange += (featureState) => this.OnSubFeatureSelectedStateChange(featureState);

                    this.features.Add(featureViewmodel);
                }
            }

            if (this.Package.PackageState == PackageState.Present ||
                this.features.Any(feature => (feature.State == FeatureViewmodel.SelectedState.Selected) || 
                                             (feature.State == FeatureViewmodel.SelectedState.Partial)))
            {
                this.selected = true;
            }
        }

        public bool Selected
        {
            get
            {
                return this.selected;
            }

            set
            {
                this.selected = value;

                if (this.selected)
                {
                    foreach (var feature in features)
                    {
                        feature.State = FeatureViewmodel.SelectedState.Selected;
                    }
                }
                else
                {
                    foreach (var feature in features)
                    {
                        feature.State = FeatureViewmodel.SelectedState.Unselected;
                    }
                }

                this.NotifyPropertyChanged();
            }
        }

        private void OnSubFeatureSelectedStateChange(FeatureViewmodel.SelectedState selectedState)
        {
            switch (selectedState)
            {
                case FeatureViewmodel.SelectedState.Selected:
                    {
                        this.Selected = true;

                        break;
                    }

                case FeatureViewmodel.SelectedState.Partial:
                    {
                        this.Selected = true;

                        break;
                    }

                case FeatureViewmodel.SelectedState.Unselected:
                    {
                        this.Selected = false;

                        break;
                    }
            }
        }
    }
}

using MaxBootstrap.Core.Packages.Features;
using System.Collections.Generic;
using MaxBootstrap.Core.Enums;
using Microsoft.Tools.WindowsInstallerXml.Bootstrapper;

namespace MaxBootstrap.Core.Packages
{
    public class Package : ObservableBase, IPackage
    {
        private PackageState packageState;

        private RequestState requestedState;

        private IList<IFeature> features;

        private bool isSelected;

        public string ID { get; protected set; }

        public string DisplayName { get; protected set; }

        public bool IsSelected
        {
            get
            {
                return this.isSelected;
            }

            set
            {
                this.isSelected = value;

                if (this.isSelected)
                {
                    foreach (var feature in features)
                    {
                        feature.SelectedState = Enums.FeatureSelectedState.SelectedState.Selected;
                    }
                }
                else
                {
                    foreach (var feature in features)
                    {
                        feature.SelectedState = Enums.FeatureSelectedState.SelectedState.Unselected;
                    }
                }

                this.NotifyPropertyChanged();
            }
        }

        public Package(string id, string displayName)
        {
            this.ID = id;
            this.DisplayName = displayName;
            this.isSelected = true; // Probably want to set to false in the future and programmatically determine if it should be true
            this.features = new List<IFeature>();
        }

        public IEnumerable<IFeature> Features
        {
            get
            {
                return this.features;
            }
        }

        public PackageState PackageState
        {
            get
            {
                return this.packageState;
            }

            set
            {
                this.packageState = value;
            }
        }

        public RequestState RequestedState
        {
            get
            {
                return this.requestedState;
            }

            set
            {
                this.requestedState = value;

                // TODO Reconsider this, I mean is this really the best approach?
                if (this.requestedState == RequestState.Present)
                {
                    this.IsSelected = true;
                }
            }
        }

        public void AddFeature(IFeature feature)
        {
            // TODO Consider putting in some safety checks?
            feature.OnFeatureStateChange += (featureState) => this.OnSubFeatureSelectedStateChange(feature, featureState);

            this.features.Add(feature);
        }

        public IFeature SearchFeature(string featureId)
        {
            IFeature foundFeature = null;

            foreach (IFeature feature in this.features)
            {
                if (feature.FeatureId.Equals(featureId))
                {
                    foundFeature = feature;
                }
                else
                {
                    foundFeature = feature.SearchSubFeatures(featureId);
                }

                if (foundFeature != null)
                {
                    break;
                }
            }

            return foundFeature;
        }

        private void OnSubFeatureSelectedStateChange(IFeature feature, FeatureSelectedState.SelectedState selectedState)
        {
            switch (selectedState)
            {
                case FeatureSelectedState.SelectedState.Selected:
                    {
                        this.IsSelected = true;

                        break;
                    }

                case FeatureSelectedState.SelectedState.Partial:
                    {
                        this.IsSelected = true;

                        break;
                    }

                case FeatureSelectedState.SelectedState.Unselected:
                    {
                        this.IsSelected = false;

                        break;
                    }
            }
        }
    }
}

using MaxBootstrap.Core;
using MaxBootstrap.Core.Packages.Features;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MaxBootstrap.UI.Views.Features
{
    public class FeatureViewmodel : ObservableBase
    {
        public enum SelectedState { Selected, Partial, Unselected };

        public event Action<SelectedState> OnFeatureStateChange;

        public IFeature Feature { get; }

        public IEnumerable<FeatureViewmodel> SubFeatures { get => this.subFeatures; }

        protected IList<FeatureViewmodel> subFeatures;

        protected SelectedState selectedState;

        //public bool Enabled { get => this.Feature. }

        public FeatureViewmodel(IFeature feature)
        {
            this.Feature = feature;

            this.subFeatures = new List<FeatureViewmodel>();

            if (feature.SubFeatures != null)
            {
                foreach (var subFeature in feature.SubFeatures)
                {
                    var subFeatureViewmodel = new FeatureViewmodel(subFeature);

                    subFeatureViewmodel.OnFeatureStateChange += (featureState) => this.OnSubFeatureSelectedStateChange(featureState);

                    this.subFeatures.Add(new FeatureViewmodel(subFeature));
                };
            }
        }

        public SelectedState State
        {
            get
            {
                return this.selectedState;
            }

            set
            {
                if (this.selectedState != value)
                {
                    // The 'partial' state should only be set via events from children
                    if (value == SelectedState.Partial)
                    {
                        if (this.selectedState == SelectedState.Selected)
                        {
                            this.selectedState = SelectedState.Unselected;
                        }
                        else
                        {
                            this.selectedState = SelectedState.Selected;
                        }
                    }
                    else
                    {
                        this.selectedState = value;
                    }

                    if (this.selectedState == SelectedState.Selected)
                    {
                        foreach (var feature in this.SubFeatures)
                        {
                            feature.State = SelectedState.Selected;
                        }
                    }
                    else
                    {
                        foreach (var feature in this.SubFeatures)
                        {
                            feature.State = SelectedState.Unselected;
                        }
                    }

                    if (this.OnFeatureStateChange != null)
                    {
                        this.OnFeatureStateChange(this.selectedState);
                    }

                    this.NotifyPropertyChanged();
                }
            }
        }

        private void OnSubFeatureSelectedStateChange(SelectedState selectedState)
        {
            switch (selectedState)
            {
                case SelectedState.Selected:
                    {
                        if (this.selectedState == SelectedState.Partial)
                        {
                            if (this.subFeatures.Count == 1 || this.AllSubFeaturesSelected())
                            {
                                this.selectedState = SelectedState.Selected;
                            }
                        }
                        else
                        {
                            // The only way to enter this block is if the Selected State on the feature is 'Unselected' so it is assumed
                            if (this.subFeatures.Count == 1)
                            {
                                this.selectedState = SelectedState.Selected;
                            }
                            else
                            {
                                this.selectedState = SelectedState.Partial;
                            }
                        }

                        break;
                    }

                case SelectedState.Partial:
                    {
                        if (this.selectedState == SelectedState.Unselected)
                        {
                            if (this.subFeatures.Count == 1)
                            {
                                this.selectedState = SelectedState.Selected;
                            }
                            else
                            {
                                this.selectedState = SelectedState.Partial;
                            }
                        }
                        else if (this.selectedState == SelectedState.Partial)
                        {
                            if (this.AllSubFeaturesSelected())
                            {
                                this.selectedState = SelectedState.Selected;
                            }
                        }

                        break;
                    }

                case SelectedState.Unselected:
                    {
                        if (this.selectedState == SelectedState.Selected ||
                            this.selectedState == SelectedState.Partial)
                        {
                            if (this.subFeatures.Count == 1)
                            {
                                this.selectedState = SelectedState.Unselected;
                            }
                            else
                            {
                                if (AllSubFeaturesUnselected())
                                {
                                    this.selectedState = SelectedState.Unselected;
                                }
                                else
                                {
                                    this.selectedState = SelectedState.Partial;
                                }
                            }
                        }

                        break;
                    }
            }
        }

        private bool AllSubFeaturesSelected()
        {
            return this.SubFeatures.All(feature => feature.State == SelectedState.Selected ||
            feature.State == SelectedState.Partial);
        }

        private bool AllSubFeaturesUnselected()
        {
            return this.SubFeatures.All(feature => feature.State == SelectedState.Unselected);
        }
    }
}

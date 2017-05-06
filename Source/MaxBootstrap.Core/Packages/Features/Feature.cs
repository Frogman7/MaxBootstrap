using System;
using System.Collections.Generic;
using System.Linq;
using MaxBootstrap.Core.Enums;

using Display = MaxBootstrap.Core.Enums.FeatureEnums.Display;
using SelectedState = MaxBootstrap.Core.Enums.FeatureSelectedState.SelectedState;

namespace MaxBootstrap.Core.Packages.Features
{
    public class Feature : ObservableBase, IFeature
    {
        private readonly IList<IFeature> subFeatures;

        public string Description { get; protected set; }

        public Display Display { get; protected set; }

        public string FeatureId { get; protected set; }

        private SelectedState selectedState;

        public Feature(string featureId, string title, string description, uint size, Display display)
        {
            this.FeatureId = featureId;
            this.Title = title;
            this.Description = description;
            this.Size = size;
            this.Display = display;

            this.subFeatures = new List<IFeature>();
        }

        public SelectedState SelectedState
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
                        foreach (var feature in this.subFeatures)
                        {
                            feature.SelectedState = Enums.FeatureSelectedState.SelectedState.Selected;
                        }
                    }
                    else
                    {
                        foreach (var feature in this.subFeatures)
                        {
                            feature.SelectedState = Enums.FeatureSelectedState.SelectedState.Unselected;
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

        public uint Size { get; protected set; }

        public IEnumerable<IFeature> SubFeatures
        {
            get
            {
                return this.subFeatures;
            }
        }

        public string Title { get; protected set; }

        public int SubFeatureCount
        {
            get
            {
                return this.subFeatures.Count;
            }
        }

        public event Action<FeatureSelectedState.SelectedState> OnFeatureStateChange;

        public void AddSubFeature(IFeature newSubFeature)
        {
            var existingFeature = this.subFeatures.FirstOrDefault(f => f.FeatureId.Equals(newSubFeature.FeatureId));

            if (existingFeature == null)
            {
                newSubFeature.OnFeatureStateChange += (featureState) => this.OnSubFeatureSelectedStateChange(newSubFeature, featureState);

                this.subFeatures.Add(newSubFeature);
            }
        }

        private void OnSubFeatureSelectedStateChange(IFeature feature, FeatureSelectedState.SelectedState selectedState)
        {
            switch (selectedState)
            {
                case FeatureSelectedState.SelectedState.Selected:
                    {
                        if (this.SelectedState == FeatureSelectedState.SelectedState.Partial)
                        {
                            if (this.subFeatures.Count == 1 || this.AllSubFeaturesSelected())
                            {
                                this.SelectedState = FeatureSelectedState.SelectedState.Selected;
                            }
                        }
                        else
                        {
                            // The only way to enter this block is if the Selected State on the feature is 'Unselected' so it is assumed
                            if (this.subFeatures.Count == 1)
                            {
                                this.SelectedState = FeatureSelectedState.SelectedState.Selected;
                            }
                            else
                            {
                                this.SelectedState = FeatureSelectedState.SelectedState.Partial;
                            }
                        }

                        break;
                    }

                case FeatureSelectedState.SelectedState.Partial:
                    {
                        if (this.SelectedState == FeatureSelectedState.SelectedState.Unselected)
                        {
                            if (this.subFeatures.Count == 1)
                            {
                                this.SelectedState = FeatureSelectedState.SelectedState.Selected;
                            }
                            else
                            {
                                this.SelectedState = FeatureSelectedState.SelectedState.Partial;
                            }
                        }
                        else if (this.SelectedState == FeatureSelectedState.SelectedState.Partial)
                        {
                            if (this.AllSubFeaturesSelected())
                            {
                                this.SelectedState = FeatureSelectedState.SelectedState.Selected;
                            }
                        }

                        break;
                    }

                case FeatureSelectedState.SelectedState.Unselected:
                    {
                        if (this.SelectedState == FeatureSelectedState.SelectedState.Selected ||
                            this.SelectedState == FeatureSelectedState.SelectedState.Partial)
                        {
                            if (this.subFeatures.Count == 1)
                            {
                                this.SelectedState = FeatureSelectedState.SelectedState.Unselected;
                            }
                            else
                            {
                                if (AllSubFeaturesUnselected())
                                {
                                    this.SelectedState = FeatureSelectedState.SelectedState.Unselected;
                                }
                                else
                                {
                                    this.SelectedState = FeatureSelectedState.SelectedState.Partial;
                                }
                            }
                        }

                        break;
                    }
            }
        }

        private bool AllSubFeaturesSelected()
        {
            return this.subFeatures.All(feature => feature.SelectedState == FeatureSelectedState.SelectedState.Selected ||
            feature.SelectedState == FeatureSelectedState.SelectedState.Partial);
        }

        private bool AllSubFeaturesUnselected()
        {
            return this.subFeatures.All(feature => feature.SelectedState == FeatureSelectedState.SelectedState.Unselected);
        }

        public IFeature SearchSubFeatures(string featureId)
        {
            IFeature foundFeature = null;
            
            foreach (IFeature feature in this.SubFeatures)
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
    }
}

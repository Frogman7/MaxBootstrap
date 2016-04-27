using MaxBootstrap.Core.Packages.Features;
using System.Collections.Generic;
using System;

namespace MaxBootstrap.Core.Packages
{
    public class Package : IPackage
    {
        private IList<IFeature> features;

        public string ID { get; protected set; }

        public string DisplayName { get; protected set; }

        public bool IsSelected { get; set; }

        public Package(string id, string displayName)
        {
            this.ID = id;
            this.DisplayName = displayName;
            this.features = new List<IFeature>();
        }

        public IEnumerable<IFeature> Features
        {
            get
            {
                return this.features;
            }
        }

        public void AddFeature(IFeature feature)
        {
            // TODO Consider putting in some safety checks?
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
    }
}

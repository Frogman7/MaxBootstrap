﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MaxBootstrap.Core.Configuration
{
    [XmlRoot("BootstrapperApplicationData", IsNullable = false, Namespace = "http://schemas.microsoft.com/wix/2010/BootstrapperApplicationData")]
    public class BurnApplicationInfo
    {
        [XmlElement("WixBundleProperties")]
        public BundlePropertiesInfo BundleAttributes
        {
            get;
            set;
        }

        [XmlElement("WixPackageProperties")]
        public List<PackageInfo> Packages { get; private set; }

        [XmlElement("WixPackageFeatureInfo")]
        public List<FeatureInfo> PackageFeatures { get; private set; }

        public BurnApplicationInfo()
        {
            this.Packages = new List<PackageInfo>();
            this.PackageFeatures = new List<FeatureInfo>();
        }
    }
}
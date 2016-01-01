using MaxBootstrap.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MaxBootstrap.Core.Configuration
{
    public class FeatureInfo
    {
        [XmlAttribute("Parent")]
        public string Parent { get; set; }

        [XmlAttribute("Package")]
        public string PackageId { get; set; }

        [XmlAttribute("Feature")]
        public string FeatureId { get; set; }

        [XmlAttribute("Size")]
        public uint Size { get; set; }

        [XmlAttribute("Title")]
        public string Title { get; set; }

        [XmlAttribute("Description")]
        public string Description { get; set; }

        [XmlAttribute("Display")]
        public FeatureEnums.Display Display { get; set; }

        [XmlAttribute("Attributes")]
        private byte AttributesValue { get; set; }

        [XmlAttribute("Directory")]
        public string Directory { get; set; }

        public FeatureEnums.Attributes Attributes
        {
            get
            {
                return (FeatureEnums.Attributes)this.AttributesValue;
            }
        }
    }
}

using System.Xml.Serialization;

namespace MaxBootstrap.Core.Configuration
{
    public class BundlePropertiesInfo
    {
        [XmlAttribute("DisplayName")]
        public string DisplayName { get; set; }
    }
}

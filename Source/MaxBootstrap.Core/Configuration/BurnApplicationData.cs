using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MaxBootstrap.Core.Configuration
{
    public class ConfigurationInfo
    {
        [XmlAttribute("Caption")]
        public string Caption { get; set; }

        [XmlAttribute("Description")]
        public string Description { get; set; }

        [XmlAttribute("PackageIds")]
        public string PackageIds { get; set; }

        [XmlElement("WixVariable")]
        public List<VariableInfo> WixVariables { get; set; }
    }
}

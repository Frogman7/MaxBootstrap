using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MaxBootstrap.Core.Configuration
{
    public class PackageInfo
    {
        [XmlAttribute("Package")]
        public string Id { get; set;}

        [XmlAttribute("DisplayName")]
        public string DisplayName { get; set; }

        [XmlAttribute("Description")]
        public string Description { get; set; }
    }
}

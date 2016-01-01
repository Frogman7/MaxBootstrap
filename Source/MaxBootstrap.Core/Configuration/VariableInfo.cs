using System.Xml.Serialization;

namespace MaxBootstrap.Core.Configuration
{
    public class VariableInfo
    {
        [XmlAttribute("Caption")]
        public string Caption { get; private set; }

        [XmlAttribute("Name")]
        public string Name { get; private set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxBootstrap.UI.Models
{
    public class ConfigurationItem
    {
        public string Caption { get; }

        public string WixVariable { get; }

        public string Value { get; set; }

        public ConfigurationItem(string wixVariable, string caption, string initialValue)
        {
            this.WixVariable = wixVariable;
            this.Caption = caption;
            this.Value = initialValue;
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MaxBootstrap.Core.Configuration.Loaders
{
    internal class BurnApplicationDataLoader
    {
        private const string BootstrapperApplicationDataFilename = "BootstrapperApplicationData.xml";

        private XmlDeserializer<BurnApplicationInfo> deserializer;

        public BurnApplicationDataLoader()
        {
            var pathToTempInstallationDirectory = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), BootstrapperApplicationDataFilename);
            this.deserializer = new XmlDeserializer<BurnApplicationInfo>(pathToTempInstallationDirectory);
        }

        public BurnApplicationInfo Load()
        {
            return this.deserializer.Deserialize();
        }
    }
}

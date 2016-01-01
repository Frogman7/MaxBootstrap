using Microsoft.Tools.WindowsInstallerXml.Bootstrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxBootstrap.Core
{
    public interface IBundle
    {
        string BundleTag { get; }

        RelatedOperation Operation { get; }

        bool PerMachine { get; }

        string ProductCode { get; }

        RelationType Relation { get; }

        Version Version { get; }
    }
}

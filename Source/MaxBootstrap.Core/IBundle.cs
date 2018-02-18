﻿using Microsoft.Tools.WindowsInstallerXml.Bootstrapper;
using System;

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxBootstrap.Core.Enums
{
    public enum BurnInstallState
    {
        Initializing,
        Present,
        NotPresent,
        Newer,
        Applying,
        Applied,
        Failed
    }
}

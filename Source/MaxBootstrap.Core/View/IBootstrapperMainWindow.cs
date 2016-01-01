using MaxBootstrap.Core.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxBootstrap.Core
{
    public interface IBootstrapperMainWindow
    {
        IBootstrapperMainWindowViewmodel Viewmodel { get; }
    }
}

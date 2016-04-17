﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MaxBootstrap.Core.View
{
    public interface IBootstrapperMainWindowViewmodel
    {
        IBootstrapperController BootstrapperController { get; }

        FrameworkElement CurrentPage { get; }
    }
}

using MaxBootstrap.Core.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxBootstrap.UI.Views.Commit
{
    public interface ICommitViewmodel : IViewmodel
    {
        string CommitMessage { get; }
    }
}

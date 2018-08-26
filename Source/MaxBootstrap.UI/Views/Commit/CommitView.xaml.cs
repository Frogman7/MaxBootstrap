using MaxBootstrap.Core.View;
using System.Windows.Controls;

namespace MaxBootstrap.UI.Views.Commit
{
    /// <summary>
    /// Interaction logic for InstallView.xaml
    /// </summary>
    public partial class CommitView : UserControl, IView
    {
        public CommitView()
        {
            InitializeComponent();
        }

        public IViewmodel Viewmodel
        {
            get
            {
                return (IViewmodel)this.DataContext;
            }

            set
            {
                this.DataContext = value;
            }
        }
    }
}

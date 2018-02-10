using System.Windows.Controls;
using MaxBootstrap.Core.View;
using MaxBootstrap.UI.Viewmodels.Interfaces;

namespace MaxBootstrap.UI.Views
{
    /// <summary>
    /// Interaction logic for FinishView.xaml
    /// </summary>
    public partial class FinishView : UserControl, IView
    {
        public FinishView(IFinishViewmodel viewmodel)
        {
            this.InitializeComponent();

            this.Viewmodel = viewmodel;

            this.Viewmodel.Activate();
        }

        public IViewmodel Viewmodel
        {
            get { return (IViewmodel)this.DataContext; }
            set { this.DataContext = value; }
        }
    }
}

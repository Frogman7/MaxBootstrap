using System.Windows.Controls;
using MaxBootstrap.Core.View;

namespace MaxBootstrap.UI.Views.Finish
{
    /// <summary>
    /// Interaction logic for FinishView.xaml
    /// </summary>
    public partial class FinishView : UserControl, IView
    {
        public FinishView()
        {
            this.InitializeComponent();
        }

        public IViewmodel Viewmodel
        {
            get { return (IViewmodel)this.DataContext; }
            set { this.DataContext = value; }
        }
    }
}

using System.Windows.Controls;
using MaxBootstrap.Core.View;

namespace MaxBootstrap.UI.Views
{
    /// <summary>
    /// Interaction logic for CancelView.xaml
    /// </summary>
    public partial class CancelView : UserControl, IView
    {
        public CancelView()
        {
            this.InitializeComponent();
        }

        public IViewmodel Viewmodel
        {
            get
            {
                return this.DataContext as IViewmodel;
            }

            set { this.DataContext = value; }
        }
    }
}

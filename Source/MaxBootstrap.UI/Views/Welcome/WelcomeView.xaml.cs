using System.Windows.Controls;
using MaxBootstrap.Core.View;

namespace MaxBootstrap.UI.Views.Welcome
{
    /// <summary>
    /// Interaction logic for WelcomeView.xaml
    /// </summary>
    public partial class WelcomeView : UserControl, IView
    {
        public WelcomeView()
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

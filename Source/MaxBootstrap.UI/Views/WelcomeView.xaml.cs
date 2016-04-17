using System.Windows.Controls;
using MaxBootstrap.Core.View;
using MaxBootstrap.UI.Viewmodels.Interfaces;

namespace MaxBootstrap.UI.Views
{
    /// <summary>
    /// Interaction logic for WelcomeView.xaml
    /// </summary>
    public partial class WelcomeView : UserControl, IView
    {
        public WelcomeView(IWelcomeViewmodel welcomeViewmodel)
        {
            this.InitializeComponent();

            this.Viewmodel = welcomeViewmodel;
        }

        public IViewmodel Viewmodel
        {
            get { return (IViewmodel)this.DataContext; }
            set { this.DataContext = value; }
        }
    }
}

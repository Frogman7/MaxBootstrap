using System.Windows.Controls;
using MaxBootstrap.Core.View;
using MaxBootstrap.UI.Viewmodels.Interfaces;

namespace MaxBootstrap.UI.Views
{
    /// <summary>
    /// Interaction logic for ConfigurationView.xaml
    /// </summary>
    public partial class ConfigurationView : UserControl, IView
    {
        public ConfigurationView(IConfigurationViewmodel configurationViewmodel)
        {
            this.InitializeComponent();

            this.Viewmodel = configurationViewmodel;

            this.Viewmodel.Activate();
        }

        public IViewmodel Viewmodel
        {
            get
            {
                return (IViewmodel) this.DataContext;
            }

            set
            {
                this.DataContext = value;
            }
        }
    }
}

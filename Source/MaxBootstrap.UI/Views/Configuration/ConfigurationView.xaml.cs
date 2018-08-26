using System.Windows.Controls;
using MaxBootstrap.Core.View;

namespace MaxBootstrap.UI.Views.Configuration
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

            this.Viewmodel.OnNavigatedTo();
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

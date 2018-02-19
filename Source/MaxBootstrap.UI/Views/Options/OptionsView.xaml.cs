using System.Windows.Controls;
using MaxBootstrap.Core.View;

namespace MaxBootstrap.UI.Views.Options
{
    /// <summary>
    /// Interaction logic for OptionView.xaml
    /// </summary>
    public partial class OptionsView : UserControl, IView
    {
        public OptionsView(IOptionsViewmodel viewmodel)
        {
            this.InitializeComponent();

            this.Viewmodel = viewmodel;

            this.Viewmodel.Activate();
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

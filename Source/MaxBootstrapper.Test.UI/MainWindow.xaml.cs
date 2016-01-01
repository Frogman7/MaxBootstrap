using MaxBootstrap.Core;
using MaxBootstrap.Core.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MaxBootstrapper.Test.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : BootstrapperMainWindowBase
    {
        public MainWindow(IBootstrapperController bootstrapperController)
        {
            IBootstrapperMainWindowViewmodel viewModel = new BootstrapperMainWindowViewmodel(bootstrapperController);
            this.Viewmodel = viewModel;

            InitializeComponent();
        }
    }
}

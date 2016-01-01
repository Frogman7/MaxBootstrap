using MaxBootstrap.Core.Configuration.Loaders;
using MaxBootstrap.Core.Packages;
using MaxBootstrap.Core.Pages;
using Microsoft.Tools.WindowsInstallerXml.Bootstrapper;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows;
using System.Windows.Threading;
using System.Linq;
using System.Configuration;

namespace MaxBootstrap.Core
{
    public class MaxBootstrapper : BootstrapperApplication
    {
        private BootstrapperMainWindowBase mainWindow;

        protected override void Run()
        {
#if DEBUG
            Debugger.Launch();
#endif
            
            this.mainWindow = ResolveMainWindow();

            this.Engine.Log(LogLevel.Verbose, "Starting MaxBootstrapper");

            this.mainWindow.Closed += delegate
            {
                this.Engine.Quit(0);
            };

            // this.mainWindow.Show();

            this.Engine.Detect();

            var bundleLoader = new BurnApplicationDataLoader();
            var info = bundleLoader.Load();

            Dispatcher.Run();

            this.Engine.Quit(mainWindow.Viewmodel.BootstrapperController.FinalResult);
        }

        private BootstrapperMainWindowBase ResolveMainWindow()
        {
            string assemblyName = this.GetSetting("MaxBootstrapperUI");

            var asm = AppDomain.CurrentDomain.Load(assemblyName);

            // TODO Add some error check and log it if it should fail to find a type inheriting from the base
            var type = asm.GetTypes().First(t => t.IsSubclassOf(typeof(BootstrapperMainWindowBase)));

            var bootstrapperController = new BootstrapperController(this, new PageController(new PageCollection()), new PackageManager());

            return (BootstrapperMainWindowBase)Activator.CreateInstance(type, new object[] { bootstrapperController });
        }

        private string GetSetting(string key)
        {
            string value = null;

            if (ConfigurationManager.AppSettings != null && !string.IsNullOrEmpty(key))
            {
                try
                {
                    value = ConfigurationManager.AppSettings[key];
                }

                catch
                {
                    // Log that key could not be read
                }
            }

            return value;
        }
    }
}

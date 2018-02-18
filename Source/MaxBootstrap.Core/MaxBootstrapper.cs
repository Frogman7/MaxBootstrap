namespace MaxBootstrap.Core
{
    using System;
    using System.Configuration;
    using System.Diagnostics;
    using System.Linq;
    using System.Windows;
    using System.Windows.Threading;

    using MaxBootstrap.Core.Configuration.Loaders;
    using MaxBootstrap.Core.Packages;

    using Microsoft.Tools.WindowsInstallerXml.Bootstrapper;
    using Helpers;
    using MaxBootstrap.Core.View;
    using MaxBootstrap.Core.View.MainWindow;

    public class MaxBootstrapper : BootstrapperApplication
    {
        public Dispatcher BootstrapperDispatcher { get; protected set; }

        private Window mainWindow;

        protected override void Run()
        {
#if DEBUG
            Debugger.Launch();
#endif

            this.BootstrapperDispatcher = Dispatcher.CurrentDispatcher;

            this.mainWindow = this.ResolveMainWindow();

            var bootstrapperMainWindow = this.mainWindow as IBootstrapperMainWindow;

            var bundleLoader = new BurnApplicationDataLoader();
            var info = bundleLoader.Load();

            var packageTrees = PackageFeatureTreeBuilder.BuildPackageTrees(info.Packages, info.PackageFeatures);

            foreach (var packageTree in packageTrees)
            {
                bootstrapperMainWindow.Viewmodel.BootstrapperController.PackageManager.AddPackage(packageTree);
            }

            this.Engine.Log(LogLevel.Verbose, "Starting MaxBootstrapper");

            this.mainWindow.Closed += delegate
            {
                this.Engine.Quit(0);
            };

            this.mainWindow.Show();

            this.Engine.Detect();

            Dispatcher.Run();

            // Figured there should be a null check here even though it should be theoretically impossible to ever not be null
            if (bootstrapperMainWindow != null)
            {
                this.Engine.Quit(bootstrapperMainWindow.Viewmodel.BootstrapperController.FinalResult);
            }
            else
            {
                this.Engine.Quit(-1);
            }
        }

        private Window ResolveMainWindow()
        {
            string assemblyName = this.GetSetting("MaxBootstrapperUI");

            var asm = AppDomain.CurrentDomain.Load(assemblyName);

            // TODO Add some error check and log it if it should fail to find a type inheriting from the base
            var type = asm.GetTypes().First(t => t.GetInterfaces().Contains(typeof(IBootstrapperMainWindow)));

            var bootstrapperController = new BootstrapperController(this, new ViewController(new ViewCollection()), new PackageManager());

            var window = (Window)Activator.CreateInstance(type, new object[] { bootstrapperController });

            bootstrapperController.WindowHandle = new System.Windows.Interop.WindowInteropHelper(window).Handle;

            return window;
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

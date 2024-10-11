using PrivateBrowser.Services;
using PrivateBrowser.Views;
using System.Windows;

namespace PrivateBrowser
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            // Register modules here if needed
        }

        protected override Window CreateShell()
        {
            // Create and return the main window of the application
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Register services like encryption, tracker blocking, etc.
            containerRegistry.Register<ITrackerBlockerService, TrackerBlockerService>();
            containerRegistry.Register<IEncryptionService, EncryptionService>();
        }
    }
}
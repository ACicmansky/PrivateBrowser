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
        }

        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IWebViewService, WebViewService>();

            containerRegistry.Register<ITrackerBlockerService, TrackerBlockerService>();
            containerRegistry.Register<IEncryptionService, EncryptionService>();            
            containerRegistry.Register<IHistoryService, HistoryService>();
        }
    }
}
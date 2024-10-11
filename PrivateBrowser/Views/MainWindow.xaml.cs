using PrivateBrowser.Services;
using System.Windows;

namespace PrivateBrowser.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IWebViewService _webViewService;

        public MainWindow(IWebViewService webViewService)
        {
            InitializeComponent();

            _webViewService = webViewService;
            InitializeWebViewAsync();
        }

        private async void InitializeWebViewAsync()
        {
            try
            {
                await BrowserControl.EnsureCoreWebView2Async();
                _webViewService.Initialize(BrowserControl);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"WebView2 initialization failed: {ex.Message}");
            }
        }
    }
}
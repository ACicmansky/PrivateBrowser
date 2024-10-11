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
            BrowserControl.EnsureCoreWebView2Async().ContinueWith(task =>
            {
                _webViewService.Initialize(BrowserControl);
            });
        }
    }
}
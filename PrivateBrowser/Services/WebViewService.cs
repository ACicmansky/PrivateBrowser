using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.Wpf;

namespace PrivateBrowser.Services
{
    public interface IWebViewService
    {
        void Initialize(WebView2 webView);
        void GoBack();
        void GoForward();
        void NavigateTo(string url);
    }


    public class WebViewService : IWebViewService
    {
        private readonly ITrackerBlockerService _trackerBlocker;
        private WebView2 _webView;

        public WebViewService(ITrackerBlockerService trackerBlockerService)
        {
            _trackerBlocker = trackerBlockerService;
        }

        public void Initialize(WebView2 webView)
        {
            _webView = webView;

            _webView.NavigationCompleted += (sender, args) =>
            {
                Console.WriteLine("Navigation completed.");
            };

            _webView.CoreWebView2.AddWebResourceRequestedFilter("*", CoreWebView2WebResourceContext.All);
            _webView.CoreWebView2.WebResourceRequested += OnWebResourceRequested;
        }

        public void GoBack()
        {
            if (_webView.CanGoBack)
                _webView.GoBack();
        }

        public void GoForward()
        {
            if (_webView.CanGoForward)
                _webView.GoForward();
        }

        public void NavigateTo(string url)
        {
            _webView.CoreWebView2.Navigate(url);
        }

        public void Dispose()
        {
            if (_webView != null)
            {
                _webView.CoreWebView2.WebResourceRequested -= OnWebResourceRequested;
            }
        }

        private void OnWebResourceRequested(object sender, CoreWebView2WebResourceRequestedEventArgs e)
        {
            var request = e.Request;

            if (_trackerBlocker.IsTracker(request.Uri)) 
            { 
                //Modify the User-Agent header to anonymize
                request.Headers.SetHeader("User-Agent", "AnonymousBrowser/1.0");

                //Remove sensitive headers
                request.Headers.RemoveHeader("Referer");
                request.Headers.RemoveHeader("Cookie");

                //AAdd custom headers here to anonymize the requests further
                request.Headers.SetHeader("X-Requested-By", "AnonymousUser");
            }
        }
    }
}

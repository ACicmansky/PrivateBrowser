using Microsoft.Web.WebView2.Wpf;

namespace PrivateBrowser.Services
{
    public interface IWebViewService
    {
        void Initialize(WebView2 webView);
        void GoBack();
        void GoForward();
    }


    public class WebViewService : IWebViewService
    {
        private WebView2 _webView;

        public void Initialize(WebView2 webView)
        {
            _webView = webView;
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
    }
}

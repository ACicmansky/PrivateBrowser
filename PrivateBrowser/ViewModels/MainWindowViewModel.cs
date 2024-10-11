using PrivateBrowser.Services;
using System.ComponentModel;
using System.IO;
using System.Reactive.Linq;

namespace PrivateBrowser.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string? _url;
        private readonly ITrackerBlockerService _trackerBlocker;
        private readonly IEncryptionService _encryptionService;

        public MainWindowViewModel(ITrackerBlockerService trackerBlocker, IEncryptionService encryptionService)
        {
            _trackerBlocker = trackerBlocker;
            _encryptionService = encryptionService;

            NavigateBackCommand = new DelegateCommand(OnNavigateBack);
            NavigateForwardCommand = new DelegateCommand(OnNavigateForward);
            LoadUrlCommand = new DelegateCommand(OnLoadUrl);

            Observable.FromEventPattern<PropertyChangedEventArgs>(this, nameof(PropertyChanged))
                      .Where(e => e.EventArgs.PropertyName == nameof(Url))
                      .Throttle(TimeSpan.FromMilliseconds(500)) // Debounce URL change
                      .Subscribe(_ => SaveEncryptedHistory(Url));
        }

        public string? Url
        {
            get => _url;
            set => SetProperty(ref _url, value);
        }

        public DelegateCommand NavigateBackCommand { get; }
        public DelegateCommand NavigateForwardCommand { get; }
        public DelegateCommand LoadUrlCommand { get; }

        private void OnNavigateBack()
        {
        }

        private void OnNavigateForward()
        {
        }

        private void OnLoadUrl()
        {
            if (_trackerBlocker.IsTracker(Url))
            {
                // Block the request and redirect
                Url = "about:blank";
            }
        }

        private void SaveEncryptedHistory(string url)
        {
            string encryptedUrl = _encryptionService.Encrypt(url);
            File.AppendAllText("history.dat", encryptedUrl + Environment.NewLine);
        }

        private string LoadEncryptedHistory()
        {
            string cipherText = File.ReadAllText("history.dat");
            return _encryptionService.Decrypt(cipherText);
        }
    }
}
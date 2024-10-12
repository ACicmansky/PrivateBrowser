using PrivateBrowser.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PrivateBrowser.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string? _url;

        private readonly IHistoryService _historyService;
        private readonly IWebViewService _webViewService;

        public MainWindowViewModel(IHistoryService historyService, IWebViewService webViewService)
        {
            _historyService = historyService;
            _webViewService = webViewService;

            HistoryItems = new ObservableCollection<string>();

            NavigateBackCommand = new DelegateCommand(OnNavigateBack);
            NavigateForwardCommand = new DelegateCommand(OnNavigateForward);
            LoadUrlCommand = new DelegateCommand(OnLoadUrl);
            ViewHistoryCommand = new DelegateCommand(OnViewHistoryCommand);
            ClearHistoryCommand = new DelegateCommand(OnClearHistoryCommand);
        }

        public string? Url
        {
            get => _url;
            set => SetProperty(ref _url, value);
        }

        public ObservableCollection<string> HistoryItems { get; set; }

        public DelegateCommand NavigateBackCommand { get; }
        public DelegateCommand NavigateForwardCommand { get; }
        public DelegateCommand LoadUrlCommand { get; }
        public DelegateCommand ViewHistoryCommand { get; }
        public DelegateCommand ClearHistoryCommand { get; }

        private void OnNavigateBack()
        {
            _webViewService.GoBack();
        }

        private void OnNavigateForward()
        {
            _webViewService.GoForward();
        }

        private void OnLoadUrl()
        {
            _webViewService.NavigateTo(Url);
        }

        private void OnViewHistoryCommand() 
        {
            HistoryItems.Clear();
            HistoryItems.AddRange(_historyService.LoadHistory());
        }

        private void OnClearHistoryCommand() 
        {
            _historyService.ClearHistory();
            HistoryItems.Clear();
        }
    }
}
using System.IO;

namespace PrivateBrowser.Services
{
    public interface IHistoryService
    {
        void SaveHistory(string url);
        IEnumerable<string> LoadHistory();
        void ClearHistory();
    }

    public class HistoryService : IHistoryService
    {
        private readonly string _historyFileName;

        private readonly IEncryptionService _encryptionService;

        public HistoryService(IEncryptionService encryptionService)
        {
            _encryptionService = encryptionService;

            _historyFileName = "history.txt";
        }

        public void ClearHistory()
        {
            if (File.Exists(_historyFileName))
            {
                File.Delete(_historyFileName);
            }
        }

        public IEnumerable<string> LoadHistory()
        {
            if (!File.Exists(_historyFileName))
            {
                return new List<string>();
            }

            var encryptedUrls = File.ReadAllLines(_historyFileName);
            var decryptedUrls = encryptedUrls.Select(url => _encryptionService.Decrypt(url)).ToList();

            return decryptedUrls;
        }

        public void SaveHistory(string url)
        {
            string encryptedUrl = _encryptionService.Encrypt(url);
            File.AppendAllText(_historyFileName, encryptedUrl + Environment.NewLine);
        }
    }
}

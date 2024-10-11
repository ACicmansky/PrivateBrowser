namespace PrivateBrowser.Services
{
    public interface ITrackerBlockerService
    {
        bool IsTracker(string url);
    }

    public class TrackerBlockerService : ITrackerBlockerService
    {
        private readonly List<string> _blockedTrackers;

        public TrackerBlockerService()
        {
            //TODO Use a predefined list of known trackers
            _blockedTrackers = new List<string> { "ads.google.com", "tracker1.com" };
        }

        public bool IsTracker(string url)
        {
            return _blockedTrackers.Any(tracker => url.Contains(tracker));
        }
    }
}
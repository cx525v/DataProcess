using DataProcess.Models.Tracker;

namespace DataProcess.Services
{
    public interface ITrackerDataHandler
    {
        TrackerRecord GetTrackerRecord(string path);
    }
}

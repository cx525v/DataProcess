using DataProcess.DataAccess;
using DataProcess.Models.Tracker;

namespace DataProcess.Services
{
    public class TrackerDataHandler : ITrackerDataHandler
    {
        private readonly IJsonObjectReader<TrackerRecord> _dataReader;
        public TrackerDataHandler(IJsonObjectReader<TrackerRecord> dataReader)
        {
            _dataReader = dataReader;
        }

        public TrackerRecord GetTrackerRecord(string path)
        {
            return _dataReader.GetData(path);
        }
    }
}

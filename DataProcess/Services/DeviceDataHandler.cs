using DataProcess.DataAccess;
using DataProcess.Models.Device;

namespace DataProcess.Services
{
    public class DeviceDataHandler : IDeviceDataHandler
    {
        private readonly IJsonObjectReader<DeviceRecord> _dataReader;
        public DeviceDataHandler(IJsonObjectReader<DeviceRecord> dataReader)
        {
            _dataReader = dataReader;
        }

        public DeviceRecord GetDeviceRecord(string path)
        {
           return _dataReader.GetData(path);
        }
    }
}

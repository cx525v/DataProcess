using DataProcess.Models.Device;

namespace DataProcess.Services
{
    public interface IDeviceDataHandler
    {
        DeviceRecord GetDeviceRecord(string path);
    }
}

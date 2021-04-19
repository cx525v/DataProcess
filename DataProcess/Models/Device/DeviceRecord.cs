using System.Collections.Generic;

namespace DataProcess.Models.Device
{
    public class DeviceRecord
    {
        public int CompanyId { get; set; }
        public string Company { get; set; }
        public List<Device> Devices { get; set; }
    }
}

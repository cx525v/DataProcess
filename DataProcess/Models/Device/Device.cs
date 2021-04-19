using System;
using System.Collections.Generic;

namespace DataProcess.Models.Device
{
    public class Device
    {
        public int DeviceID { get; set; }
        public string Name { get; set; }

        public DateTime? StartDateTime { get; set; }
        public List<SensorData> SensorData { get; set; }
    }
}

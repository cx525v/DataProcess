using System;

namespace DataProcess.Models.Device
{
    public class SensorData
    {
        public string SensorType { get; set; }
        public DateTime? DateTime { get; set; }
        public double Value { get; set; }
    }
}

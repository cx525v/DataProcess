using System;
using System.Collections.Generic;

namespace DataProcess.Models.Tracker
{
    public class Tracker
    {
        public int Id { get; set; }
        public string Model { get; set; }

        public DateTime? ShipmentStartDtm { get; set; }

        public List<Sensor> Sensors { get; set; }
    }
}

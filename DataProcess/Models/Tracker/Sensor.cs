using System.Collections.Generic;

namespace DataProcess.Models.Tracker
{
    public class Sensor
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Crumb> Crumbs { get; set; }
    }
}

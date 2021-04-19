using System;
using System.Collections.Generic;
using System.Text;

namespace DataProcess.Models.Tracker
{
    public class TrackerRecord
    {
        public int PartnerId { get; set; }
        public string PartnerName { get; set; }

        public List<Tracker> Trackers { get; set; }
    }
}

using System.Collections.Generic;

namespace WorldTracker.Models
{
    public class EventAddViewModel
    {
        public Event Event { get; set; }
        public string SiteName { get; set; }
        public List<Location> Locations { get; set; }
    }
}
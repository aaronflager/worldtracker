
using System.Collections.Generic;

namespace WorldTracker.Models
{
    public class EventViewModel
    {
        public Event InitialEvent { get; set; }
        public Event ModifiedEvent { get; set; }
        public string SiteName { get; set; }
        public List<Location> Locations { get; set; }
    }
}

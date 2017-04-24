using System.ComponentModel.DataAnnotations;

namespace WorldTracker.Models
{
    public class Location
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
        public string Geography { get; set; }
        public int LocationID { get; set; }
    }
}
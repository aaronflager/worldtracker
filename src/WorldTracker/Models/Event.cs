using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WorldTracker.Models
{
    public class Event
    {
        [Required]
        public string Title { get; set; }

        public string WorldDate { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public Location Site { get; set; }

        public int EventID { get; set; }
    }
}
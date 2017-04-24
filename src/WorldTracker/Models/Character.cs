using System.ComponentModel.DataAnnotations;

namespace WorldTracker.Models
{
    public class Character
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Race { get; set; }

        [Required]
        public string Class { get; set; }

        public string Background { get; set; }
        public string Description { get; set; }
        public string Backstory { get; set; }
        public int CharacterID { get; set; }
        //TODO: attach a player to a character
    }
}
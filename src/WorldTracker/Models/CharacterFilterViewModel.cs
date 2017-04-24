using System.Collections.Generic;

namespace WorldTracker.Models
{
    public class CharacterFilterViewModel
    {
        public List<Character> PriorCharacters { get; set; }
        public List<Character> Characters { get; set; }
        public string filterName { get; set; }
    }
}
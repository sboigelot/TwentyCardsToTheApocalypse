using System.Collections.Generic;

namespace Assets.Scripts.Models
{
    public class PrototypeData
    {
        public List<Deck> Decks { get; set; }

        public List<Apocalypse> Apocalypses { get; set; }

        public PlayerProfile PlayerTemplate { get; set; }
    }
}
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Assets.Scripts.Models
{
    public class Deck
    {
        public string Name { get; set; }

        public List<Card> Cards { get; set; }
    }
}
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Assets.Scripts.Models
{
    public class Apocalypse
    {
        public const int TurnToEndAllLifeOnEarth = 20;

        [XmlAttribute]
        public string Name { get; set; }

        [XmlAttribute]
        public string BackgroundSpriteName { get; set; }

        public Card StartupCard { get; set; }

        public World StartupWorld { get; set; }

        public List<string> AvailableDeckNames { get; set; }
    }
}
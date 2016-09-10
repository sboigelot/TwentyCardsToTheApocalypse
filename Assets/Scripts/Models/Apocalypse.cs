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

        [XmlElement("StartupCard")]
        public Card StartupCard { get; set; }

        [XmlElement("WolrdEndCard")]
        public Card WolrdEndCard { get; set; }

        [XmlElement("VictoryCard")]
        public Card VictoryCard { get; set; }

        [XmlElement("StartupWorld")]
        public World StartupWorld { get; set; }

        [XmlElement("AvailableDeck")]
        public List<string> AvailableDeckNames { get; set; }
    }
}
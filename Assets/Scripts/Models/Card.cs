using System.Collections.Generic;
using System.Xml.Serialization;
using Assets.Scripts.Models.Effects;

namespace Assets.Scripts.Models
{
    public class Card
    {
        [XmlAttribute]
        public string Name { get; set; }

        [XmlAttribute]
        public string SpriteName { get; set; }

        [XmlAttribute]
        public string DescriptionTextLocalCode { get; set; }

        [XmlAttribute]
        public string LeftOptionTextLocalCode { get; set; }

        [XmlAttribute]
        public string RightOptionTextLocalCode { get; set; }

        public List<CardEffect> LeftEffects { get; set; }

        public List<CardEffect> RightEffects { get; set; }
    }
}
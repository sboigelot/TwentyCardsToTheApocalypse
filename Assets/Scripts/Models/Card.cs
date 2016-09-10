using System.Collections.Generic;
using System.Xml.Serialization;
using Assets.Scripts.Models.Effects;

namespace Assets.Scripts.Models
{
    public class Card
    {
        public Card()
        {
            LeftEffects = new List<CardEffect>();
            RightEffects = new List<CardEffect>();
            CardRequirements = new List<CardRequirement>();
        }

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

        [XmlElement("LeftEffect")]
        public List<CardEffect> LeftEffects { get; set; }

        [XmlElement("RightEffect")]
        public List<CardEffect> RightEffects { get; set; }
        
        [XmlElement("Require")]
        public List<CardRequirement> CardRequirements { get; set; }

        public bool IsValid()
        {
            foreach (var cardRequirement in CardRequirements)
            {
                if (!cardRequirement.IsSatisfied())
                {
                    return false;
                }
            }

            return true;
        }
    }
}
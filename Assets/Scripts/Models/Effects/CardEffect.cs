using System;
using System.Xml.Serialization;

namespace Assets.Scripts.Models.Effects
{
    public class CardEffect
    {
        [XmlAttribute]
        public int TurnDelay { get; set; }

        [XmlAttribute]
        public bool HasDialog { get; set; }

        [XmlAttribute]
        public string DialogSpriteName { get; set; }

        [XmlAttribute]
        public string DialogTextLocalCode { get; set; }

        [XmlAttribute]
        public string TargetName { get; set; }

        [XmlAttribute]
        public int FunctionParam { get; set; }

        [XmlIgnore]
        public CardEffectType EffectType { get; set; }

        [XmlAttribute("CardEffectType")]
        public string XmlEffectType
        {
            get { return Enum.GetName(typeof (CardEffectType), EffectType); }
            set { EffectType = (CardEffectType)Enum.Parse(typeof(CardEffectType), value); }
        }
    }
}
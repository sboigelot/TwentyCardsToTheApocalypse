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

        [XmlAttribute]
        public CardEffectType FunctionName { get; set; }
    }
}
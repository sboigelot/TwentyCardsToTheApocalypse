using System.Xml.Serialization;

namespace Assets.Scripts.Models
{
    public class CardRequirement
    {
        [XmlAttribute]
        public string StatName { get; set; }

        [XmlAttribute]
        public bool IsBiggerThen { get; set; }

        [XmlAttribute]
        public bool IsLesserThen { get; set; }

        [XmlAttribute]
        public int Value { get; set; }

        [XmlAttribute]
        public string ImprovementName { get; set; }
    }
}
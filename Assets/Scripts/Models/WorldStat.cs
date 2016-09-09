using System.Xml.Serialization;

namespace Assets.Scripts.Models
{
    public class WorldStat
    {
        [XmlAttribute]
        public string Name { get; set; }

        [XmlAttribute]
        public string SpriteName { get; set; }

        [XmlAttribute]
        public int Value { get; set; }

        [XmlAttribute]
        public string CurrentMaxOutLocalCode { get; set; }

        [XmlAttribute]
        public string CurrentMinOutLocalCode { get; set; }

        public object Clone()
        {
            return new WorldStat
            {
                Name = Name,
                SpriteName = SpriteName,
                Value = Value,
                CurrentMaxOutLocalCode = CurrentMaxOutLocalCode,
                CurrentMinOutLocalCode = CurrentMinOutLocalCode
            };
        }
    }
}
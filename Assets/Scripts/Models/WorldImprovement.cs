using System;
using System.Xml.Serialization;

namespace Assets.Scripts.Models
{
    public class WorldImprovement
    {
        [XmlAttribute]
        public string Name { get; set; }

        [XmlAttribute]
        public string DescriptionTextLocalCode { get; set; }

        public virtual void OnStatChange(string statName, int value)
        {
            throw new NotImplementedException();
        }

        public object Clone()
        {
            return new WorldImprovement();
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace Assets.Scripts.Models
{
    public class World
    {
        [XmlElement("Stat")]
        public List<WorldStat> Stats { get; set; }

        [XmlElement("Imrpovement")]
        public List<WorldImprovement> Improvements { get; set; }

        public object Clone()
        {
            return new World
            {
                Stats = Stats.Select(s => (WorldStat)s.Clone()).ToList(),
                Improvements = Improvements.Select(i => (WorldImprovement)i.Clone()).ToList()
            };
        }
    }
}
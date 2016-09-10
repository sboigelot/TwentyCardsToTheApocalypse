using System.Linq;
using System.Xml.Serialization;
using Assets.Scripts.Managers;

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
        public bool WorldShouldHaveImprovement { get; set; }

        [XmlAttribute]
        public string ImprovementName { get; set; }

        [XmlAttribute]
        public string ApocalypseName { get; set; }

        public bool IsSatisfied()
        {
            if (!string.IsNullOrEmpty(StatName))
            {
                var stat = GameManager.Instance.World.Stats.FirstOrDefault(s => s.Name == StatName);
                if (stat == null)
                {
                    return false;
                }

                if ((!IsBiggerThen || stat.Value <= Value) && (!IsLesserThen || stat.Value >= Value))
                {
                    return false;
                }
            }

            if (!string.IsNullOrEmpty(ImprovementName))
            {
                if (WorldShouldHaveImprovement)
                {
                    if (GameManager.Instance.World.Improvements.All(i => i.Name != ImprovementName))
                    {
                        return false;
                    }
                }
                else
                {
                    if (GameManager.Instance.World.Improvements.Any(i => i.Name == ImprovementName))
                    {
                        return false;
                    }
                }
            }

            if (!string.IsNullOrEmpty(ApocalypseName))
            {
                if (GameManager.Instance.Apocalypse.Name != ApocalypseName)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
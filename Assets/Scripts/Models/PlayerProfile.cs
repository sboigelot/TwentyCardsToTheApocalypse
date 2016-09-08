using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace Assets.Scripts.Models
{
    public class PlayerProfile : ICloneable
    {
        [XmlAttribute]
        public string Name { get; set; }

        public List<string> UnlockedDeckNames { get; set; }

        public List<string> UnlockedAchievementNames { get; set; }

        public List<string> UnlockedApocalypseNames { get; set; }

        public object Clone()
        {
            return new PlayerProfile
            {
                Name = Name,
                UnlockedDeckNames = UnlockedDeckNames.ToList(),
                UnlockedAchievementNames = UnlockedAchievementNames.ToList(),
                UnlockedApocalypseNames = UnlockedApocalypseNames.ToList(),
            };
        }
    }
}
using System.Collections.Generic;

namespace Assets.Scripts.Models
{
    public class PlayerProfile
    {
        public string Name { get; set; }

        public List<string> UnlockedDeckNames { get; set; }

        public List<string> UnlockedAchievementNames { get; set; }

        public List<string> UnlockedApocalypseNames { get; set; } 
    }
}
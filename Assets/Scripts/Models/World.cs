using System.Collections.Generic;

namespace Assets.Scripts.Models
{
    public class World
    {
        public List<WorldStat> Stats { get; set; }

        public List<WorldImprovement> Improvements { get; set; }
    }
}
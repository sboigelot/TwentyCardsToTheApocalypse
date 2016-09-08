using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.Models
{
    public class World
    {
        public List<WorldStat> Stats { get; set; }

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
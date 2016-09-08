using System.Collections.Generic;

namespace Assets.Scripts.Models
{
    public class Apocalypse
    {
        public string Name { get; set; }

        public const int TurnToEndAllLifeOnEarth = 20;

        public string BackgroundSpriteName { get; set; }

        public string StartupCardname { get; set; }

        public World StartupWorld { get; set; }

        public List<string> AvailableDesckNames { get; set; }
    }
}
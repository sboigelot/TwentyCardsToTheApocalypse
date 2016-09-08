using Assets.Scripts.Models;
using System.Collections.Generic;

namespace Assets.Scripts.Managers
{
    public class GameManager
    {
        public PrototypeData Prototypes { get; set; }

        public List<PlayerProfile> PlayerProfiles { get; set; }

        public GameSession GameSession { get; set; }
    }
}
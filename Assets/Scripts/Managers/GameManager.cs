using Assets.Scripts.Models;
using Boo.Lang;

namespace Assets.Scripts.Managers
{
    public class GameManager
    {
        public PrototypeData Prototypes { get; set; }

        public List<PlayerProfile> PlayerProfiles { get; set; }

        public GameSession GameSession { get; set; }
    }
}
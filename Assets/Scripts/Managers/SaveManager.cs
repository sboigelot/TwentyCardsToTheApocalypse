using System.Collections.Generic;
using Assets.Scripts.Models;

namespace Assets.Scripts.Managers
{
    public class SaveManager : Singleton<SaveManager>
    {
        public List<PlayerProfile> PlayerProfiles { get; set; }
    }
}
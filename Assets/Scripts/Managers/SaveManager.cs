using System.Collections.Generic;
using Assets.Scripts.Models;
using Assets.Scripts.Serialization;

namespace Assets.Scripts.Managers
{
    public class SaveManager : Singleton<SaveManager>
    {
        public PlayerProfile PlayerProfile { get; set; }

        public void LoadProfiles()
        {
            PlayerProfile = DataSerializer.Instance.LoadFromAppData<PlayerProfile>(string.Empty, "Profile.xml");
            if (PlayerProfile == null)
            {
                PlayerProfile = (PlayerProfile)PrototypeManager.Instance.PlayerTemplate.Clone();
                DataSerializer.Instance.SaveToAppData(string.Empty, "Profile.xml", PlayerProfile);
            }
        }
    }
}
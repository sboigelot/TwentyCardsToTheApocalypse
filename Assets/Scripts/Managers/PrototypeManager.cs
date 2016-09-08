using System.Collections.Generic;
using System.IO;
using Assets.Scripts.Models;
using Assets.Scripts.Serialization;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class PrototypeManager : Singleton<PrototypeManager>
    {
        public PrototypeData Prototypes { get; set; }

        public void LoadPrototypes()
        {
            Prototypes = new PrototypeData
            {
                Apocalypses = Load<List<Apocalypse>>("Apocalypses.xml"),
                Decks = Load<List<Deck>>("Decks.xml"),
                PlayerTemplate = Load<PlayerProfile>("PlayerTemplate.xml"),
            };
        }

        private T Load<T>(string fileName) where T : class, new()
        {
            return DataSerializer.Instance.LoadFromStreamingAssets<T>("Data", fileName);
        }
    }
}
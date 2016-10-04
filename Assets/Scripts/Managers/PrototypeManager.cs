using System.Collections.Generic;
using System.IO;
using System.Linq;
using Assets.Scripts.Localization;
using Assets.Scripts.Models;
using Assets.Scripts.Serialization;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class PrototypeManager : Singleton<PrototypeManager>
    {
        public List<Deck> Decks { get; set; }

        public List<Apocalypse> Apocalypses { get; set; }

        public List<WorldImprovement> Improvements { get; set; }
        
        public PlayerProfile PlayerTemplate { get; set; }

        public void LoadPrototypes()
        {
            Apocalypses = Load<List<Apocalypse>>("Apocalypses.xml");
            Decks = Load<List<Deck>>("Decks.xml");
            Improvements = Load<List<WorldImprovement>>("Improvements.xml");
            PlayerTemplate = Load<PlayerProfile>("PlayerTemplate.xml");

            var allCards = Decks.SelectMany(d => d.Cards).ToList();
            Localizer.Instance.EnsureAllLocalKeyExist(allCards);
        }

        private T Load<T>(string fileName) where T : class, new()
        {
            return DataSerializer.Instance.LoadFromStreamingAssets<T>("Data", fileName);
        }
    }
}
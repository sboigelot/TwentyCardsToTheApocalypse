using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Models;

namespace Assets.Scripts.Managers
{
    public class GameManager : Singleton<GameManager>
    {
        public GameSession GameSession { get; set; }

        public void NewGame(Apocalypse apocalypse)
        {
            PlayerProfile player = SaveManager.Instance.PlayerProfile;
            World world = (World) apocalypse.StartupWorld.Clone();

            GameSession = new GameSession
            {
                Apocalypse = apocalypse,
                Player = player,
                TurnToApocalypse = Apocalypse.TurnToEndAllLifeOnEarth,
                World = world,
                DiscardPile = new Deck(),
                CurrentCard = apocalypse.StartupCard
            };

            List<Deck> availableDecks =
                PrototypeManager.Instance.Prototypes.Decks.Where(
                    d => player.UnlockedDeckNames.Contains(d.Name) &&
                         apocalypse.AvailableDeckNames.Contains(d.Name))
                    .ToList();

            GameSession.MixedDeck = Deck.Merge(availableDecks);
            GameSession.MixedDeck.Shuffle();
        }

        public void NextCard()
        {
            if (GameSession.MixedDeck.Cards.Count == 0)
            {
                GameSession.MixedDeck = GameSession.DiscardPile;
                GameSession.MixedDeck.Shuffle();
                GameSession.DiscardPile = new Deck();
            }

            var newCard = GameSession.MixedDeck.Cards.First();
            GameSession.DiscardPile.Cards.Add(newCard);
            GameSession.CurrentCard = newCard;
            GameSession.MixedDeck.Cards.RemoveAt(0);
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Models;
using Assets.Scripts.Models.Effects;

namespace Assets.Scripts.Managers
{
    public class GameManager : Singleton<GameManager>
    {
        public GameManager()
        {
            EffectQueue = new List<CardEffect>();
        }

        public PlayerProfile Player { get; set; }

        public Apocalypse Apocalypse { get; set; }

        public World World { get; set; }

        public int TurnToApocalypse { get; set; }

        public Deck MixedDeck { get; set; }

        public Deck DiscardPile { get; set; }

        public Card CurrentCard { get; set; }

        public List<CardEffect> EffectQueue { get; set; }

        public void NewGame(Apocalypse apocalypse)
        {
            PlayerProfile player = SaveManager.Instance.PlayerProfile;
            World world = (World)apocalypse.StartupWorld.Clone();

            Apocalypse = apocalypse;
            Player = player;
            TurnToApocalypse = Apocalypse.TurnToEndAllLifeOnEarth;
            World = world;
            DiscardPile = new Deck();
            CurrentCard = apocalypse.StartupCard;

            List<Deck> availableDecks =
                PrototypeManager.Instance.Decks.Where(
                    d => player.UnlockedDeckNames.Contains(d.Name) &&
                         apocalypse.AvailableDeckNames.Contains(d.Name))
                    .ToList();

            MixedDeck = Deck.Merge(availableDecks);
            MixedDeck.Shuffle();
        }

        public void EndTurn(bool chooseLeft)
        {
            if (chooseLeft)
            {
                EffectQueue.AddRange(CurrentCard.LeftEffects.Select(e => e.Clone()));
            }
            else
            {
                EffectQueue.AddRange(CurrentCard.RightEffects.Select(e => e.Clone()));
            }

            TurnToApocalypse--;

            TriggerEffects();
            NextCard();
        }

        private void TriggerEffects()
        {
            foreach (var effect in EffectQueue.ToList())
            {
                if (effect.TurnDelay == 0)
                {
                    effect.Trigger();
                    EffectQueue.Remove(effect);
                }
                else
                {
                    effect.TurnDelay--;
                }
            }
        }

        private void NextCard()
        {
            if (MixedDeck.Cards.Count == 0)
            {
                MixedDeck = DiscardPile;
                MixedDeck.Shuffle();
                DiscardPile = new Deck();
            }

            var newCard = MixedDeck.Cards.First();
            DiscardPile.Cards.Add(newCard);
            CurrentCard = newCard;
            MixedDeck.Cards.RemoveAt(0);

            TurnToApocalypse--;
        }
    }
}
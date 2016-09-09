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
            EffectQueue.AddRange(chooseLeft
                ? CurrentCard.LeftEffects.Select(e => e.Clone())
                : CurrentCard.RightEffects.Select(e => e.Clone()));

            if (TriggerEffects())
            {
                return;
            }

            TurnToApocalypse--;

            if (World.Stats.Any(s => s.Value <= 0 || s.Value >= 100) || TurnToApocalypse <= 0)
            {
                GameOver();
                return;
            }

            DrawNextCard();
        }

        private void GameOver()
        {
            CurrentCard = Apocalypse.WolrdEndCard;
            TurnToApocalypse = 0;
        }

        private bool TriggerEffects()
        {
            foreach (var effect in EffectQueue.ToList())
            {
                if (effect.TurnDelay == 0)
                {
                    effect.Trigger();
                    EffectQueue.Remove(effect);

                    if (effect.HasDialog)
                    {
                        CurrentCard = new Card
                        {
                            Name = "EffectDialog",
                            DescriptionTextLocalCode = effect.DialogTextLocalCode,
                            SpriteName = effect.DialogSpriteName,
                            LeftOptionTextLocalCode = "Hem...",
                            RightOptionTextLocalCode = "What!",
                        };

                        return true;
                    }
                }
                else
                {
                    effect.TurnDelay--;
                }
            }

            return false;
        }

        private void DrawNextCard()
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
        }
    }
}
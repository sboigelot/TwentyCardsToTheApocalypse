using System;
using System.Linq;
using System.Xml.Serialization;
using Assets.Scripts.Managers;

namespace Assets.Scripts.Models.Effects
{
    public class CardEffect
    {
        [XmlAttribute]
        public int TurnDelay { get; set; }

        [XmlAttribute]
        public bool HasDialog { get; set; }

        [XmlAttribute]
        public string DialogSpriteName { get; set; }

        [XmlAttribute]
        public string DialogTextLocalCode { get; set; }

        [XmlAttribute]
        public string TargetName { get; set; }

        [XmlAttribute]
        public int FunctionParam { get; set; }

        [XmlIgnore]
        public CardEffectType EffectType { get; set; }

        [XmlAttribute("CardEffectType")]
        public string XmlEffectType
        {
            get { return Enum.GetName(typeof(CardEffectType), EffectType); }
            set { EffectType = (CardEffectType)Enum.Parse(typeof(CardEffectType), value); }
        }

        public CardEffect Clone()
        {
            return new CardEffect
            {
                TurnDelay = TurnDelay,
                HasDialog = HasDialog,
                DialogSpriteName = DialogSpriteName,
                DialogTextLocalCode = DialogTextLocalCode,
                TargetName = TargetName,
                FunctionParam = FunctionParam,
                EffectType = EffectType,
            };
        }

        public bool Trigger()
        {
            var gameManager = GameManager.Instance;
            switch (EffectType)
            {
                case CardEffectType.AffectWorldStat:
                    var stat = gameManager.World.Stats.FirstOrDefault(s => s.Name == TargetName);
                    if (stat != null)
                    {
                        stat.Value += FunctionParam;
                    }

                    break;

                case CardEffectType.PrioritizeCard:
                    var cards = gameManager.MixedDeck.Cards.Where(c => c.Name == TargetName).ToList();
                    foreach (var card in cards)
                    {
                        var oldIndex = gameManager.MixedDeck.Cards.IndexOf(card);
                        var newIndex = Math.Max(
                            0,
                            Math.Min(gameManager.MixedDeck.Cards.Count - 2, oldIndex + FunctionParam));
                        gameManager.MixedDeck.Cards.RemoveAt(oldIndex);
                        gameManager.MixedDeck.Cards.Insert(newIndex, card);
                    }

                    break;

                case CardEffectType.ShuffleDeck:
                    gameManager.MixedDeck.Shuffle();
                    break;

                case CardEffectType.UnlockAchievement:
                    gameManager.Player.UnlockedAchievementNames.Add(TargetName);
                    break;

                case CardEffectType.UnlockApocalypse:
                    gameManager.Player.UnlockedApocalypseNames.Add(TargetName);
                    break;

                case CardEffectType.UnlockDeck:
                    gameManager.Player.UnlockedDeckNames.Add(TargetName);
                    break;

                case CardEffectType.BuildImprovement:
                    gameManager.World.Improvements.Add(new WorldImprovement { Name = TargetName });
                    break;

                case CardEffectType.Victory:
                    gameManager.WindGame();
                    return true;
                    break;
            }

            return false;
        }
    }
}
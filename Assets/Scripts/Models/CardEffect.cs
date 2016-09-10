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

        public void Trigger()
        {
            switch (EffectType)
            {
                case CardEffectType.AffectWorldStat:
                    var stat = GameManager.Instance.World.Stats.FirstOrDefault(s => s.Name == TargetName);
                    if (stat != null)
                    {
                        stat.Value += FunctionParam;
                    }

                    break;

                case CardEffectType.PrioritizeCard:
                    // TODO.
                    break;

                case CardEffectType.ShuffleDeck:
                    GameManager.Instance.MixedDeck.Shuffle();
                    break;

                case CardEffectType.UnlockAchievement:
                    GameManager.Instance.Player.UnlockedAchievementNames.Add(TargetName);
                    break;

                case CardEffectType.UnlockApocalypse:
                    GameManager.Instance.Player.UnlockedApocalypseNames.Add(TargetName);
                    break;

                case CardEffectType.UnlockDeck:
                    GameManager.Instance.Player.UnlockedDeckNames.Add(TargetName);
                    break;
            }
        }
    }
}
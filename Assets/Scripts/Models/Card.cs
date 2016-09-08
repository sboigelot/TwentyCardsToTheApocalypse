using System.Collections.Generic;
using System.Xml.Serialization;
using Assets.Scripts.Models.Effects;

namespace Assets.Scripts.Models
{
    public class Card
    {
        public string Name { get; set; }

        public string SpriteName { get; set; }

        public string DescriptionTextLocalCode { get; set; }

        public string LeftOptionTextLocalCode { get; set; }

        public string RightOptionTextLocalCode { get; set; }

        [XmlArray("LeftEffects")]
        [XmlArrayItem("PrioritizeCardEffect", typeof(PrioritizeCardEffect))]
        [XmlArrayItem("ShuffleCardsCardEffect", typeof(ShuffleCardsCardEffect))]
        [XmlArrayItem("TriggerCardCardEffect", typeof(TriggerCardCardEffect))]
        [XmlArrayItem("UnlockAchievementEffect", typeof(UnlockAchievementEffect))]
        [XmlArrayItem("UnlockApocalypseEffect", typeof(UnlockApocalypseEffect))]
        [XmlArrayItem("UnlockDeckCardEffect", typeof(UnlockDeckCardEffect))]
        public List<CardEffect> LeftEffects { get; set; }

        [XmlArray("RightEffects")]
        [XmlArrayItem("PrioritizeCardEffect", typeof(PrioritizeCardEffect))]
        [XmlArrayItem("ShuffleCardsCardEffect", typeof(ShuffleCardsCardEffect))]
        [XmlArrayItem("TriggerCardCardEffect", typeof(TriggerCardCardEffect))]
        [XmlArrayItem("UnlockAchievementEffect", typeof(UnlockAchievementEffect))]
        [XmlArrayItem("UnlockApocalypseEffect", typeof(UnlockApocalypseEffect))]
        [XmlArrayItem("UnlockDeckCardEffect", typeof(UnlockDeckCardEffect))]
        public List<CardEffect> RightEffects { get; set; }
    }
}
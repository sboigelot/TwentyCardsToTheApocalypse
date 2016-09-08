using System.Collections.Generic;
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

        public List<CardEffect> LeftEffects { get; set; }

        public List<CardEffect> RightEffects { get; set; }
    }
}
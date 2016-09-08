namespace Assets.Scripts.Models.Effects
{
    public abstract class CardEffect
    {
        public int TurnDelay { get; set; }

        public bool HasDialog { get; set; }

        public string DialogSpriteName { get; set; }

        public string DialogTextLocalCode { get; set; }
    }
}
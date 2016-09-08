namespace Assets.Scripts.Models
{
    public class GameSession
    {
        public PlayerProfile Player { get; set; }

        public Apocalypse Apocalypse { get; set; }

        public World World { get; set; }

        public int TurnToApocalypse { get; set; }
    }
}
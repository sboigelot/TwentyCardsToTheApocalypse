using Assets.Scripts.Models;
namespace Assets.Scripts.Managers
{
    public class GameManager : Singleton<GameManager>
    {
        private static GameManager instance;

        public static GameManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameManager();
                }
                return instance;
            }
            set { instance = value; }
        }

        public GameSession GameSession { get; set; }
    }
}
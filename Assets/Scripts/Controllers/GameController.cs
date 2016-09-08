using System.Linq;
using Assets.Scripts.Managers;
using Assets.Scripts.Models;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Controllers
{
    public class GameController : MonoBehaviour
    {
        public Image CardDisplay;

        public Text CardDescription;

        public Text CardFooter;

        public Text TurnCountDown;

        public GameController()
        {
            Instance = this;
        }
        
        public static GameController Instance { get; set; }
        
        public void Awake()
        {
            PrototypeManager.Instance.LoadPrototypes();
            SaveManager.Instance.LoadProfiles();
            GameManager.Instance.NewGame(PrototypeManager.Instance.Prototypes.Apocalypses.First());
            BindUi();
        }

        public void ClickLeft()
        {
            Debug.Log("Click Left");
            GameManager.Instance.NextCard();
            BindUi();
        }

        public void ClickRight()
        {
            Debug.Log("Click Right");
            GameManager.Instance.NextCard();
            BindUi();
        }

        private void BindUi()
        {
            var card = GameManager.Instance.GameSession.CurrentCard;
            CardDescription.text = card.DescriptionTextLocalCode;
            CardFooter.text = card.Name;
            TurnCountDown.text = GameManager.Instance.GameSession.TurnToApocalypse.ToString();
        }
    }
}
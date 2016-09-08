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
        
        public static GameController Instance { get; set; }

        public GameController()
        {
            Instance = this;
        }

        public void Awake()
        {
            PrototypeManager.Instance.LoadPrototypes();
            SaveManager.Instance.LoadProfiles();
            GameManager.Instance.NewGame(PrototypeManager.Instance.Prototypes.Apocalypses.First());
            BindUi();
        }

        private void BindUi()
        {
            var card = GameManager.Instance.GameSession.CurrentCard;
            CardDescription.text = card.DescriptionTextLocalCode;
            CardFooter.text = card.Name;
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
    }
}
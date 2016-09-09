using System.Linq;
using Assets.Scripts.Localization;
using Assets.Scripts.Managers;
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
            GameManager.Instance.NewGame(PrototypeManager.Instance.Apocalypses.First());
            BindUi();
        }

        public void ClickLeft()
        {
            Debug.Log("Click Left");
            GameManager.Instance.EndTurn(true);
            BindUi();
        }

        public void ClickRight()
        {
            Debug.Log("Click Right");
            GameManager.Instance.EndTurn(false);
            BindUi();
        }

        private void BindUi()
        {
            var card = GameManager.Instance.CurrentCard;
            CardDescription.text = Localizer.Get(card.DescriptionTextLocalCode);
            CardFooter.text = Localizer.Get(card.Name);
            TurnCountDown.text = GameManager.Instance.TurnToApocalypse.ToString();
            CardDisplay.sprite = SpriteManager.Get(card.SpriteName);
        }
    }
}
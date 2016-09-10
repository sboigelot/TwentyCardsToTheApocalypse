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

        public Image Stat1Image;

        public Image Stat2Image;

        public Image Stat3Image;

        public Image Stat4Image;

        public Slider Stat1Slider;

        public Slider Stat2Slider;

        public Slider Stat3Slider;

        public Slider Stat4Slider;

        public Gradient SliderColorGradient;

        public GameController()
        {
            Instance = this;
        }

        public static GameController Instance { get; set; }

        public void Awake()
        {
            PrototypeManager.Instance.LoadPrototypes();
            SaveManager.Instance.LoadProfiles();
        }

        public void NewGame()
        {
            GameManager.Instance.NewGame(PrototypeManager.Instance.Apocalypses.First());
            BindUi();
        }

        public void ClickLeft()
        {
            Debug.Log("Click Left");
            Click(true);
        }

        public void ClickRight()
        {
            Debug.Log("Click Right");
            Click(false);
        }

        private void Click(bool left)
        {
            if (GameManager.Instance.CurrentCard == null ||
                GameManager.Instance.Apocalypse == null)
            {
                return;
            }

            if (GameManager.Instance.CurrentCard == GameManager.Instance.Apocalypse.WolrdEndCard)
            {
                DialogBoxController.Instance.SwitchToScreen(DialogBoxController.Instance.EndGameScreen);
            }
            else
            {
                GameManager.Instance.EndTurn(left);
                BindUi();
            }
        }

        private void BindUi()
        {
            var card = GameManager.Instance.CurrentCard;
            var world = GameManager.Instance.World;

            CardDescription.text = Localizer.Get(card.DescriptionTextLocalCode);
            CardFooter.text = Localizer.Get(card.Name);
            TurnCountDown.text = GameManager.Instance.TurnToApocalypse.ToString();
            CardDisplay.sprite = SpriteManager.Get(card.SpriteName);

            Stat1Image.sprite = SpriteManager.Get(world.Stats[0].SpriteName);
            Stat2Image.sprite = SpriteManager.Get(world.Stats[1].SpriteName);
            Stat3Image.sprite = SpriteManager.Get(world.Stats[2].SpriteName);
            Stat4Image.sprite = SpriteManager.Get(world.Stats[3].SpriteName);

            Stat1Slider.value = world.Stats[0].Value;
            Stat2Slider.value = world.Stats[1].Value;
            Stat3Slider.value = world.Stats[2].Value;
            Stat4Slider.value = world.Stats[3].Value;

            Stat1Slider.GetComponentInChildren<Image>().color =
                SliderColorGradient.Evaluate((float)world.Stats[0].Value / 100);
            Stat2Slider.GetComponentInChildren<Image>().color =
                SliderColorGradient.Evaluate((float)world.Stats[1].Value / 100);
            Stat3Slider.GetComponentInChildren<Image>().color =
                SliderColorGradient.Evaluate((float)world.Stats[2].Value / 100);
            Stat4Slider.GetComponentInChildren<Image>().color =
                SliderColorGradient.Evaluate((float)world.Stats[3].Value / 100);
        }
    }
}
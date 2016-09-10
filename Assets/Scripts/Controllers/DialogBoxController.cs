using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class DialogBoxController : MonoBehaviourSingleton<DialogBoxController>
    {
        public GameObject GameScreen;

        public GameObject ChooseProfileScreen;

        public GameObject ChooseApocalypseScreen;

        public GameObject EndGameScreen;
        
        public void Awake()
        {
            SwitchToScreen(ChooseProfileScreen);
        }

        public void SwitchToScreen(GameObject screen)
        {
            GameScreen.SetActive(false);
            ChooseProfileScreen.SetActive(false);
            ChooseApocalypseScreen.SetActive(false);
            EndGameScreen.SetActive(false);
            screen.SetActive(true);
        }
    }
}
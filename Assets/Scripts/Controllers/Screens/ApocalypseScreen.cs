using UnityEngine;

namespace Assets.Scripts.Controllers.Screens
{
    public class ApocalypseScreen : MonoBehaviour
    {
        public void ChooseDefaultApocalypse()
        {
            GameController.Instance.NewGame();
            DialogBoxController.Instance.SwitchToScreen(DialogBoxController.Instance.GameScreen);
        }
    }
}
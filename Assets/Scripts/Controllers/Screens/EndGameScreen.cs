using UnityEngine;

namespace Assets.Scripts.Controllers.Screens
{
    public class EndGameScreen : MonoBehaviour
    {
        public void Close()
        {
            DialogBoxController.Instance.SwitchToScreen(DialogBoxController.Instance.ChooseProfileScreen);
        }
    }
}
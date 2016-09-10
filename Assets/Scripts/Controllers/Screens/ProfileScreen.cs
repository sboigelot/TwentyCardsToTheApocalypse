using UnityEngine;

namespace Assets.Scripts.Controllers.Screens
{
    public class ProfileScreen : MonoBehaviour
    {
        public void ChooseDefaultProfile()
        {
            DialogBoxController.Instance.SwitchToScreen(DialogBoxController.Instance.ChooseApocalypseScreen);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

using System;
using Assets.Scripts.Localization;
using Assets.Scripts.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Controllers
{
    public class MouseController : MonoBehaviour
    {
        public RectTransform CardDisplay;

        public float rotationSpeed;

        public float currentZRotation;

        public AnimationCurve SpeedVariation;

        public Text ChoiceText;

        public void Update()
        {
            Vector2 mousePosition = Input.mousePosition;
            float horizontalMousePosition = mousePosition.x;
            float centerRelatedMouseOffset = horizontalMousePosition - ((float)Screen.width / 2);

            float absoluteDistanceFrom0To1 = Math.Abs(currentZRotation / 20f);
            float curvedSpeed = SpeedVariation.Evaluate(absoluteDistanceFrom0To1);
            float rotation = rotationSpeed * Time.deltaTime * curvedSpeed;

            if (Input.GetMouseButtonUp(0))
            {
                if (centerRelatedMouseOffset < -150f)
                {
                    GameController.Instance.ClickLeft();
                }
                else if (centerRelatedMouseOffset > 150f)
                {
                    GameController.Instance.ClickRight();
                }

                CardDisplay.localRotation = new Quaternion(0f, 0f, 0f, 0f);
                return;
            }

            if (centerRelatedMouseOffset < -150f)
            {
                if (GameManager.Instance.CurrentCard != null)
                {
                    ChoiceText.text = Localizer.Get(GameManager.Instance.CurrentCard.LeftOptionTextLocalCode);
                }

                currentZRotation = Mathf.Max(-20f, currentZRotation - .1f);
                if (currentZRotation > -20f)
                {
                    CardDisplay.Rotate(Vector3.forward, Mathf.Deg2Rad * rotation);
                }
            }
            else if (centerRelatedMouseOffset > 150f)
            {
                if (GameManager.Instance.CurrentCard != null)
                {
                    ChoiceText.text = Localizer.Get(GameManager.Instance.CurrentCard.RightOptionTextLocalCode);
                }

                currentZRotation = Mathf.Min(+20f, currentZRotation + .1f);
                if (currentZRotation < 20f)
                {
                    CardDisplay.Rotate(Vector3.back, Mathf.Deg2Rad * rotation);
                }
            }
        }
    }
}

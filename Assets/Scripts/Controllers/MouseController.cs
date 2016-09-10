using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Localization;
using Assets.Scripts.Managers;
using Assets.Scripts.Models.Effects;
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

        public float centerRelatedMouseOffset;

        public Image Inpact1;

        public Image Inpact3;

        public Image Inpact2;

        public Image Inpact4;

        public AnimationCurve InpactSizePerValueSum;

        public void Update()
        {
            if (GameManager.Instance.CurrentCard == null)
            {
                currentZRotation = 0f;
                CardDisplay.localRotation = new Quaternion(0f, 0f, 0f, 0f);
                return;
            }

            Vector2 mousePosition = Input.mousePosition;
            float horizontalMousePosition = mousePosition.x;
            centerRelatedMouseOffset = horizontalMousePosition - ((float)Screen.width / 2);

            float absoluteDistanceFrom0To1 = Math.Abs(currentZRotation / 10f);
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

                currentZRotation = 0f;
                CardDisplay.localRotation = new Quaternion(0f, 0f, 0f, 0f);
                return;
            }

            if (centerRelatedMouseOffset < -150f)
            {
                UpdateUi(
                    GameManager.Instance.CurrentCard.LeftOptionTextLocalCode,
                    GameManager.Instance.CurrentCard.LeftEffects);

                currentZRotation = Mathf.Max(-10f, currentZRotation - .1f);
                if (currentZRotation > -10f)
                {
                    CardDisplay.Rotate(Vector3.forward, Mathf.Deg2Rad * rotation);
                }
            }
            else if (centerRelatedMouseOffset > 150f)
            {
                UpdateUi(
                    GameManager.Instance.CurrentCard.RightOptionTextLocalCode,
                    GameManager.Instance.CurrentCard.RightEffects);

                currentZRotation = Mathf.Min(+10f, currentZRotation + .1f);
                if (currentZRotation < 10f)
                {
                    CardDisplay.Rotate(Vector3.back, Mathf.Deg2Rad * rotation);
                }
            }
        }

        private void UpdateUi(string textCode, List<CardEffect> effects)
        {
            ChoiceText.text = Localizer.Get(textCode);

            UpdateInpactGuess(Inpact1, effects, GameManager.Instance.World.Stats[0].Name);
            UpdateInpactGuess(Inpact2, effects, GameManager.Instance.World.Stats[1].Name);
            UpdateInpactGuess(Inpact3, effects, GameManager.Instance.World.Stats[2].Name);
            UpdateInpactGuess(Inpact4, effects, GameManager.Instance.World.Stats[3].Name);
        }

        private void UpdateInpactGuess(Image image, List<CardEffect> effects, string statName)
        {
            int realSum = effects.Where(e => e.EffectType == CardEffectType.AffectWorldStat &&
                                             e.TargetName == statName)
                .Sum(e => e.FunctionParam);

            int absSum = Math.Abs(realSum);

            float inpact1Value = InpactSizePerValueSum.Evaluate((float)absSum / 100) * 20;

            image.enabled = absSum != 0;
            RectTransform rt = image.GetComponent(typeof(RectTransform)) as RectTransform;
            rt.sizeDelta = new Vector2(inpact1Value, inpact1Value);
        }
    }
}

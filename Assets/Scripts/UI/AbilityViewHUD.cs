using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class AbilityViewHUD : MonoBehaviour
    {
        [SerializeField] private int index;
        public InputKey inputKey;

        [Header(" CoolDown ")]
        [SerializeField] private Image[] coolDownImages;
        [SerializeField] private TMP_Text coolDownText;
        private float _coolDownFillAmount;
        private Coroutine _coolDownRoutine;

        [Header(" AbilityInput ")] 
        [SerializeField] private Image abilityInputImage;
        private InputModel _inputModel;

        public void Init(InputModel inputModel)
        {
            _inputModel = inputModel;
            abilityInputImage.sprite = _inputModel.enableIcon;
            coolDownText.text = "";
            _coolDownFillAmount = 0f;
        }

        public void StartCoolDown(float coolDown)
        {
            coolDownText.text = coolDown.ToString("0000");
            abilityInputImage.sprite = _inputModel.disableIcon;

            if(_coolDownRoutine!=null)
                StopCoroutine(_coolDownRoutine);
            _coolDownRoutine = StartCoroutine(CoolDownRoutine(coolDown));
        }

        private IEnumerator CoolDownRoutine(float coolDown)
        {
            var timer = coolDown;
            var waitTime = new WaitForFixedUpdate();
            _coolDownFillAmount = timer/coolDown;

            while (timer>=0)
            {
                _coolDownFillAmount = timer/coolDown;
                timer -= Time.deltaTime;
                if(timer>=1)
                    coolDownText.text = timer.ToString("0");
                
                foreach (var iamge in coolDownImages)
                {
                    iamge.fillAmount = _coolDownFillAmount;
                }

                yield return waitTime;
            }
            coolDownText.text = "";
            _coolDownFillAmount = 0f;
            foreach (var iamge in coolDownImages)
            {
                iamge.fillAmount = _coolDownFillAmount;
            }
            abilityInputImage.sprite = _inputModel.enableIcon;
        }
    }
}
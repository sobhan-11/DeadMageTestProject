using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace CoreGame
{
    public class HpBar : MonoBehaviour
    {
        [Header(" UI ")] 
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private Image hpFillImage;

        private Tweener hpTweener;
        [Header(" Config ")] 
        private bool _isActive;

        public void Init()
        {
            hpFillImage.fillAmount = 1;
            canvasGroup.alpha = 0;
            _isActive = false;
        }

        public void SetHpBar(float value,float duration =1f)
        {
            if (!_isActive)
            {
                DOVirtual.Float(0, 1, .5f, (f => canvasGroup.alpha = f))
                    .OnComplete(()=>
                    {
                        _isActive = true;
                        HpTween(value, duration);
                    });
                return;
            }
            HpTween(value, duration);
        }

        private void HpTween(float targetValue, float duration)
        {
            if(hpTweener!=null)
                hpTweener.Kill();
            hpTweener = DOVirtual.Float(hpFillImage.fillAmount, targetValue, duration,
                (value => hpFillImage.fillAmount = value));
        }
    }
}
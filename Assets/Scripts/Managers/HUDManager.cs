using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    private static HUDManager _instance;

    public static HUDManager instance
    {
        get
        {
            if (_instance==null)
            {
                _instance = FindObjectOfType<HUDManager>();
            }

            return _instance;
        }
    }

    private Player player;
    
    [Header(" Avatar "), Space]
    [SerializeField] private CanvasGroup canvasGroup;
    
    [Header(" Avatar "), Space]
    [SerializeField] private Image avatarIcon;   
    
    [Header(" Bars "), Space]
    [SerializeField] private Image hpFillImage;
    [SerializeField] private Image signatureFillImage;
    private Tweener hpTweener;


    public void Init(Player _player)
    {
        player = _player;
        // TODO Set Values
    }

    #region HP-Bar

    public void SetHpBar(float value)
    {
        HpTween(value,1f);
    }
    
    public void SetSignatureBar(float value) => signatureFillImage.fillAmount = value;
    
    private void HpTween(float targetValue, float duration)
    {
        if(hpTweener!=null)
            hpTweener.Kill();
        hpTweener = DOVirtual.Float(hpFillImage.fillAmount, targetValue, duration,
            (value => hpFillImage.fillAmount = value));
    }

    #endregion
}

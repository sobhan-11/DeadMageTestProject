using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UI;
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

    private Controller _controllerModel;
    public ControllerModel model;
    
    [Header(" Avatar "), Space]
    [SerializeField] private CanvasGroup canvasGroup;
    
    [Header(" Avatar "), Space]
    [SerializeField] private Image avatarIcon;   
    
    [Header(" Bars "), Space]
    [SerializeField] private Image hpFillImage;
    [SerializeField] private Image signatureFillImage;
    private Tweener hpTweener;

    [Header(" Abilities ")]
    [SerializeField] private AbilityViewHUD[] abilityViewHuds;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        _controllerModel = model.GetCurrentControllerModel();
        foreach (var abilityView in abilityViewHuds)
        {
            abilityView.Init(_controllerModel.inputModels.FirstOrDefault(i=>i.key==abilityView.inputKey));
        }
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

    #region Ability

    public AbilityViewHUD GetAbilityViewByIndex(int index) => abilityViewHuds[index-1];

    #endregion
}

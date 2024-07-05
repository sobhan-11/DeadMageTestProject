using System;
using System.Collections;
using System.Collections.Generic;
using CoreGame;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Actor
{
    [Header("Components"), Space]
    [SerializeField] private ActionHandler actionHandler;
    [SerializeField] private PlayerInput playerInput;
    private InputHandler _inputHandler;
    private HUDManager _hudManager;

    [Header("Desired Inputs")] 
    private Vector2 moveInput;
    private bool dashInput;
    private bool cast1Input;
    
    private void Start()
    {
        // Set Input for just auth player not others
        ValidateInput();
    }

    private void Update()
    {
        moveInput = _inputHandler.GatherMoveInput();
        dashInput = _inputHandler.GatherDashInput();
        cast1Input = _inputHandler.GatherCast1Input();
    }

    private void FixedUpdate()
    {
        actionHandler.ApplyMove(moveInput);
        actionHandler.HandleDash(dashInput);
        actionHandler.OnCast_1(cast1Input);
    }

    #region Actor
    public override Enum_TeamType TeamType => Enum_TeamType.Wizard;
    
    public override void Init()
    {
        statsHandler.Init(new InitStat()
        {
            maxHP = 150,
            statPercent = 1
        });
        actionHandler.Init(this , animationHandler);
        playerInput.enabled=false;
        
        if (_inputHandler == null) 
            _inputHandler = new InputHandler(playerInput);
        
        _hudManager = HUDManager.instance;
    }

    public override void OnTakeDamage(float damage,float currentHP)
    {
        ShowDamageVisual(damage);
        _hudManager.SetHpBar(currentHP);
    }
    
    private void OnUseSignature(float currentSignature) => _hudManager.SetSignatureBar(currentSignature);

    #endregion

    #region Validation

    private void ValidateInput()
    {
        // TODO Set Player Input Scheme From Settings
        // override players default values
        playerInput.enabled=true;
        playerInput.SwitchCurrentActionMap("CoreGame");
    }

    #endregion
}

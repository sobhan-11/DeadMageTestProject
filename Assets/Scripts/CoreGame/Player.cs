using System;
using System.Collections;
using System.Collections.Generic;
using CoreGame;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Header("Components"), Space] 
    [SerializeField] private ActorHandler actorHandler;
    [SerializeField] private StatsHandler statsHandler;
    [SerializeField] private ActionHandler actionHandler;
    [SerializeField] private PlayerInput playerInput;
    private InputHandler inputHandler;

    [Header("Desired Inputs")] 
    private Vector2 moveInput;

    private void Awake()
    {
        statsHandler.Init(new InitStat()
        {
            maxHP = 150,
            maxMoveSpeed = 5,
            statPercent = 1
        });
        
        actionHandler.Init(new AnimationHandler(GetComponentInChildren<Animator>()));
        
        playerInput.enabled=false;
        
        if (inputHandler == null) 
            inputHandler = new InputHandler(playerInput);
    }

    private void Start()
    {
        // Set Input for just auth player not others
        ValidateInput();
    }

    private void Update()
    {
        moveInput = inputHandler.GatherMoveInput();
    }

    private void FixedUpdate()
    {
        actionHandler.ApplyMove(moveInput);
    }

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

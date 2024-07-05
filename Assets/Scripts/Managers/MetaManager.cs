using System;
using System.Collections;
using System.Collections.Generic;
using CoreGame;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MetaManager : MonoBehaviour
{
    public ControllerModel model;
    public PlayerInput playerInput;
    public InputHandler inputHandler;

    [SerializeField] private MenuCard[] menuCards;
    private int _selectedCenuCardIndex;
    
    private void Awake()
    {
        inputHandler = new InputHandler(playerInput);
        _selectedCenuCardIndex = 0;
        menuCards[_selectedCenuCardIndex].OnSelect();
    }

    public void PlayCoreGame()
    {
        SceneManager.LoadScene(1);
    }
    
    public void QuitApplication()
    {
        Application.Quit();
    }

    public void SelectCard()
    {
        menuCards[_selectedCenuCardIndex].OnSelect();
    }
    
    private void Update()
    {
        if(inputHandler.GatherClickInput())
            menuCards[_selectedCenuCardIndex].button.onClick?.Invoke();
        else if (inputHandler.GatherSwitchUpInput())
        {
            menuCards[_selectedCenuCardIndex].OnDeSelect();
            if (_selectedCenuCardIndex == 0)
                _selectedCenuCardIndex = menuCards.Length - 1;
            else
                _selectedCenuCardIndex--;
            menuCards[_selectedCenuCardIndex].OnSelect();
        }
        else if(inputHandler.GatherSwitchdownInput())
        {
            menuCards[_selectedCenuCardIndex].OnDeSelect();
            if (_selectedCenuCardIndex >= menuCards.Length - 1)
                _selectedCenuCardIndex = 0;
            else
                _selectedCenuCardIndex++;
            menuCards[_selectedCenuCardIndex].OnSelect();
        }
    }

    public void SetController(PlayerInput playerInput)
    {
        switch (playerInput.currentControlScheme)
        {
            default:
            case "MouseKeyboard":
                model.currentControllerType = ControllerType.Keyboard;
                break;
            case "PSController":
                model.currentControllerType = ControllerType.PS;
                break;
            case "XboxController":
                model.currentControllerType = ControllerType.XBOX;
                break;
        }
    }
}

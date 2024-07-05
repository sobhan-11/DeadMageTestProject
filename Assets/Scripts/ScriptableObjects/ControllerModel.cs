using System;
using System.Linq;
using CoreGame;using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ControllerModel",menuName = "Assets/Data")]
public class ControllerModel : ScriptableObject
{
    public ControllerType currentControllerType;
    public Controller[] controllers;

    public Controller GetCurrentControllerModel()
    {
        return controllers.FirstOrDefault(x => x.type == currentControllerType);
    }
}
[Serializable]
public class Controller
{
    public ControllerType type;
    public InputModel[] inputModels;
}
[Serializable]
public class InputModel
{
    public InputKey key;
    public Sprite enableIcon;
    public Sprite disableIcon;
}

public enum ControllerType
{
    None = 0,
    Keyboard = 1,
    XBOX = 2,
    PS = 3
}

public enum InputKey
{
    None = 0,
    Cast1 = 1
}

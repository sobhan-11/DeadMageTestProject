//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/ُScripts/CoreGame/InputSystem/PlayerInputAction.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerInputAction: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputAction()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputAction"",
    ""maps"": [
        {
            ""name"": ""CoreGame"",
            ""id"": ""454b5c79-21b4-47cc-bd98-025df21662be"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""04baabcf-8481-40ae-acd2-27f32ac74cb3"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""6efd340e-bf8a-4f2f-ba44-fd6bf56d557f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Cast1"",
                    ""type"": ""Button"",
                    ""id"": ""8125a7b9-2d52-4b0b-b003-21d6ff07b12e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""d4b37a9b-507f-47e6-9ca7-64522562de72"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""11a1d7f6-f6c8-472f-8bba-4be50e0b66d8"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse&Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""33e13420-3a29-4484-82ef-ddafe53f23c9"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse&Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""6a04995d-9057-4993-961e-2c11288eb78f"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse&Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""c8688e85-b066-420e-99d3-375cc2ee247b"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse&Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""LeftJoysticXBOX"",
                    ""id"": ""6bf288ae-7fa8-4351-a08a-bb4fedb2bc8e"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""da2a169a-8c66-49bc-bec1-7fa9a005bc1e"",
                    ""path"": ""<XInputController>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XboxController"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""d49738ef-e3b0-413d-842b-410c4014a1d9"",
                    ""path"": ""<XInputController>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XboxController"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""a6e82c58-4054-4918-bbd8-716b826f39dc"",
                    ""path"": ""<XInputController>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XboxController"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""d3d7a120-ecc8-433d-b553-ff3e4790616f"",
                    ""path"": ""<XInputController>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XboxController"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""LeftJoysticPS"",
                    ""id"": ""f2710f03-d112-4e75-9883-2d76e52b2078"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""59362b4d-925b-4fc7-9923-856d44f2a8f7"",
                    ""path"": ""<DualShockGamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PSController"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""52362b1f-2cf4-4ccc-a809-cc89b5551510"",
                    ""path"": ""<DualShockGamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PSController"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""fbdec77a-d56b-4ff4-a15d-43f3c68ce142"",
                    ""path"": ""<DualShockGamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PSController"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""42feca29-ce96-4e5d-8ce2-822c30693c65"",
                    ""path"": ""<DualShockGamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PSController"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""42e8b00c-0204-463f-99ae-c3136e629219"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse&Keyboard"",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""06ad05a5-5978-41a9-9a0a-05beedf13949"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XboxController"",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""78190d9e-eba3-4177-bb1e-15d2a10f9c9e"",
                    ""path"": ""<DualShockGamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PSController"",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1ffe7ce7-790e-4a40-8491-50b8c4029a33"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse&Keyboard"",
                    ""action"": ""Cast1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5aa8e4cf-eb4f-4bea-b163-489226b4acbd"",
                    ""path"": ""<XInputController>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XboxController"",
                    ""action"": ""Cast1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f1e27125-b307-4f36-b800-bed6169e0431"",
                    ""path"": ""<DualShockGamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PSController"",
                    ""action"": ""Cast1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Meta"",
            ""id"": ""aabba97d-6ea5-4fd1-b7af-fe969513d901"",
            ""actions"": [
                {
                    ""name"": ""Click"",
                    ""type"": ""Button"",
                    ""id"": ""b3c20ec3-7e36-43e3-9e21-6a333a64cd4a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SwitchUp"",
                    ""type"": ""Button"",
                    ""id"": ""f2006357-129b-4225-97dc-7905175741b0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SwitchDown"",
                    ""type"": ""Button"",
                    ""id"": ""580bd4f6-c348-457d-9b56-4d677aa77618"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""50d6bd84-f02f-4713-a5f7-3ff7c4818514"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse&Keyboard"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""70de3eb9-6b51-40b0-8676-8d376ea4afc0"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XboxController"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2d9cac02-5ddd-4c20-9431-358a9fdc5ef8"",
                    ""path"": ""<DualShockGamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PSController"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2229cc9f-7f3c-4bd8-ab4b-8cd82c47bee6"",
                    ""path"": ""<XInputController>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XboxController"",
                    ""action"": ""SwitchUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4b1ca000-5f24-44f6-a625-0e500f03d0ea"",
                    ""path"": ""<DualShockGamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PSController"",
                    ""action"": ""SwitchUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""24a7e110-8917-4515-afe1-189578335dba"",
                    ""path"": ""<XInputController>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""XboxController"",
                    ""action"": ""SwitchDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""238592ca-e185-4ac7-b04e-91bf0cca04c8"",
                    ""path"": ""<DualShockGamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PSController"",
                    ""action"": ""SwitchDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Mouse&Keyboard"",
            ""bindingGroup"": ""Mouse&Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""XboxController"",
            ""bindingGroup"": ""XboxController"",
            ""devices"": [
                {
                    ""devicePath"": ""<XInputController>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""PSController"",
            ""bindingGroup"": ""PSController"",
            ""devices"": [
                {
                    ""devicePath"": ""<DualShockGamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // CoreGame
        m_CoreGame = asset.FindActionMap("CoreGame", throwIfNotFound: true);
        m_CoreGame_Movement = m_CoreGame.FindAction("Movement", throwIfNotFound: true);
        m_CoreGame_Dash = m_CoreGame.FindAction("Dash", throwIfNotFound: true);
        m_CoreGame_Cast1 = m_CoreGame.FindAction("Cast1", throwIfNotFound: true);
        // Meta
        m_Meta = asset.FindActionMap("Meta", throwIfNotFound: true);
        m_Meta_Click = m_Meta.FindAction("Click", throwIfNotFound: true);
        m_Meta_SwitchUp = m_Meta.FindAction("SwitchUp", throwIfNotFound: true);
        m_Meta_SwitchDown = m_Meta.FindAction("SwitchDown", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // CoreGame
    private readonly InputActionMap m_CoreGame;
    private List<ICoreGameActions> m_CoreGameActionsCallbackInterfaces = new List<ICoreGameActions>();
    private readonly InputAction m_CoreGame_Movement;
    private readonly InputAction m_CoreGame_Dash;
    private readonly InputAction m_CoreGame_Cast1;
    public struct CoreGameActions
    {
        private @PlayerInputAction m_Wrapper;
        public CoreGameActions(@PlayerInputAction wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_CoreGame_Movement;
        public InputAction @Dash => m_Wrapper.m_CoreGame_Dash;
        public InputAction @Cast1 => m_Wrapper.m_CoreGame_Cast1;
        public InputActionMap Get() { return m_Wrapper.m_CoreGame; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CoreGameActions set) { return set.Get(); }
        public void AddCallbacks(ICoreGameActions instance)
        {
            if (instance == null || m_Wrapper.m_CoreGameActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_CoreGameActionsCallbackInterfaces.Add(instance);
            @Movement.started += instance.OnMovement;
            @Movement.performed += instance.OnMovement;
            @Movement.canceled += instance.OnMovement;
            @Dash.started += instance.OnDash;
            @Dash.performed += instance.OnDash;
            @Dash.canceled += instance.OnDash;
            @Cast1.started += instance.OnCast1;
            @Cast1.performed += instance.OnCast1;
            @Cast1.canceled += instance.OnCast1;
        }

        private void UnregisterCallbacks(ICoreGameActions instance)
        {
            @Movement.started -= instance.OnMovement;
            @Movement.performed -= instance.OnMovement;
            @Movement.canceled -= instance.OnMovement;
            @Dash.started -= instance.OnDash;
            @Dash.performed -= instance.OnDash;
            @Dash.canceled -= instance.OnDash;
            @Cast1.started -= instance.OnCast1;
            @Cast1.performed -= instance.OnCast1;
            @Cast1.canceled -= instance.OnCast1;
        }

        public void RemoveCallbacks(ICoreGameActions instance)
        {
            if (m_Wrapper.m_CoreGameActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(ICoreGameActions instance)
        {
            foreach (var item in m_Wrapper.m_CoreGameActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_CoreGameActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public CoreGameActions @CoreGame => new CoreGameActions(this);

    // Meta
    private readonly InputActionMap m_Meta;
    private List<IMetaActions> m_MetaActionsCallbackInterfaces = new List<IMetaActions>();
    private readonly InputAction m_Meta_Click;
    private readonly InputAction m_Meta_SwitchUp;
    private readonly InputAction m_Meta_SwitchDown;
    public struct MetaActions
    {
        private @PlayerInputAction m_Wrapper;
        public MetaActions(@PlayerInputAction wrapper) { m_Wrapper = wrapper; }
        public InputAction @Click => m_Wrapper.m_Meta_Click;
        public InputAction @SwitchUp => m_Wrapper.m_Meta_SwitchUp;
        public InputAction @SwitchDown => m_Wrapper.m_Meta_SwitchDown;
        public InputActionMap Get() { return m_Wrapper.m_Meta; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MetaActions set) { return set.Get(); }
        public void AddCallbacks(IMetaActions instance)
        {
            if (instance == null || m_Wrapper.m_MetaActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_MetaActionsCallbackInterfaces.Add(instance);
            @Click.started += instance.OnClick;
            @Click.performed += instance.OnClick;
            @Click.canceled += instance.OnClick;
            @SwitchUp.started += instance.OnSwitchUp;
            @SwitchUp.performed += instance.OnSwitchUp;
            @SwitchUp.canceled += instance.OnSwitchUp;
            @SwitchDown.started += instance.OnSwitchDown;
            @SwitchDown.performed += instance.OnSwitchDown;
            @SwitchDown.canceled += instance.OnSwitchDown;
        }

        private void UnregisterCallbacks(IMetaActions instance)
        {
            @Click.started -= instance.OnClick;
            @Click.performed -= instance.OnClick;
            @Click.canceled -= instance.OnClick;
            @SwitchUp.started -= instance.OnSwitchUp;
            @SwitchUp.performed -= instance.OnSwitchUp;
            @SwitchUp.canceled -= instance.OnSwitchUp;
            @SwitchDown.started -= instance.OnSwitchDown;
            @SwitchDown.performed -= instance.OnSwitchDown;
            @SwitchDown.canceled -= instance.OnSwitchDown;
        }

        public void RemoveCallbacks(IMetaActions instance)
        {
            if (m_Wrapper.m_MetaActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IMetaActions instance)
        {
            foreach (var item in m_Wrapper.m_MetaActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_MetaActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public MetaActions @Meta => new MetaActions(this);
    private int m_MouseKeyboardSchemeIndex = -1;
    public InputControlScheme MouseKeyboardScheme
    {
        get
        {
            if (m_MouseKeyboardSchemeIndex == -1) m_MouseKeyboardSchemeIndex = asset.FindControlSchemeIndex("Mouse&Keyboard");
            return asset.controlSchemes[m_MouseKeyboardSchemeIndex];
        }
    }
    private int m_XboxControllerSchemeIndex = -1;
    public InputControlScheme XboxControllerScheme
    {
        get
        {
            if (m_XboxControllerSchemeIndex == -1) m_XboxControllerSchemeIndex = asset.FindControlSchemeIndex("XboxController");
            return asset.controlSchemes[m_XboxControllerSchemeIndex];
        }
    }
    private int m_PSControllerSchemeIndex = -1;
    public InputControlScheme PSControllerScheme
    {
        get
        {
            if (m_PSControllerSchemeIndex == -1) m_PSControllerSchemeIndex = asset.FindControlSchemeIndex("PSController");
            return asset.controlSchemes[m_PSControllerSchemeIndex];
        }
    }
    public interface ICoreGameActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
        void OnCast1(InputAction.CallbackContext context);
    }
    public interface IMetaActions
    {
        void OnClick(InputAction.CallbackContext context);
        void OnSwitchUp(InputAction.CallbackContext context);
        void OnSwitchDown(InputAction.CallbackContext context);
    }
}
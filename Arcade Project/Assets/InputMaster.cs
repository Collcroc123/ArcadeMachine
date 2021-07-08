// GENERATED AUTOMATICALLY FROM 'Assets/InputMaster.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputMaster : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputMaster()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputMaster"",
    ""maps"": [
        {
            ""name"": ""User"",
            ""id"": ""f9d78362-db0e-4ff0-a869-4557fe1b396d"",
            ""actions"": [
                {
                    ""name"": ""Up"",
                    ""type"": ""Button"",
                    ""id"": ""539e1a28-08da-460d-aa22-d46fd305b6cb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Down"",
                    ""type"": ""Button"",
                    ""id"": ""e52d1b99-3bba-4973-baea-c24fc3b7eed0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""b5d1d3c9-b48d-471f-9f7d-463ff9e8e712"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Back"",
                    ""type"": ""Button"",
                    ""id"": ""35e74faf-4e54-4986-bd33-05f3db08e315"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Left"",
                    ""type"": ""Button"",
                    ""id"": ""9c1288e4-d880-448e-97dd-66d3bd209b96"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Right"",
                    ""type"": ""Button"",
                    ""id"": ""38c88892-7328-4c49-a330-0990c97bca9a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c74fe456-c4ec-4bd9-aa68-67dfaa3d8bc2"",
                    ""path"": ""<HID::DragonRise Inc.   Generic   USB  Joystick  >/stick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""430a5e25-37db-4c2a-8e7e-bfbafacedcf7"",
                    ""path"": ""<HID::DragonRise Inc.   Generic   USB  Joystick  >/stick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""479eed73-e954-4575-b173-efdcb22c1e07"",
                    ""path"": ""<HID::DragonRise Inc.   Generic   USB  Joystick  >/button2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2361287b-628e-4895-b5fd-32d93bc45cb2"",
                    ""path"": ""<HID::DragonRise Inc.   Generic   USB  Joystick  >/trigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""00acedbc-cbc4-40b7-91f6-3ac03508c304"",
                    ""path"": ""<HID::DragonRise Inc.   Generic   USB  Joystick  >/stick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a8dda430-6b08-405c-9d50-e1e735b1adab"",
                    ""path"": ""<HID::DragonRise Inc.   Generic   USB  Joystick  >/stick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Joystick"",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Joystick"",
            ""bindingGroup"": ""Joystick"",
            ""devices"": [
                {
                    ""devicePath"": ""<HID::DragonRise Inc.   Generic   USB  Joystick  >"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // User
        m_User = asset.FindActionMap("User", throwIfNotFound: true);
        m_User_Up = m_User.FindAction("Up", throwIfNotFound: true);
        m_User_Down = m_User.FindAction("Down", throwIfNotFound: true);
        m_User_Select = m_User.FindAction("Select", throwIfNotFound: true);
        m_User_Back = m_User.FindAction("Back", throwIfNotFound: true);
        m_User_Left = m_User.FindAction("Left", throwIfNotFound: true);
        m_User_Right = m_User.FindAction("Right", throwIfNotFound: true);
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

    // User
    private readonly InputActionMap m_User;
    private IUserActions m_UserActionsCallbackInterface;
    private readonly InputAction m_User_Up;
    private readonly InputAction m_User_Down;
    private readonly InputAction m_User_Select;
    private readonly InputAction m_User_Back;
    private readonly InputAction m_User_Left;
    private readonly InputAction m_User_Right;
    public struct UserActions
    {
        private @InputMaster m_Wrapper;
        public UserActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @Up => m_Wrapper.m_User_Up;
        public InputAction @Down => m_Wrapper.m_User_Down;
        public InputAction @Select => m_Wrapper.m_User_Select;
        public InputAction @Back => m_Wrapper.m_User_Back;
        public InputAction @Left => m_Wrapper.m_User_Left;
        public InputAction @Right => m_Wrapper.m_User_Right;
        public InputActionMap Get() { return m_Wrapper.m_User; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UserActions set) { return set.Get(); }
        public void SetCallbacks(IUserActions instance)
        {
            if (m_Wrapper.m_UserActionsCallbackInterface != null)
            {
                @Up.started -= m_Wrapper.m_UserActionsCallbackInterface.OnUp;
                @Up.performed -= m_Wrapper.m_UserActionsCallbackInterface.OnUp;
                @Up.canceled -= m_Wrapper.m_UserActionsCallbackInterface.OnUp;
                @Down.started -= m_Wrapper.m_UserActionsCallbackInterface.OnDown;
                @Down.performed -= m_Wrapper.m_UserActionsCallbackInterface.OnDown;
                @Down.canceled -= m_Wrapper.m_UserActionsCallbackInterface.OnDown;
                @Select.started -= m_Wrapper.m_UserActionsCallbackInterface.OnSelect;
                @Select.performed -= m_Wrapper.m_UserActionsCallbackInterface.OnSelect;
                @Select.canceled -= m_Wrapper.m_UserActionsCallbackInterface.OnSelect;
                @Back.started -= m_Wrapper.m_UserActionsCallbackInterface.OnBack;
                @Back.performed -= m_Wrapper.m_UserActionsCallbackInterface.OnBack;
                @Back.canceled -= m_Wrapper.m_UserActionsCallbackInterface.OnBack;
                @Left.started -= m_Wrapper.m_UserActionsCallbackInterface.OnLeft;
                @Left.performed -= m_Wrapper.m_UserActionsCallbackInterface.OnLeft;
                @Left.canceled -= m_Wrapper.m_UserActionsCallbackInterface.OnLeft;
                @Right.started -= m_Wrapper.m_UserActionsCallbackInterface.OnRight;
                @Right.performed -= m_Wrapper.m_UserActionsCallbackInterface.OnRight;
                @Right.canceled -= m_Wrapper.m_UserActionsCallbackInterface.OnRight;
            }
            m_Wrapper.m_UserActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Up.started += instance.OnUp;
                @Up.performed += instance.OnUp;
                @Up.canceled += instance.OnUp;
                @Down.started += instance.OnDown;
                @Down.performed += instance.OnDown;
                @Down.canceled += instance.OnDown;
                @Select.started += instance.OnSelect;
                @Select.performed += instance.OnSelect;
                @Select.canceled += instance.OnSelect;
                @Back.started += instance.OnBack;
                @Back.performed += instance.OnBack;
                @Back.canceled += instance.OnBack;
                @Left.started += instance.OnLeft;
                @Left.performed += instance.OnLeft;
                @Left.canceled += instance.OnLeft;
                @Right.started += instance.OnRight;
                @Right.performed += instance.OnRight;
                @Right.canceled += instance.OnRight;
            }
        }
    }
    public UserActions @User => new UserActions(this);
    private int m_JoystickSchemeIndex = -1;
    public InputControlScheme JoystickScheme
    {
        get
        {
            if (m_JoystickSchemeIndex == -1) m_JoystickSchemeIndex = asset.FindControlSchemeIndex("Joystick");
            return asset.controlSchemes[m_JoystickSchemeIndex];
        }
    }
    public interface IUserActions
    {
        void OnUp(InputAction.CallbackContext context);
        void OnDown(InputAction.CallbackContext context);
        void OnSelect(InputAction.CallbackContext context);
        void OnBack(InputAction.CallbackContext context);
        void OnLeft(InputAction.CallbackContext context);
        void OnRight(InputAction.CallbackContext context);
    }
}

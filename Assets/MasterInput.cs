// GENERATED AUTOMATICALLY FROM 'Assets/MasterInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @MasterInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @MasterInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MasterInput"",
    ""maps"": [
        {
            ""name"": ""PlayerMap"",
            ""id"": ""95f04c48-1db5-464f-bbb4-400cc4ba1b86"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""de0aa27c-7574-4521-86d4-de3fc1ef42c9"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Value"",
                    ""id"": ""eec30c4c-592e-4c0f-b7ff-49c84697c2ab"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Cannon"",
                    ""type"": ""Button"",
                    ""id"": ""9c4b5bd3-ed19-4046-b42a-dba6e91ac41f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shield"",
                    ""type"": ""Button"",
                    ""id"": ""c52584f2-6bbe-42fc-bd8f-92a76a97823f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SiegeMode"",
                    ""type"": ""Button"",
                    ""id"": ""e569fdc0-473c-40d3-ad8e-6937ddff3156"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LockRate"",
                    ""type"": ""Button"",
                    ""id"": ""3d83bcc2-fcf4-42d3-92b5-75d47943b0d9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""4cae4809-b60f-4aa8-aa89-04ca3b9f6c7c"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8a9b78e2-ef7d-4e5c-acb8-63bfba564cf6"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""29d4077b-3d9a-4285-ba46-7f33467b9e4e"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cannon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""63be586d-6afa-4e6e-949c-8e47a5248616"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shield"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5d96e484-7490-44c9-94a5-580360d3194d"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SiegeMode"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""14ad76dd-e1df-49f5-b25a-dbc5f707a284"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SiegeMode"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""742af685-62dd-4bfa-b043-64804adc0ac1"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LockRate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""MenuMap"",
            ""id"": ""574eb09f-57fa-4334-9370-5dc494bdc6ea"",
            ""actions"": [
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""2e9ef95a-ccae-4374-b110-5cf12c06eb32"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Back"",
                    ""type"": ""Button"",
                    ""id"": ""f27510b4-7a99-47d3-8c68-487cdab7c73c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Up"",
                    ""type"": ""Button"",
                    ""id"": ""ef7d370d-574b-47e2-a4ed-2e44a4e18844"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Down"",
                    ""type"": ""Button"",
                    ""id"": ""addc30e5-b8a5-451b-867d-d2b7a9a2b572"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f55b696a-4316-4445-95fc-d34b4a683071"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""78e3d23c-19f5-4d4e-81b2-8b526a3e490b"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f22c58e0-d726-49a3-9d0d-394d046daf9e"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a0849ca8-69b8-42c2-97f6-e0e654c7b03b"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""985a0a82-7119-4810-bd83-a15e38ceea53"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9e1acfb0-16a9-4dea-9a5a-918840fb52c5"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerMap
        m_PlayerMap = asset.FindActionMap("PlayerMap", throwIfNotFound: true);
        m_PlayerMap_Move = m_PlayerMap.FindAction("Move", throwIfNotFound: true);
        m_PlayerMap_Rotate = m_PlayerMap.FindAction("Rotate", throwIfNotFound: true);
        m_PlayerMap_Cannon = m_PlayerMap.FindAction("Cannon", throwIfNotFound: true);
        m_PlayerMap_Shield = m_PlayerMap.FindAction("Shield", throwIfNotFound: true);
        m_PlayerMap_SiegeMode = m_PlayerMap.FindAction("SiegeMode", throwIfNotFound: true);
        m_PlayerMap_LockRate = m_PlayerMap.FindAction("LockRate", throwIfNotFound: true);
        // MenuMap
        m_MenuMap = asset.FindActionMap("MenuMap", throwIfNotFound: true);
        m_MenuMap_Select = m_MenuMap.FindAction("Select", throwIfNotFound: true);
        m_MenuMap_Back = m_MenuMap.FindAction("Back", throwIfNotFound: true);
        m_MenuMap_Up = m_MenuMap.FindAction("Up", throwIfNotFound: true);
        m_MenuMap_Down = m_MenuMap.FindAction("Down", throwIfNotFound: true);
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

    // PlayerMap
    private readonly InputActionMap m_PlayerMap;
    private IPlayerMapActions m_PlayerMapActionsCallbackInterface;
    private readonly InputAction m_PlayerMap_Move;
    private readonly InputAction m_PlayerMap_Rotate;
    private readonly InputAction m_PlayerMap_Cannon;
    private readonly InputAction m_PlayerMap_Shield;
    private readonly InputAction m_PlayerMap_SiegeMode;
    private readonly InputAction m_PlayerMap_LockRate;
    public struct PlayerMapActions
    {
        private @MasterInput m_Wrapper;
        public PlayerMapActions(@MasterInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_PlayerMap_Move;
        public InputAction @Rotate => m_Wrapper.m_PlayerMap_Rotate;
        public InputAction @Cannon => m_Wrapper.m_PlayerMap_Cannon;
        public InputAction @Shield => m_Wrapper.m_PlayerMap_Shield;
        public InputAction @SiegeMode => m_Wrapper.m_PlayerMap_SiegeMode;
        public InputAction @LockRate => m_Wrapper.m_PlayerMap_LockRate;
        public InputActionMap Get() { return m_Wrapper.m_PlayerMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerMapActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerMapActions instance)
        {
            if (m_Wrapper.m_PlayerMapActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnMove;
                @Rotate.started -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnRotate;
                @Rotate.performed -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnRotate;
                @Rotate.canceled -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnRotate;
                @Cannon.started -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnCannon;
                @Cannon.performed -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnCannon;
                @Cannon.canceled -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnCannon;
                @Shield.started -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnShield;
                @Shield.performed -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnShield;
                @Shield.canceled -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnShield;
                @SiegeMode.started -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnSiegeMode;
                @SiegeMode.performed -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnSiegeMode;
                @SiegeMode.canceled -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnSiegeMode;
                @LockRate.started -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnLockRate;
                @LockRate.performed -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnLockRate;
                @LockRate.canceled -= m_Wrapper.m_PlayerMapActionsCallbackInterface.OnLockRate;
            }
            m_Wrapper.m_PlayerMapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Rotate.started += instance.OnRotate;
                @Rotate.performed += instance.OnRotate;
                @Rotate.canceled += instance.OnRotate;
                @Cannon.started += instance.OnCannon;
                @Cannon.performed += instance.OnCannon;
                @Cannon.canceled += instance.OnCannon;
                @Shield.started += instance.OnShield;
                @Shield.performed += instance.OnShield;
                @Shield.canceled += instance.OnShield;
                @SiegeMode.started += instance.OnSiegeMode;
                @SiegeMode.performed += instance.OnSiegeMode;
                @SiegeMode.canceled += instance.OnSiegeMode;
                @LockRate.started += instance.OnLockRate;
                @LockRate.performed += instance.OnLockRate;
                @LockRate.canceled += instance.OnLockRate;
            }
        }
    }
    public PlayerMapActions @PlayerMap => new PlayerMapActions(this);

    // MenuMap
    private readonly InputActionMap m_MenuMap;
    private IMenuMapActions m_MenuMapActionsCallbackInterface;
    private readonly InputAction m_MenuMap_Select;
    private readonly InputAction m_MenuMap_Back;
    private readonly InputAction m_MenuMap_Up;
    private readonly InputAction m_MenuMap_Down;
    public struct MenuMapActions
    {
        private @MasterInput m_Wrapper;
        public MenuMapActions(@MasterInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Select => m_Wrapper.m_MenuMap_Select;
        public InputAction @Back => m_Wrapper.m_MenuMap_Back;
        public InputAction @Up => m_Wrapper.m_MenuMap_Up;
        public InputAction @Down => m_Wrapper.m_MenuMap_Down;
        public InputActionMap Get() { return m_Wrapper.m_MenuMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenuMapActions set) { return set.Get(); }
        public void SetCallbacks(IMenuMapActions instance)
        {
            if (m_Wrapper.m_MenuMapActionsCallbackInterface != null)
            {
                @Select.started -= m_Wrapper.m_MenuMapActionsCallbackInterface.OnSelect;
                @Select.performed -= m_Wrapper.m_MenuMapActionsCallbackInterface.OnSelect;
                @Select.canceled -= m_Wrapper.m_MenuMapActionsCallbackInterface.OnSelect;
                @Back.started -= m_Wrapper.m_MenuMapActionsCallbackInterface.OnBack;
                @Back.performed -= m_Wrapper.m_MenuMapActionsCallbackInterface.OnBack;
                @Back.canceled -= m_Wrapper.m_MenuMapActionsCallbackInterface.OnBack;
                @Up.started -= m_Wrapper.m_MenuMapActionsCallbackInterface.OnUp;
                @Up.performed -= m_Wrapper.m_MenuMapActionsCallbackInterface.OnUp;
                @Up.canceled -= m_Wrapper.m_MenuMapActionsCallbackInterface.OnUp;
                @Down.started -= m_Wrapper.m_MenuMapActionsCallbackInterface.OnDown;
                @Down.performed -= m_Wrapper.m_MenuMapActionsCallbackInterface.OnDown;
                @Down.canceled -= m_Wrapper.m_MenuMapActionsCallbackInterface.OnDown;
            }
            m_Wrapper.m_MenuMapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Select.started += instance.OnSelect;
                @Select.performed += instance.OnSelect;
                @Select.canceled += instance.OnSelect;
                @Back.started += instance.OnBack;
                @Back.performed += instance.OnBack;
                @Back.canceled += instance.OnBack;
                @Up.started += instance.OnUp;
                @Up.performed += instance.OnUp;
                @Up.canceled += instance.OnUp;
                @Down.started += instance.OnDown;
                @Down.performed += instance.OnDown;
                @Down.canceled += instance.OnDown;
            }
        }
    }
    public MenuMapActions @MenuMap => new MenuMapActions(this);
    public interface IPlayerMapActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnRotate(InputAction.CallbackContext context);
        void OnCannon(InputAction.CallbackContext context);
        void OnShield(InputAction.CallbackContext context);
        void OnSiegeMode(InputAction.CallbackContext context);
        void OnLockRate(InputAction.CallbackContext context);
    }
    public interface IMenuMapActions
    {
        void OnSelect(InputAction.CallbackContext context);
        void OnBack(InputAction.CallbackContext context);
        void OnUp(InputAction.CallbackContext context);
        void OnDown(InputAction.CallbackContext context);
    }
}

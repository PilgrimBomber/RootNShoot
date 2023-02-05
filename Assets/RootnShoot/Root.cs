// GENERATED AUTOMATICALLY FROM 'Assets/RootnShoot/Root.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Root : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Root()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Root"",
    ""maps"": [
        {
            ""name"": ""Roots"",
            ""id"": ""31ad95c6-c741-4ab3-a7fe-41c5cef5a240"",
            ""actions"": [
                {
                    ""name"": ""NavUp"",
                    ""type"": ""Button"",
                    ""id"": ""aa4e5fb9-ab07-4e2a-804e-8fa50a7e5515"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""NavDown"",
                    ""type"": ""Button"",
                    ""id"": ""6d403c0f-abaf-40d8-810e-299a7747f355"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""NavLeft"",
                    ""type"": ""Button"",
                    ""id"": ""fcfdcc4f-3f22-4dd8-9893-d05a5221d1d3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""NavRight"",
                    ""type"": ""Button"",
                    ""id"": ""6153d998-fca2-4162-bf28-16e21b985e29"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Charge"",
                    ""type"": ""PassThrough"",
                    ""id"": ""7f861867-5368-4d26-a9bc-276f2cc244a7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""46a5e254-e46c-474a-ab88-a62cc3dc2765"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c2de1f53-bf2f-4b34-8afb-dd0fbd7215d8"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NavUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a7eb697a-47b2-4bdd-8e7b-dfa72dad83f0"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NavDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""07bc3a83-0c4c-40c0-b34e-adfd6acdcff5"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NavLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b4191962-d58c-43d2-989f-ea45b16ea520"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NavRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""eca25a1a-ea91-45ec-86cf-7dafa94b70b1"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Charge"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8f00a3b4-7848-45d9-b8f9-8c504ac81fec"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Menu"",
            ""id"": ""801974a5-9cae-4148-b485-37d36b5f9f73"",
            ""actions"": [],
            ""bindings"": []
        }
    ],
    ""controlSchemes"": []
}");
        // Roots
        m_Roots = asset.FindActionMap("Roots", throwIfNotFound: true);
        m_Roots_NavUp = m_Roots.FindAction("NavUp", throwIfNotFound: true);
        m_Roots_NavDown = m_Roots.FindAction("NavDown", throwIfNotFound: true);
        m_Roots_NavLeft = m_Roots.FindAction("NavLeft", throwIfNotFound: true);
        m_Roots_NavRight = m_Roots.FindAction("NavRight", throwIfNotFound: true);
        m_Roots_Charge = m_Roots.FindAction("Charge", throwIfNotFound: true);
        m_Roots_Pause = m_Roots.FindAction("Pause", throwIfNotFound: true);
        // Menu
        m_Menu = asset.FindActionMap("Menu", throwIfNotFound: true);
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

    // Roots
    private readonly InputActionMap m_Roots;
    private IRootsActions m_RootsActionsCallbackInterface;
    private readonly InputAction m_Roots_NavUp;
    private readonly InputAction m_Roots_NavDown;
    private readonly InputAction m_Roots_NavLeft;
    private readonly InputAction m_Roots_NavRight;
    private readonly InputAction m_Roots_Charge;
    private readonly InputAction m_Roots_Pause;
    public struct RootsActions
    {
        private @Root m_Wrapper;
        public RootsActions(@Root wrapper) { m_Wrapper = wrapper; }
        public InputAction @NavUp => m_Wrapper.m_Roots_NavUp;
        public InputAction @NavDown => m_Wrapper.m_Roots_NavDown;
        public InputAction @NavLeft => m_Wrapper.m_Roots_NavLeft;
        public InputAction @NavRight => m_Wrapper.m_Roots_NavRight;
        public InputAction @Charge => m_Wrapper.m_Roots_Charge;
        public InputAction @Pause => m_Wrapper.m_Roots_Pause;
        public InputActionMap Get() { return m_Wrapper.m_Roots; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(RootsActions set) { return set.Get(); }
        public void SetCallbacks(IRootsActions instance)
        {
            if (m_Wrapper.m_RootsActionsCallbackInterface != null)
            {
                @NavUp.started -= m_Wrapper.m_RootsActionsCallbackInterface.OnNavUp;
                @NavUp.performed -= m_Wrapper.m_RootsActionsCallbackInterface.OnNavUp;
                @NavUp.canceled -= m_Wrapper.m_RootsActionsCallbackInterface.OnNavUp;
                @NavDown.started -= m_Wrapper.m_RootsActionsCallbackInterface.OnNavDown;
                @NavDown.performed -= m_Wrapper.m_RootsActionsCallbackInterface.OnNavDown;
                @NavDown.canceled -= m_Wrapper.m_RootsActionsCallbackInterface.OnNavDown;
                @NavLeft.started -= m_Wrapper.m_RootsActionsCallbackInterface.OnNavLeft;
                @NavLeft.performed -= m_Wrapper.m_RootsActionsCallbackInterface.OnNavLeft;
                @NavLeft.canceled -= m_Wrapper.m_RootsActionsCallbackInterface.OnNavLeft;
                @NavRight.started -= m_Wrapper.m_RootsActionsCallbackInterface.OnNavRight;
                @NavRight.performed -= m_Wrapper.m_RootsActionsCallbackInterface.OnNavRight;
                @NavRight.canceled -= m_Wrapper.m_RootsActionsCallbackInterface.OnNavRight;
                @Charge.started -= m_Wrapper.m_RootsActionsCallbackInterface.OnCharge;
                @Charge.performed -= m_Wrapper.m_RootsActionsCallbackInterface.OnCharge;
                @Charge.canceled -= m_Wrapper.m_RootsActionsCallbackInterface.OnCharge;
                @Pause.started -= m_Wrapper.m_RootsActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_RootsActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_RootsActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_RootsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @NavUp.started += instance.OnNavUp;
                @NavUp.performed += instance.OnNavUp;
                @NavUp.canceled += instance.OnNavUp;
                @NavDown.started += instance.OnNavDown;
                @NavDown.performed += instance.OnNavDown;
                @NavDown.canceled += instance.OnNavDown;
                @NavLeft.started += instance.OnNavLeft;
                @NavLeft.performed += instance.OnNavLeft;
                @NavLeft.canceled += instance.OnNavLeft;
                @NavRight.started += instance.OnNavRight;
                @NavRight.performed += instance.OnNavRight;
                @NavRight.canceled += instance.OnNavRight;
                @Charge.started += instance.OnCharge;
                @Charge.performed += instance.OnCharge;
                @Charge.canceled += instance.OnCharge;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public RootsActions @Roots => new RootsActions(this);

    // Menu
    private readonly InputActionMap m_Menu;
    private IMenuActions m_MenuActionsCallbackInterface;
    public struct MenuActions
    {
        private @Root m_Wrapper;
        public MenuActions(@Root wrapper) { m_Wrapper = wrapper; }
        public InputActionMap Get() { return m_Wrapper.m_Menu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenuActions set) { return set.Get(); }
        public void SetCallbacks(IMenuActions instance)
        {
            if (m_Wrapper.m_MenuActionsCallbackInterface != null)
            {
            }
            m_Wrapper.m_MenuActionsCallbackInterface = instance;
            if (instance != null)
            {
            }
        }
    }
    public MenuActions @Menu => new MenuActions(this);
    public interface IRootsActions
    {
        void OnNavUp(InputAction.CallbackContext context);
        void OnNavDown(InputAction.CallbackContext context);
        void OnNavLeft(InputAction.CallbackContext context);
        void OnNavRight(InputAction.CallbackContext context);
        void OnCharge(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
    }
    public interface IMenuActions
    {
    }
}

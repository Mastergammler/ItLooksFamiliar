// GENERATED AUTOMATICALLY FROM 'Assets/Project/DefaultControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @DefaultControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @DefaultControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""DefaultControls"",
    ""maps"": [
        {
            ""name"": ""Keyboard"",
            ""id"": ""d7b51404-d56d-433c-bc07-b05904fa9808"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""51540e40-76bc-42b9-8661-1fbe1a3b4e43"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Inventory"",
                    ""type"": ""Button"",
                    ""id"": ""50acbec2-dabd-4380-8ab2-d80cd8c64201"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Ship"",
                    ""type"": ""Button"",
                    ""id"": ""ab04ada4-1545-482b-ab29-7f9007115195"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector - WASD"",
                    ""id"": ""a7ca9a9e-8384-4013-b5f8-9f67540b88c4"",
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
                    ""id"": ""4fdeeb5b-0e3d-4b0c-8a04-9f63611a670d"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""b7ef82e1-5a6e-4a8f-b665-3e1d01a69878"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""ef062536-9fe6-48d1-bd2c-c4390bd59315"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""22f5e5aa-7a02-43a1-b4ed-2b64d5b4e3bc"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""ee6163ac-63e2-4ab9-b26d-cd44f880d234"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Inventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b6fca436-9764-4788-b729-f5efca454033"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Inventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""61e9cfbd-f651-47b8-bb96-ea6c2419f903"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ship"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Keyboard
        m_Keyboard = asset.FindActionMap("Keyboard", throwIfNotFound: true);
        m_Keyboard_Movement = m_Keyboard.FindAction("Movement", throwIfNotFound: true);
        m_Keyboard_Inventory = m_Keyboard.FindAction("Inventory", throwIfNotFound: true);
        m_Keyboard_Ship = m_Keyboard.FindAction("Ship", throwIfNotFound: true);
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

    // Keyboard
    private readonly InputActionMap m_Keyboard;
    private IKeyboardActions m_KeyboardActionsCallbackInterface;
    private readonly InputAction m_Keyboard_Movement;
    private readonly InputAction m_Keyboard_Inventory;
    private readonly InputAction m_Keyboard_Ship;
    public struct KeyboardActions
    {
        private @DefaultControls m_Wrapper;
        public KeyboardActions(@DefaultControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Keyboard_Movement;
        public InputAction @Inventory => m_Wrapper.m_Keyboard_Inventory;
        public InputAction @Ship => m_Wrapper.m_Keyboard_Ship;
        public InputActionMap Get() { return m_Wrapper.m_Keyboard; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(KeyboardActions set) { return set.Get(); }
        public void SetCallbacks(IKeyboardActions instance)
        {
            if (m_Wrapper.m_KeyboardActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnMovement;
                @Inventory.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnInventory;
                @Inventory.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnInventory;
                @Inventory.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnInventory;
                @Ship.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnShip;
                @Ship.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnShip;
                @Ship.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnShip;
            }
            m_Wrapper.m_KeyboardActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Inventory.started += instance.OnInventory;
                @Inventory.performed += instance.OnInventory;
                @Inventory.canceled += instance.OnInventory;
                @Ship.started += instance.OnShip;
                @Ship.performed += instance.OnShip;
                @Ship.canceled += instance.OnShip;
            }
        }
    }
    public KeyboardActions @Keyboard => new KeyboardActions(this);
    public interface IKeyboardActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnInventory(InputAction.CallbackContext context);
        void OnShip(InputAction.CallbackContext context);
    }
}

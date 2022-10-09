//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Internal/Inputs/Ship/HelmControls.inputactions
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

public partial class @HelmControls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @HelmControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""HelmControls"",
    ""maps"": [
        {
            ""name"": ""Main"",
            ""id"": ""a0cb71f4-e993-4f0a-912a-58d19e3c828b"",
            ""actions"": [
                {
                    ""name"": ""Exit"",
                    ""type"": ""Button"",
                    ""id"": ""e7a1502e-4fe7-4ed5-a29c-8887db4df508"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Steer"",
                    ""type"": ""PassThrough"",
                    ""id"": ""438999d7-ff35-4640-849f-2342b5d0324a"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ModifySails"",
                    ""type"": ""PassThrough"",
                    ""id"": ""ff712c13-1b39-42ff-a12a-ee270cc90caa"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""68d7406e-5f4f-4548-a673-aabb6b2dba45"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Exit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""113e8dda-c5a9-4e50-a836-64ba25e4cab5"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Steer"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""ad45069c-e433-4875-8a56-4a1cdfe4b205"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Steer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""4be8e574-e667-4280-9909-b2253f3eeff1"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Steer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""306fd08b-9bf4-4d29-b0f2-af377043e3cd"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Steer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""e4f63ebe-157e-419a-bc09-e963c62da3ca"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Steer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""1af122a3-ed3a-4f88-ab1d-0cb4fc595a3e"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ModifySails"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""f23c1cdc-be12-4251-8a9a-e07070e264a0"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ModifySails"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""bae3ddfd-35e1-4f19-8d40-047d87c24a1e"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ModifySails"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""bd2df54b-eca5-4f80-b0b7-1916a07beb37"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ModifySails"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""131755b4-70b5-473e-af19-5e3431eb7d74"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ModifySails"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""f4ac0482-a26b-4132-ae30-9bf0563a6d6f"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ModifySails"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""d0e28ee5-4d75-4bb3-bb02-f250f5948a3a"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ModifySails"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""2a2e7a0a-8f62-4218-9330-26521d06dca2"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ModifySails"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""02d5fb1d-f6b4-493c-8c62-21252858dd7b"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ModifySails"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""784cc7b5-e471-4f1f-af3f-5357957a0666"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ModifySails"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Main
        m_Main = asset.FindActionMap("Main", throwIfNotFound: true);
        m_Main_Exit = m_Main.FindAction("Exit", throwIfNotFound: true);
        m_Main_Steer = m_Main.FindAction("Steer", throwIfNotFound: true);
        m_Main_ModifySails = m_Main.FindAction("ModifySails", throwIfNotFound: true);
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

    // Main
    private readonly InputActionMap m_Main;
    private IMainActions m_MainActionsCallbackInterface;
    private readonly InputAction m_Main_Exit;
    private readonly InputAction m_Main_Steer;
    private readonly InputAction m_Main_ModifySails;
    public struct MainActions
    {
        private @HelmControls m_Wrapper;
        public MainActions(@HelmControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Exit => m_Wrapper.m_Main_Exit;
        public InputAction @Steer => m_Wrapper.m_Main_Steer;
        public InputAction @ModifySails => m_Wrapper.m_Main_ModifySails;
        public InputActionMap Get() { return m_Wrapper.m_Main; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MainActions set) { return set.Get(); }
        public void SetCallbacks(IMainActions instance)
        {
            if (m_Wrapper.m_MainActionsCallbackInterface != null)
            {
                @Exit.started -= m_Wrapper.m_MainActionsCallbackInterface.OnExit;
                @Exit.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnExit;
                @Exit.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnExit;
                @Steer.started -= m_Wrapper.m_MainActionsCallbackInterface.OnSteer;
                @Steer.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnSteer;
                @Steer.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnSteer;
                @ModifySails.started -= m_Wrapper.m_MainActionsCallbackInterface.OnModifySails;
                @ModifySails.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnModifySails;
                @ModifySails.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnModifySails;
            }
            m_Wrapper.m_MainActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Exit.started += instance.OnExit;
                @Exit.performed += instance.OnExit;
                @Exit.canceled += instance.OnExit;
                @Steer.started += instance.OnSteer;
                @Steer.performed += instance.OnSteer;
                @Steer.canceled += instance.OnSteer;
                @ModifySails.started += instance.OnModifySails;
                @ModifySails.performed += instance.OnModifySails;
                @ModifySails.canceled += instance.OnModifySails;
            }
        }
    }
    public MainActions @Main => new MainActions(this);
    public interface IMainActions
    {
        void OnExit(InputAction.CallbackContext context);
        void OnSteer(InputAction.CallbackContext context);
        void OnModifySails(InputAction.CallbackContext context);
    }
}
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.3
//     from Assets/Project.Source/Input/AbilityInputActions.inputactions
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

namespace Project.Source.Input
{
    public partial class @AbilityInputActions : IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @AbilityInputActions()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""AbilityInputActions"",
    ""maps"": [
        {
            ""name"": ""PlayerAbilities"",
            ""id"": ""beda1f7d-3362-4779-b8c8-05f45bffcd70"",
            ""actions"": [
                {
                    ""name"": ""ExecuteAbility"",
                    ""type"": ""Button"",
                    ""id"": ""74c5e96b-96df-41e1-9251-a1f58f33969a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""6b328389-bad4-49c3-abe2-3f7f79482bfc"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": ""Scale"",
                    ""groups"": """",
                    ""action"": ""ExecuteAbility"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""421388ad-e64c-40e3-b227-d5f8ab2959f4"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=2)"",
                    ""groups"": """",
                    ""action"": ""ExecuteAbility"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // PlayerAbilities
            m_PlayerAbilities = asset.FindActionMap("PlayerAbilities", throwIfNotFound: true);
            m_PlayerAbilities_ExecuteAbility = m_PlayerAbilities.FindAction("ExecuteAbility", throwIfNotFound: true);
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

        // PlayerAbilities
        private readonly InputActionMap m_PlayerAbilities;
        private IPlayerAbilitiesActions m_PlayerAbilitiesActionsCallbackInterface;
        private readonly InputAction m_PlayerAbilities_ExecuteAbility;
        public struct PlayerAbilitiesActions
        {
            private @AbilityInputActions m_Wrapper;
            public PlayerAbilitiesActions(@AbilityInputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @ExecuteAbility => m_Wrapper.m_PlayerAbilities_ExecuteAbility;
            public InputActionMap Get() { return m_Wrapper.m_PlayerAbilities; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(PlayerAbilitiesActions set) { return set.Get(); }
            public void SetCallbacks(IPlayerAbilitiesActions instance)
            {
                if (m_Wrapper.m_PlayerAbilitiesActionsCallbackInterface != null)
                {
                    @ExecuteAbility.started -= m_Wrapper.m_PlayerAbilitiesActionsCallbackInterface.OnExecuteAbility;
                    @ExecuteAbility.performed -= m_Wrapper.m_PlayerAbilitiesActionsCallbackInterface.OnExecuteAbility;
                    @ExecuteAbility.canceled -= m_Wrapper.m_PlayerAbilitiesActionsCallbackInterface.OnExecuteAbility;
                }
                m_Wrapper.m_PlayerAbilitiesActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @ExecuteAbility.started += instance.OnExecuteAbility;
                    @ExecuteAbility.performed += instance.OnExecuteAbility;
                    @ExecuteAbility.canceled += instance.OnExecuteAbility;
                }
            }
        }
        public PlayerAbilitiesActions @PlayerAbilities => new PlayerAbilitiesActions(this);
        public interface IPlayerAbilitiesActions
        {
            void OnExecuteAbility(InputAction.CallbackContext context);
        }
    }
}

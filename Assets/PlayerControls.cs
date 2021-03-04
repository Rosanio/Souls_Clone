// GENERATED AUTOMATICALLY FROM 'Assets/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Player Movement"",
            ""id"": ""8378de4b-8f47-4e20-ba39-c1fdd0f0355b"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""5631810d-e58e-4a88-9d0b-1e5e11ff08ac"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Camera"",
                    ""type"": ""PassThrough"",
                    ""id"": ""706b2b77-40f3-4c2c-8b1e-8aadb724a6de"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ChangeLockOnTarget"",
                    ""type"": ""PassThrough"",
                    ""id"": ""9b53e41e-296a-4d35-8cb5-3663b5c2f3db"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""4f00e199-ad98-41d4-a12b-ae0f723ca15b"",
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
                    ""id"": ""9b1bb393-c729-4519-afb8-15f8d44d57bb"",
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
                    ""id"": ""f1956675-df82-461b-a154-8b268f24c259"",
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
                    ""id"": ""ec3745e8-8696-4c97-8ef9-59ca283b92f6"",
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
                    ""id"": ""35c3df0d-bffa-46d5-8c93-1565f9625934"",
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
                    ""id"": ""3943ae0c-13c5-421d-a9f5-c0c4106207c4"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": """",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fe1e0faa-89c3-4ac2-8f35-094cfd3ad0c6"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ab6d8c12-2603-4013-ad38-ce315c60aad4"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": ""NormalizeVector2"",
                    ""groups"": """",
                    ""action"": ""ChangeLockOnTarget"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Player Actions"",
            ""id"": ""c9c08851-85b2-4179-bca0-b37005676ae8"",
            ""actions"": [
                {
                    ""name"": ""Roll"",
                    ""type"": ""Button"",
                    ""id"": ""05ba638f-66c9-48da-9c8f-cd9f33e567ff"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RT"",
                    ""type"": ""Button"",
                    ""id"": ""a7bbc6df-685e-4fa0-8d7c-22ad1323c64f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RB"",
                    ""type"": ""Button"",
                    ""id"": ""9742b321-0686-4a07-8230-a8ac4184a1f3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""a060fdac-0978-4e96-875e-95d6af61e1ac"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""02c267ba-dc5a-4ff0-b80f-cbe1073b8d1d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Inventory"",
                    ""type"": ""Button"",
                    ""id"": ""60680536-ed7e-4158-9afa-f61ebd5dca88"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LockOn"",
                    ""type"": ""Button"",
                    ""id"": ""15eb2163-52f4-4af1-be6d-d2a9036dd43b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Walk"",
                    ""type"": ""Button"",
                    ""id"": ""5ade6fbb-1326-4b90-a6f3-2ae10a39cef3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""91d887e9-c4cd-4fd7-b834-62f40d63a657"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Roll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4cffce29-ee67-438a-a0ee-016192c4c380"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Roll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""4ec2dfa7-5bd9-4183-b74d-c2ed59479ee7"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RT"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""570b4463-7050-4801-bb7c-2577a5470ae4"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RT"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""fe0d0bd0-acdf-4633-a056-becfc3cd6aed"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RT"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""c046e35d-583d-4ca7-b079-140001d50399"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RB"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a1817529-bea4-41fe-9b9f-9ffaab70e58f"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4ba82d79-f577-4755-8b81-2bfa63f2bb9c"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""50a4802e-8e75-473d-a090-91e13e41ecd7"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4e270b3e-986d-4247-9787-5d0a195b121e"",
                    ""path"": ""<Keyboard>/m"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Inventory"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""913ce4b3-e795-4c26-abd8-30db3e3729c3"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LockOn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""37d3af42-0e48-4e65-969f-fd43895436a9"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Inventory Management"",
            ""id"": ""f8c72665-a90b-4156-897f-3f5db65da60d"",
            ""actions"": [
                {
                    ""name"": ""D-Pad Up"",
                    ""type"": ""Button"",
                    ""id"": ""bfce7813-6f33-4ded-8827-82f5e1b9db47"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""D-Pad Down"",
                    ""type"": ""Button"",
                    ""id"": ""38a5d204-9040-4fb1-952c-aa383f68a876"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""D-Pad Left"",
                    ""type"": ""Button"",
                    ""id"": ""e698578c-2b41-488c-a1a8-a15348c7b5c3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""D-Pad Right"",
                    ""type"": ""Button"",
                    ""id"": ""30b49b38-2753-4e5d-adb3-a42ae1a39d0d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""6bc8d4fe-35e8-45d6-a68c-59d7d244347a"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""D-Pad Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""885ed4ea-2a4c-4d30-88f2-72726f1a606b"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""D-Pad Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""94d9db56-0a09-4868-ab63-3c5711560247"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""D-Pad Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7ec22bcd-62b9-410e-b633-2bf476279646"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""D-Pad Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""01885176-dcba-4a02-99e8-9ec8afb98fdf"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""D-Pad Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4bd95a0a-9494-46d3-b959-64f8616e6223"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""D-Pad Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dd5cd551-0ff0-48ff-94bd-e11f191f28be"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""D-Pad Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8a82babf-c679-466c-97ca-5ac67d8a77c2"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""D-Pad Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player Movement
        m_PlayerMovement = asset.FindActionMap("Player Movement", throwIfNotFound: true);
        m_PlayerMovement_Movement = m_PlayerMovement.FindAction("Movement", throwIfNotFound: true);
        m_PlayerMovement_Camera = m_PlayerMovement.FindAction("Camera", throwIfNotFound: true);
        m_PlayerMovement_ChangeLockOnTarget = m_PlayerMovement.FindAction("ChangeLockOnTarget", throwIfNotFound: true);
        // Player Actions
        m_PlayerActions = asset.FindActionMap("Player Actions", throwIfNotFound: true);
        m_PlayerActions_Roll = m_PlayerActions.FindAction("Roll", throwIfNotFound: true);
        m_PlayerActions_RT = m_PlayerActions.FindAction("RT", throwIfNotFound: true);
        m_PlayerActions_RB = m_PlayerActions.FindAction("RB", throwIfNotFound: true);
        m_PlayerActions_Interact = m_PlayerActions.FindAction("Interact", throwIfNotFound: true);
        m_PlayerActions_Jump = m_PlayerActions.FindAction("Jump", throwIfNotFound: true);
        m_PlayerActions_Inventory = m_PlayerActions.FindAction("Inventory", throwIfNotFound: true);
        m_PlayerActions_LockOn = m_PlayerActions.FindAction("LockOn", throwIfNotFound: true);
        m_PlayerActions_Walk = m_PlayerActions.FindAction("Walk", throwIfNotFound: true);
        // Inventory Management
        m_InventoryManagement = asset.FindActionMap("Inventory Management", throwIfNotFound: true);
        m_InventoryManagement_DPadUp = m_InventoryManagement.FindAction("D-Pad Up", throwIfNotFound: true);
        m_InventoryManagement_DPadDown = m_InventoryManagement.FindAction("D-Pad Down", throwIfNotFound: true);
        m_InventoryManagement_DPadLeft = m_InventoryManagement.FindAction("D-Pad Left", throwIfNotFound: true);
        m_InventoryManagement_DPadRight = m_InventoryManagement.FindAction("D-Pad Right", throwIfNotFound: true);
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

    // Player Movement
    private readonly InputActionMap m_PlayerMovement;
    private IPlayerMovementActions m_PlayerMovementActionsCallbackInterface;
    private readonly InputAction m_PlayerMovement_Movement;
    private readonly InputAction m_PlayerMovement_Camera;
    private readonly InputAction m_PlayerMovement_ChangeLockOnTarget;
    public struct PlayerMovementActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerMovementActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_PlayerMovement_Movement;
        public InputAction @Camera => m_Wrapper.m_PlayerMovement_Camera;
        public InputAction @ChangeLockOnTarget => m_Wrapper.m_PlayerMovement_ChangeLockOnTarget;
        public InputActionMap Get() { return m_Wrapper.m_PlayerMovement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerMovementActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerMovementActions instance)
        {
            if (m_Wrapper.m_PlayerMovementActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnMovement;
                @Camera.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnCamera;
                @Camera.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnCamera;
                @Camera.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnCamera;
                @ChangeLockOnTarget.started -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnChangeLockOnTarget;
                @ChangeLockOnTarget.performed -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnChangeLockOnTarget;
                @ChangeLockOnTarget.canceled -= m_Wrapper.m_PlayerMovementActionsCallbackInterface.OnChangeLockOnTarget;
            }
            m_Wrapper.m_PlayerMovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Camera.started += instance.OnCamera;
                @Camera.performed += instance.OnCamera;
                @Camera.canceled += instance.OnCamera;
                @ChangeLockOnTarget.started += instance.OnChangeLockOnTarget;
                @ChangeLockOnTarget.performed += instance.OnChangeLockOnTarget;
                @ChangeLockOnTarget.canceled += instance.OnChangeLockOnTarget;
            }
        }
    }
    public PlayerMovementActions @PlayerMovement => new PlayerMovementActions(this);

    // Player Actions
    private readonly InputActionMap m_PlayerActions;
    private IPlayerActionsActions m_PlayerActionsActionsCallbackInterface;
    private readonly InputAction m_PlayerActions_Roll;
    private readonly InputAction m_PlayerActions_RT;
    private readonly InputAction m_PlayerActions_RB;
    private readonly InputAction m_PlayerActions_Interact;
    private readonly InputAction m_PlayerActions_Jump;
    private readonly InputAction m_PlayerActions_Inventory;
    private readonly InputAction m_PlayerActions_LockOn;
    private readonly InputAction m_PlayerActions_Walk;
    public struct PlayerActionsActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerActionsActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Roll => m_Wrapper.m_PlayerActions_Roll;
        public InputAction @RT => m_Wrapper.m_PlayerActions_RT;
        public InputAction @RB => m_Wrapper.m_PlayerActions_RB;
        public InputAction @Interact => m_Wrapper.m_PlayerActions_Interact;
        public InputAction @Jump => m_Wrapper.m_PlayerActions_Jump;
        public InputAction @Inventory => m_Wrapper.m_PlayerActions_Inventory;
        public InputAction @LockOn => m_Wrapper.m_PlayerActions_LockOn;
        public InputAction @Walk => m_Wrapper.m_PlayerActions_Walk;
        public InputActionMap Get() { return m_Wrapper.m_PlayerActions; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActionsActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActionsActions instance)
        {
            if (m_Wrapper.m_PlayerActionsActionsCallbackInterface != null)
            {
                @Roll.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnRoll;
                @Roll.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnRoll;
                @Roll.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnRoll;
                @RT.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnRT;
                @RT.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnRT;
                @RT.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnRT;
                @RB.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnRB;
                @RB.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnRB;
                @RB.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnRB;
                @Interact.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnInteract;
                @Jump.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnJump;
                @Inventory.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnInventory;
                @Inventory.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnInventory;
                @Inventory.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnInventory;
                @LockOn.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnLockOn;
                @LockOn.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnLockOn;
                @LockOn.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnLockOn;
                @Walk.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnWalk;
                @Walk.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnWalk;
                @Walk.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnWalk;
            }
            m_Wrapper.m_PlayerActionsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Roll.started += instance.OnRoll;
                @Roll.performed += instance.OnRoll;
                @Roll.canceled += instance.OnRoll;
                @RT.started += instance.OnRT;
                @RT.performed += instance.OnRT;
                @RT.canceled += instance.OnRT;
                @RB.started += instance.OnRB;
                @RB.performed += instance.OnRB;
                @RB.canceled += instance.OnRB;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Inventory.started += instance.OnInventory;
                @Inventory.performed += instance.OnInventory;
                @Inventory.canceled += instance.OnInventory;
                @LockOn.started += instance.OnLockOn;
                @LockOn.performed += instance.OnLockOn;
                @LockOn.canceled += instance.OnLockOn;
                @Walk.started += instance.OnWalk;
                @Walk.performed += instance.OnWalk;
                @Walk.canceled += instance.OnWalk;
            }
        }
    }
    public PlayerActionsActions @PlayerActions => new PlayerActionsActions(this);

    // Inventory Management
    private readonly InputActionMap m_InventoryManagement;
    private IInventoryManagementActions m_InventoryManagementActionsCallbackInterface;
    private readonly InputAction m_InventoryManagement_DPadUp;
    private readonly InputAction m_InventoryManagement_DPadDown;
    private readonly InputAction m_InventoryManagement_DPadLeft;
    private readonly InputAction m_InventoryManagement_DPadRight;
    public struct InventoryManagementActions
    {
        private @PlayerControls m_Wrapper;
        public InventoryManagementActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @DPadUp => m_Wrapper.m_InventoryManagement_DPadUp;
        public InputAction @DPadDown => m_Wrapper.m_InventoryManagement_DPadDown;
        public InputAction @DPadLeft => m_Wrapper.m_InventoryManagement_DPadLeft;
        public InputAction @DPadRight => m_Wrapper.m_InventoryManagement_DPadRight;
        public InputActionMap Get() { return m_Wrapper.m_InventoryManagement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InventoryManagementActions set) { return set.Get(); }
        public void SetCallbacks(IInventoryManagementActions instance)
        {
            if (m_Wrapper.m_InventoryManagementActionsCallbackInterface != null)
            {
                @DPadUp.started -= m_Wrapper.m_InventoryManagementActionsCallbackInterface.OnDPadUp;
                @DPadUp.performed -= m_Wrapper.m_InventoryManagementActionsCallbackInterface.OnDPadUp;
                @DPadUp.canceled -= m_Wrapper.m_InventoryManagementActionsCallbackInterface.OnDPadUp;
                @DPadDown.started -= m_Wrapper.m_InventoryManagementActionsCallbackInterface.OnDPadDown;
                @DPadDown.performed -= m_Wrapper.m_InventoryManagementActionsCallbackInterface.OnDPadDown;
                @DPadDown.canceled -= m_Wrapper.m_InventoryManagementActionsCallbackInterface.OnDPadDown;
                @DPadLeft.started -= m_Wrapper.m_InventoryManagementActionsCallbackInterface.OnDPadLeft;
                @DPadLeft.performed -= m_Wrapper.m_InventoryManagementActionsCallbackInterface.OnDPadLeft;
                @DPadLeft.canceled -= m_Wrapper.m_InventoryManagementActionsCallbackInterface.OnDPadLeft;
                @DPadRight.started -= m_Wrapper.m_InventoryManagementActionsCallbackInterface.OnDPadRight;
                @DPadRight.performed -= m_Wrapper.m_InventoryManagementActionsCallbackInterface.OnDPadRight;
                @DPadRight.canceled -= m_Wrapper.m_InventoryManagementActionsCallbackInterface.OnDPadRight;
            }
            m_Wrapper.m_InventoryManagementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @DPadUp.started += instance.OnDPadUp;
                @DPadUp.performed += instance.OnDPadUp;
                @DPadUp.canceled += instance.OnDPadUp;
                @DPadDown.started += instance.OnDPadDown;
                @DPadDown.performed += instance.OnDPadDown;
                @DPadDown.canceled += instance.OnDPadDown;
                @DPadLeft.started += instance.OnDPadLeft;
                @DPadLeft.performed += instance.OnDPadLeft;
                @DPadLeft.canceled += instance.OnDPadLeft;
                @DPadRight.started += instance.OnDPadRight;
                @DPadRight.performed += instance.OnDPadRight;
                @DPadRight.canceled += instance.OnDPadRight;
            }
        }
    }
    public InventoryManagementActions @InventoryManagement => new InventoryManagementActions(this);
    public interface IPlayerMovementActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnCamera(InputAction.CallbackContext context);
        void OnChangeLockOnTarget(InputAction.CallbackContext context);
    }
    public interface IPlayerActionsActions
    {
        void OnRoll(InputAction.CallbackContext context);
        void OnRT(InputAction.CallbackContext context);
        void OnRB(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnInventory(InputAction.CallbackContext context);
        void OnLockOn(InputAction.CallbackContext context);
        void OnWalk(InputAction.CallbackContext context);
    }
    public interface IInventoryManagementActions
    {
        void OnDPadUp(InputAction.CallbackContext context);
        void OnDPadDown(InputAction.CallbackContext context);
        void OnDPadLeft(InputAction.CallbackContext context);
        void OnDPadRight(InputAction.CallbackContext context);
    }
}

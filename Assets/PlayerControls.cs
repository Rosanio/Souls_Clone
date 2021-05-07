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
                },
                {
                    ""name"": ""TwoHand"",
                    ""type"": ""Button"",
                    ""id"": ""c6662960-d845-49b9-8de3-42480d944e48"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""UseItem"",
                    ""type"": ""Button"",
                    ""id"": ""30de145f-bd51-4cb9-83cb-aefcd7849f33"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftAttack1"",
                    ""type"": ""Button"",
                    ""id"": ""aefdb771-1bc4-4ad0-b083-6601e9810f71"",
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
                    ""id"": ""6cde2cbc-c0cc-4ef9-82ba-0cff577d1254"",
                    ""path"": ""<Keyboard>/q"",
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
                },
                {
                    ""name"": """",
                    ""id"": ""b31d450f-5611-4201-9787-cc75be00f913"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TwoHand"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""96509933-f14c-4a5d-8578-5fbcd5d89d8c"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UseItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c0f39ea8-db66-41ca-9f39-aa88f46223b3"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftAttack1"",
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
        },
        {
            ""name"": ""Menu Navigation"",
            ""id"": ""aa2c0d35-8b70-4fae-af05-08a948e566ad"",
            ""actions"": [
                {
                    ""name"": ""Confirm"",
                    ""type"": ""Button"",
                    ""id"": ""fd98a9af-e910-4332-9944-c8d1d7cb1ca4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Navigate Left"",
                    ""type"": ""Button"",
                    ""id"": ""a8d92885-f90b-4a44-85b7-c5eb62c2ec94"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Navigate Right"",
                    ""type"": ""Button"",
                    ""id"": ""36c6bea7-18af-492b-8ad2-5044c250f58c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Navigate Up"",
                    ""type"": ""Button"",
                    ""id"": ""50c2a53c-f891-485d-811b-f5708d79fad1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Navigate Down"",
                    ""type"": ""Button"",
                    ""id"": ""d740d55f-e950-4c96-86fe-f2fa7c030611"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Back"",
                    ""type"": ""Button"",
                    ""id"": ""abefdb1d-49b6-4959-9407-c0b5ce2e1eb3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Menu Option 1"",
                    ""type"": ""Button"",
                    ""id"": ""b4841cd4-fdf7-4001-9a6d-9315931e0f84"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Tab Left"",
                    ""type"": ""Button"",
                    ""id"": ""c0b9708a-5468-4309-8b09-75eac96560ac"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Tab Right"",
                    ""type"": ""Button"",
                    ""id"": ""ac6bc6f6-090a-4203-9fdc-5b03095101a4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""79067724-8efc-4b49-a3c9-fad7a6db8c3c"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Confirm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""87009568-7d87-48d4-bb60-d6b7bbb77bdc"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""304a9444-fcc9-41be-9bb5-36ea524853d9"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""329e17fa-8b29-44c8-81c5-2c60298ad2b8"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""10e36945-f227-421e-a1db-de4ff42c7ee6"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Navigate Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d95c8fb5-2c35-4e94-bb1c-b3cc17aecf38"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""79963500-4317-4193-8289-b568088bda84"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Menu Option 1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""3e9d9b6a-9ce0-4b2b-9e14-cfae01b7d870"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Tab Left"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""5a542ae3-6535-418b-ba4f-63ced0f6628e"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Tab Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""c10efcdc-50d8-4db2-bae4-5bc30d61d72f"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Tab Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Button With One Modifier"",
                    ""id"": ""02df503d-325e-477a-846a-002637c4dfce"",
                    ""path"": ""ButtonWithOneModifier"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Tab Right"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""modifier"",
                    ""id"": ""0cb02a4a-8258-4182-b718-46a7c0a46ea7"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Tab Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""button"",
                    ""id"": ""e554b704-cf46-47d4-93fe-cd995e104d25"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Tab Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
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
        m_PlayerActions_TwoHand = m_PlayerActions.FindAction("TwoHand", throwIfNotFound: true);
        m_PlayerActions_UseItem = m_PlayerActions.FindAction("UseItem", throwIfNotFound: true);
        m_PlayerActions_LeftAttack1 = m_PlayerActions.FindAction("LeftAttack1", throwIfNotFound: true);
        // Inventory Management
        m_InventoryManagement = asset.FindActionMap("Inventory Management", throwIfNotFound: true);
        m_InventoryManagement_DPadUp = m_InventoryManagement.FindAction("D-Pad Up", throwIfNotFound: true);
        m_InventoryManagement_DPadDown = m_InventoryManagement.FindAction("D-Pad Down", throwIfNotFound: true);
        m_InventoryManagement_DPadLeft = m_InventoryManagement.FindAction("D-Pad Left", throwIfNotFound: true);
        m_InventoryManagement_DPadRight = m_InventoryManagement.FindAction("D-Pad Right", throwIfNotFound: true);
        // Menu Navigation
        m_MenuNavigation = asset.FindActionMap("Menu Navigation", throwIfNotFound: true);
        m_MenuNavigation_Confirm = m_MenuNavigation.FindAction("Confirm", throwIfNotFound: true);
        m_MenuNavigation_NavigateLeft = m_MenuNavigation.FindAction("Navigate Left", throwIfNotFound: true);
        m_MenuNavigation_NavigateRight = m_MenuNavigation.FindAction("Navigate Right", throwIfNotFound: true);
        m_MenuNavigation_NavigateUp = m_MenuNavigation.FindAction("Navigate Up", throwIfNotFound: true);
        m_MenuNavigation_NavigateDown = m_MenuNavigation.FindAction("Navigate Down", throwIfNotFound: true);
        m_MenuNavigation_Back = m_MenuNavigation.FindAction("Back", throwIfNotFound: true);
        m_MenuNavigation_MenuOption1 = m_MenuNavigation.FindAction("Menu Option 1", throwIfNotFound: true);
        m_MenuNavigation_TabLeft = m_MenuNavigation.FindAction("Tab Left", throwIfNotFound: true);
        m_MenuNavigation_TabRight = m_MenuNavigation.FindAction("Tab Right", throwIfNotFound: true);
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
    private readonly InputAction m_PlayerActions_TwoHand;
    private readonly InputAction m_PlayerActions_UseItem;
    private readonly InputAction m_PlayerActions_LeftAttack1;
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
        public InputAction @TwoHand => m_Wrapper.m_PlayerActions_TwoHand;
        public InputAction @UseItem => m_Wrapper.m_PlayerActions_UseItem;
        public InputAction @LeftAttack1 => m_Wrapper.m_PlayerActions_LeftAttack1;
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
                @TwoHand.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnTwoHand;
                @TwoHand.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnTwoHand;
                @TwoHand.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnTwoHand;
                @UseItem.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnUseItem;
                @UseItem.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnUseItem;
                @UseItem.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnUseItem;
                @LeftAttack1.started -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnLeftAttack1;
                @LeftAttack1.performed -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnLeftAttack1;
                @LeftAttack1.canceled -= m_Wrapper.m_PlayerActionsActionsCallbackInterface.OnLeftAttack1;
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
                @TwoHand.started += instance.OnTwoHand;
                @TwoHand.performed += instance.OnTwoHand;
                @TwoHand.canceled += instance.OnTwoHand;
                @UseItem.started += instance.OnUseItem;
                @UseItem.performed += instance.OnUseItem;
                @UseItem.canceled += instance.OnUseItem;
                @LeftAttack1.started += instance.OnLeftAttack1;
                @LeftAttack1.performed += instance.OnLeftAttack1;
                @LeftAttack1.canceled += instance.OnLeftAttack1;
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

    // Menu Navigation
    private readonly InputActionMap m_MenuNavigation;
    private IMenuNavigationActions m_MenuNavigationActionsCallbackInterface;
    private readonly InputAction m_MenuNavigation_Confirm;
    private readonly InputAction m_MenuNavigation_NavigateLeft;
    private readonly InputAction m_MenuNavigation_NavigateRight;
    private readonly InputAction m_MenuNavigation_NavigateUp;
    private readonly InputAction m_MenuNavigation_NavigateDown;
    private readonly InputAction m_MenuNavigation_Back;
    private readonly InputAction m_MenuNavigation_MenuOption1;
    private readonly InputAction m_MenuNavigation_TabLeft;
    private readonly InputAction m_MenuNavigation_TabRight;
    public struct MenuNavigationActions
    {
        private @PlayerControls m_Wrapper;
        public MenuNavigationActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Confirm => m_Wrapper.m_MenuNavigation_Confirm;
        public InputAction @NavigateLeft => m_Wrapper.m_MenuNavigation_NavigateLeft;
        public InputAction @NavigateRight => m_Wrapper.m_MenuNavigation_NavigateRight;
        public InputAction @NavigateUp => m_Wrapper.m_MenuNavigation_NavigateUp;
        public InputAction @NavigateDown => m_Wrapper.m_MenuNavigation_NavigateDown;
        public InputAction @Back => m_Wrapper.m_MenuNavigation_Back;
        public InputAction @MenuOption1 => m_Wrapper.m_MenuNavigation_MenuOption1;
        public InputAction @TabLeft => m_Wrapper.m_MenuNavigation_TabLeft;
        public InputAction @TabRight => m_Wrapper.m_MenuNavigation_TabRight;
        public InputActionMap Get() { return m_Wrapper.m_MenuNavigation; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenuNavigationActions set) { return set.Get(); }
        public void SetCallbacks(IMenuNavigationActions instance)
        {
            if (m_Wrapper.m_MenuNavigationActionsCallbackInterface != null)
            {
                @Confirm.started -= m_Wrapper.m_MenuNavigationActionsCallbackInterface.OnConfirm;
                @Confirm.performed -= m_Wrapper.m_MenuNavigationActionsCallbackInterface.OnConfirm;
                @Confirm.canceled -= m_Wrapper.m_MenuNavigationActionsCallbackInterface.OnConfirm;
                @NavigateLeft.started -= m_Wrapper.m_MenuNavigationActionsCallbackInterface.OnNavigateLeft;
                @NavigateLeft.performed -= m_Wrapper.m_MenuNavigationActionsCallbackInterface.OnNavigateLeft;
                @NavigateLeft.canceled -= m_Wrapper.m_MenuNavigationActionsCallbackInterface.OnNavigateLeft;
                @NavigateRight.started -= m_Wrapper.m_MenuNavigationActionsCallbackInterface.OnNavigateRight;
                @NavigateRight.performed -= m_Wrapper.m_MenuNavigationActionsCallbackInterface.OnNavigateRight;
                @NavigateRight.canceled -= m_Wrapper.m_MenuNavigationActionsCallbackInterface.OnNavigateRight;
                @NavigateUp.started -= m_Wrapper.m_MenuNavigationActionsCallbackInterface.OnNavigateUp;
                @NavigateUp.performed -= m_Wrapper.m_MenuNavigationActionsCallbackInterface.OnNavigateUp;
                @NavigateUp.canceled -= m_Wrapper.m_MenuNavigationActionsCallbackInterface.OnNavigateUp;
                @NavigateDown.started -= m_Wrapper.m_MenuNavigationActionsCallbackInterface.OnNavigateDown;
                @NavigateDown.performed -= m_Wrapper.m_MenuNavigationActionsCallbackInterface.OnNavigateDown;
                @NavigateDown.canceled -= m_Wrapper.m_MenuNavigationActionsCallbackInterface.OnNavigateDown;
                @Back.started -= m_Wrapper.m_MenuNavigationActionsCallbackInterface.OnBack;
                @Back.performed -= m_Wrapper.m_MenuNavigationActionsCallbackInterface.OnBack;
                @Back.canceled -= m_Wrapper.m_MenuNavigationActionsCallbackInterface.OnBack;
                @MenuOption1.started -= m_Wrapper.m_MenuNavigationActionsCallbackInterface.OnMenuOption1;
                @MenuOption1.performed -= m_Wrapper.m_MenuNavigationActionsCallbackInterface.OnMenuOption1;
                @MenuOption1.canceled -= m_Wrapper.m_MenuNavigationActionsCallbackInterface.OnMenuOption1;
                @TabLeft.started -= m_Wrapper.m_MenuNavigationActionsCallbackInterface.OnTabLeft;
                @TabLeft.performed -= m_Wrapper.m_MenuNavigationActionsCallbackInterface.OnTabLeft;
                @TabLeft.canceled -= m_Wrapper.m_MenuNavigationActionsCallbackInterface.OnTabLeft;
                @TabRight.started -= m_Wrapper.m_MenuNavigationActionsCallbackInterface.OnTabRight;
                @TabRight.performed -= m_Wrapper.m_MenuNavigationActionsCallbackInterface.OnTabRight;
                @TabRight.canceled -= m_Wrapper.m_MenuNavigationActionsCallbackInterface.OnTabRight;
            }
            m_Wrapper.m_MenuNavigationActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Confirm.started += instance.OnConfirm;
                @Confirm.performed += instance.OnConfirm;
                @Confirm.canceled += instance.OnConfirm;
                @NavigateLeft.started += instance.OnNavigateLeft;
                @NavigateLeft.performed += instance.OnNavigateLeft;
                @NavigateLeft.canceled += instance.OnNavigateLeft;
                @NavigateRight.started += instance.OnNavigateRight;
                @NavigateRight.performed += instance.OnNavigateRight;
                @NavigateRight.canceled += instance.OnNavigateRight;
                @NavigateUp.started += instance.OnNavigateUp;
                @NavigateUp.performed += instance.OnNavigateUp;
                @NavigateUp.canceled += instance.OnNavigateUp;
                @NavigateDown.started += instance.OnNavigateDown;
                @NavigateDown.performed += instance.OnNavigateDown;
                @NavigateDown.canceled += instance.OnNavigateDown;
                @Back.started += instance.OnBack;
                @Back.performed += instance.OnBack;
                @Back.canceled += instance.OnBack;
                @MenuOption1.started += instance.OnMenuOption1;
                @MenuOption1.performed += instance.OnMenuOption1;
                @MenuOption1.canceled += instance.OnMenuOption1;
                @TabLeft.started += instance.OnTabLeft;
                @TabLeft.performed += instance.OnTabLeft;
                @TabLeft.canceled += instance.OnTabLeft;
                @TabRight.started += instance.OnTabRight;
                @TabRight.performed += instance.OnTabRight;
                @TabRight.canceled += instance.OnTabRight;
            }
        }
    }
    public MenuNavigationActions @MenuNavigation => new MenuNavigationActions(this);
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
        void OnTwoHand(InputAction.CallbackContext context);
        void OnUseItem(InputAction.CallbackContext context);
        void OnLeftAttack1(InputAction.CallbackContext context);
    }
    public interface IInventoryManagementActions
    {
        void OnDPadUp(InputAction.CallbackContext context);
        void OnDPadDown(InputAction.CallbackContext context);
        void OnDPadLeft(InputAction.CallbackContext context);
        void OnDPadRight(InputAction.CallbackContext context);
    }
    public interface IMenuNavigationActions
    {
        void OnConfirm(InputAction.CallbackContext context);
        void OnNavigateLeft(InputAction.CallbackContext context);
        void OnNavigateRight(InputAction.CallbackContext context);
        void OnNavigateUp(InputAction.CallbackContext context);
        void OnNavigateDown(InputAction.CallbackContext context);
        void OnBack(InputAction.CallbackContext context);
        void OnMenuOption1(InputAction.CallbackContext context);
        void OnTabLeft(InputAction.CallbackContext context);
        void OnTabRight(InputAction.CallbackContext context);
    }
}

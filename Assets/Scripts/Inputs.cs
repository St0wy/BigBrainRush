// GENERATED AUTOMATICALLY FROM 'Assets/Inputs.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Inputs : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Inputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Inputs"",
    ""maps"": [
        {
            ""name"": ""MapEditor"",
            ""id"": ""3343762b-201d-4472-8f8d-f2451b54f1ac"",
            ""actions"": [
                {
                    ""name"": ""PlaceRoad"",
                    ""type"": ""Button"",
                    ""id"": ""a0d91037-8342-4062-ad68-36772bf6acba"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RotateOrientation"",
                    ""type"": ""Button"",
                    ""id"": ""8eac6122-8219-4b92-9353-426ad73b656b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SelectButtonStraight"",
                    ""type"": ""Button"",
                    ""id"": ""f0db49ba-547f-4356-a66f-e94934fb8b1b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SelectButtonTurn"",
                    ""type"": ""Button"",
                    ""id"": ""5e37d7d7-0f8b-4234-84ac-00d664811adc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ShowPauseMenu"",
                    ""type"": ""Button"",
                    ""id"": ""fbe43584-c98f-439f-b73d-7fe5ebd0367b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SelectButtonTJunction"",
                    ""type"": ""Button"",
                    ""id"": ""bfdff75b-ccce-4e2f-a298-091399d606f8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SelectButtonCrossroad"",
                    ""type"": ""Button"",
                    ""id"": ""2b8ede85-5f42-487d-b949-8783043df4b3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SelectButtonStart"",
                    ""type"": ""Button"",
                    ""id"": ""728bc402-dc03-4d15-85f5-1085c9572327"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SelectButtonEnd"",
                    ""type"": ""Button"",
                    ""id"": ""7491e43c-a992-4a87-b307-182265884354"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SelectButtonDelete"",
                    ""type"": ""Button"",
                    ""id"": ""aa2e282b-b1c3-45a1-b5a0-048f52be9d1c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""db90adfd-486c-42a6-b736-091565f161a0"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlaceRoad"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""d42e5e66-71d1-46db-a2cc-3ddf09b98d47"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateOrientation"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""64b646cf-65e7-4518-bf8e-782b415a2a4f"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""RotateOrientation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""965831bd-56a3-4042-a100-0602e7689fea"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""RotateOrientation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""846d4030-cd9b-4ce1-9635-03eeb0c18809"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectButtonStraight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""64c187c6-0aad-4498-9f06-9fa0cd7812a7"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectButtonTurn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7507cc32-6a30-47f5-b30f-c81718169aa4"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShowPauseMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""50b5e9a0-888a-4d8d-ba23-3ba5c5fc5d0b"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectButtonTJunction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c1f50b59-0419-4f14-a6f3-ae1d326f3ba9"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectButtonCrossroad"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bb0c8132-5c6e-491a-9987-5ac8f6439f72"",
                    ""path"": ""<Keyboard>/5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectButtonStart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1ac69bb1-6f90-4dc4-a4b4-944f440f3dfd"",
                    ""path"": ""<Keyboard>/6"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectButtonEnd"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ca6a5414-7d03-4c52-b859-b0118e13189e"",
                    ""path"": ""<Keyboard>/7"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectButtonDelete"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1b807eed-6d0c-4d0f-8470-e4471c30a5a3"",
                    ""path"": ""<Keyboard>/delete"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectButtonDelete"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Car"",
            ""id"": ""45f06653-9823-4a90-8c70-403b201cd90a"",
            ""actions"": [
                {
                    ""name"": ""Steer"",
                    ""type"": ""Value"",
                    ""id"": ""860df541-4f73-4e94-86f0-7de2710f41ac"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Accelerate"",
                    ""type"": ""Button"",
                    ""id"": ""2c33fe4e-2676-4da9-b5f8-9c4f1e3131e1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""2d5e60f9-0776-498f-a622-2f07419b6a3e"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Steer"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""f74b567e-f855-40d9-8770-ee3ff4ff5b46"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Steer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""22ab737e-3ae3-457f-87da-883d40b416af"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Steer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""f2410663-8a0c-471c-af50-90b559dd8de9"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Accelerate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""ef3b471a-5959-447b-bed4-9b90a2a3e988"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Accelerate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""a2c5da5a-4526-4f98-b361-370c358d2aad"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Accelerate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
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
        }
    ]
}");
        // MapEditor
        m_MapEditor = asset.FindActionMap("MapEditor", throwIfNotFound: true);
        m_MapEditor_PlaceRoad = m_MapEditor.FindAction("PlaceRoad", throwIfNotFound: true);
        m_MapEditor_RotateOrientation = m_MapEditor.FindAction("RotateOrientation", throwIfNotFound: true);
        m_MapEditor_SelectButtonStraight = m_MapEditor.FindAction("SelectButtonStraight", throwIfNotFound: true);
        m_MapEditor_SelectButtonTurn = m_MapEditor.FindAction("SelectButtonTurn", throwIfNotFound: true);
        m_MapEditor_ShowPauseMenu = m_MapEditor.FindAction("ShowPauseMenu", throwIfNotFound: true);
        m_MapEditor_SelectButtonTJunction = m_MapEditor.FindAction("SelectButtonTJunction", throwIfNotFound: true);
        m_MapEditor_SelectButtonCrossroad = m_MapEditor.FindAction("SelectButtonCrossroad", throwIfNotFound: true);
        m_MapEditor_SelectButtonStart = m_MapEditor.FindAction("SelectButtonStart", throwIfNotFound: true);
        m_MapEditor_SelectButtonEnd = m_MapEditor.FindAction("SelectButtonEnd", throwIfNotFound: true);
        m_MapEditor_SelectButtonDelete = m_MapEditor.FindAction("SelectButtonDelete", throwIfNotFound: true);
        // Car
        m_Car = asset.FindActionMap("Car", throwIfNotFound: true);
        m_Car_Steer = m_Car.FindAction("Steer", throwIfNotFound: true);
        m_Car_Accelerate = m_Car.FindAction("Accelerate", throwIfNotFound: true);
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

    // MapEditor
    private readonly InputActionMap m_MapEditor;
    private IMapEditorActions m_MapEditorActionsCallbackInterface;
    private readonly InputAction m_MapEditor_PlaceRoad;
    private readonly InputAction m_MapEditor_RotateOrientation;
    private readonly InputAction m_MapEditor_SelectButtonStraight;
    private readonly InputAction m_MapEditor_SelectButtonTurn;
    private readonly InputAction m_MapEditor_ShowPauseMenu;
    private readonly InputAction m_MapEditor_SelectButtonTJunction;
    private readonly InputAction m_MapEditor_SelectButtonCrossroad;
    private readonly InputAction m_MapEditor_SelectButtonStart;
    private readonly InputAction m_MapEditor_SelectButtonEnd;
    private readonly InputAction m_MapEditor_SelectButtonDelete;
    public struct MapEditorActions
    {
        private @Inputs m_Wrapper;
        public MapEditorActions(@Inputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @PlaceRoad => m_Wrapper.m_MapEditor_PlaceRoad;
        public InputAction @RotateOrientation => m_Wrapper.m_MapEditor_RotateOrientation;
        public InputAction @SelectButtonStraight => m_Wrapper.m_MapEditor_SelectButtonStraight;
        public InputAction @SelectButtonTurn => m_Wrapper.m_MapEditor_SelectButtonTurn;
        public InputAction @ShowPauseMenu => m_Wrapper.m_MapEditor_ShowPauseMenu;
        public InputAction @SelectButtonTJunction => m_Wrapper.m_MapEditor_SelectButtonTJunction;
        public InputAction @SelectButtonCrossroad => m_Wrapper.m_MapEditor_SelectButtonCrossroad;
        public InputAction @SelectButtonStart => m_Wrapper.m_MapEditor_SelectButtonStart;
        public InputAction @SelectButtonEnd => m_Wrapper.m_MapEditor_SelectButtonEnd;
        public InputAction @SelectButtonDelete => m_Wrapper.m_MapEditor_SelectButtonDelete;
        public InputActionMap Get() { return m_Wrapper.m_MapEditor; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MapEditorActions set) { return set.Get(); }
        public void SetCallbacks(IMapEditorActions instance)
        {
            if (m_Wrapper.m_MapEditorActionsCallbackInterface != null)
            {
                @PlaceRoad.started -= m_Wrapper.m_MapEditorActionsCallbackInterface.OnPlaceRoad;
                @PlaceRoad.performed -= m_Wrapper.m_MapEditorActionsCallbackInterface.OnPlaceRoad;
                @PlaceRoad.canceled -= m_Wrapper.m_MapEditorActionsCallbackInterface.OnPlaceRoad;
                @RotateOrientation.started -= m_Wrapper.m_MapEditorActionsCallbackInterface.OnRotateOrientation;
                @RotateOrientation.performed -= m_Wrapper.m_MapEditorActionsCallbackInterface.OnRotateOrientation;
                @RotateOrientation.canceled -= m_Wrapper.m_MapEditorActionsCallbackInterface.OnRotateOrientation;
                @SelectButtonStraight.started -= m_Wrapper.m_MapEditorActionsCallbackInterface.OnSelectButtonStraight;
                @SelectButtonStraight.performed -= m_Wrapper.m_MapEditorActionsCallbackInterface.OnSelectButtonStraight;
                @SelectButtonStraight.canceled -= m_Wrapper.m_MapEditorActionsCallbackInterface.OnSelectButtonStraight;
                @SelectButtonTurn.started -= m_Wrapper.m_MapEditorActionsCallbackInterface.OnSelectButtonTurn;
                @SelectButtonTurn.performed -= m_Wrapper.m_MapEditorActionsCallbackInterface.OnSelectButtonTurn;
                @SelectButtonTurn.canceled -= m_Wrapper.m_MapEditorActionsCallbackInterface.OnSelectButtonTurn;
                @ShowPauseMenu.started -= m_Wrapper.m_MapEditorActionsCallbackInterface.OnShowPauseMenu;
                @ShowPauseMenu.performed -= m_Wrapper.m_MapEditorActionsCallbackInterface.OnShowPauseMenu;
                @ShowPauseMenu.canceled -= m_Wrapper.m_MapEditorActionsCallbackInterface.OnShowPauseMenu;
                @SelectButtonTJunction.started -= m_Wrapper.m_MapEditorActionsCallbackInterface.OnSelectButtonTJunction;
                @SelectButtonTJunction.performed -= m_Wrapper.m_MapEditorActionsCallbackInterface.OnSelectButtonTJunction;
                @SelectButtonTJunction.canceled -= m_Wrapper.m_MapEditorActionsCallbackInterface.OnSelectButtonTJunction;
                @SelectButtonCrossroad.started -= m_Wrapper.m_MapEditorActionsCallbackInterface.OnSelectButtonCrossroad;
                @SelectButtonCrossroad.performed -= m_Wrapper.m_MapEditorActionsCallbackInterface.OnSelectButtonCrossroad;
                @SelectButtonCrossroad.canceled -= m_Wrapper.m_MapEditorActionsCallbackInterface.OnSelectButtonCrossroad;
                @SelectButtonStart.started -= m_Wrapper.m_MapEditorActionsCallbackInterface.OnSelectButtonStart;
                @SelectButtonStart.performed -= m_Wrapper.m_MapEditorActionsCallbackInterface.OnSelectButtonStart;
                @SelectButtonStart.canceled -= m_Wrapper.m_MapEditorActionsCallbackInterface.OnSelectButtonStart;
                @SelectButtonEnd.started -= m_Wrapper.m_MapEditorActionsCallbackInterface.OnSelectButtonEnd;
                @SelectButtonEnd.performed -= m_Wrapper.m_MapEditorActionsCallbackInterface.OnSelectButtonEnd;
                @SelectButtonEnd.canceled -= m_Wrapper.m_MapEditorActionsCallbackInterface.OnSelectButtonEnd;
                @SelectButtonDelete.started -= m_Wrapper.m_MapEditorActionsCallbackInterface.OnSelectButtonDelete;
                @SelectButtonDelete.performed -= m_Wrapper.m_MapEditorActionsCallbackInterface.OnSelectButtonDelete;
                @SelectButtonDelete.canceled -= m_Wrapper.m_MapEditorActionsCallbackInterface.OnSelectButtonDelete;
            }
            m_Wrapper.m_MapEditorActionsCallbackInterface = instance;
            if (instance != null)
            {
                @PlaceRoad.started += instance.OnPlaceRoad;
                @PlaceRoad.performed += instance.OnPlaceRoad;
                @PlaceRoad.canceled += instance.OnPlaceRoad;
                @RotateOrientation.started += instance.OnRotateOrientation;
                @RotateOrientation.performed += instance.OnRotateOrientation;
                @RotateOrientation.canceled += instance.OnRotateOrientation;
                @SelectButtonStraight.started += instance.OnSelectButtonStraight;
                @SelectButtonStraight.performed += instance.OnSelectButtonStraight;
                @SelectButtonStraight.canceled += instance.OnSelectButtonStraight;
                @SelectButtonTurn.started += instance.OnSelectButtonTurn;
                @SelectButtonTurn.performed += instance.OnSelectButtonTurn;
                @SelectButtonTurn.canceled += instance.OnSelectButtonTurn;
                @ShowPauseMenu.started += instance.OnShowPauseMenu;
                @ShowPauseMenu.performed += instance.OnShowPauseMenu;
                @ShowPauseMenu.canceled += instance.OnShowPauseMenu;
                @SelectButtonTJunction.started += instance.OnSelectButtonTJunction;
                @SelectButtonTJunction.performed += instance.OnSelectButtonTJunction;
                @SelectButtonTJunction.canceled += instance.OnSelectButtonTJunction;
                @SelectButtonCrossroad.started += instance.OnSelectButtonCrossroad;
                @SelectButtonCrossroad.performed += instance.OnSelectButtonCrossroad;
                @SelectButtonCrossroad.canceled += instance.OnSelectButtonCrossroad;
                @SelectButtonStart.started += instance.OnSelectButtonStart;
                @SelectButtonStart.performed += instance.OnSelectButtonStart;
                @SelectButtonStart.canceled += instance.OnSelectButtonStart;
                @SelectButtonEnd.started += instance.OnSelectButtonEnd;
                @SelectButtonEnd.performed += instance.OnSelectButtonEnd;
                @SelectButtonEnd.canceled += instance.OnSelectButtonEnd;
                @SelectButtonDelete.started += instance.OnSelectButtonDelete;
                @SelectButtonDelete.performed += instance.OnSelectButtonDelete;
                @SelectButtonDelete.canceled += instance.OnSelectButtonDelete;
            }
        }
    }
    public MapEditorActions @MapEditor => new MapEditorActions(this);

    // Car
    private readonly InputActionMap m_Car;
    private ICarActions m_CarActionsCallbackInterface;
    private readonly InputAction m_Car_Steer;
    private readonly InputAction m_Car_Accelerate;
    public struct CarActions
    {
        private @Inputs m_Wrapper;
        public CarActions(@Inputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Steer => m_Wrapper.m_Car_Steer;
        public InputAction @Accelerate => m_Wrapper.m_Car_Accelerate;
        public InputActionMap Get() { return m_Wrapper.m_Car; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CarActions set) { return set.Get(); }
        public void SetCallbacks(ICarActions instance)
        {
            if (m_Wrapper.m_CarActionsCallbackInterface != null)
            {
                @Steer.started -= m_Wrapper.m_CarActionsCallbackInterface.OnSteer;
                @Steer.performed -= m_Wrapper.m_CarActionsCallbackInterface.OnSteer;
                @Steer.canceled -= m_Wrapper.m_CarActionsCallbackInterface.OnSteer;
                @Accelerate.started -= m_Wrapper.m_CarActionsCallbackInterface.OnAccelerate;
                @Accelerate.performed -= m_Wrapper.m_CarActionsCallbackInterface.OnAccelerate;
                @Accelerate.canceled -= m_Wrapper.m_CarActionsCallbackInterface.OnAccelerate;
            }
            m_Wrapper.m_CarActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Steer.started += instance.OnSteer;
                @Steer.performed += instance.OnSteer;
                @Steer.canceled += instance.OnSteer;
                @Accelerate.started += instance.OnAccelerate;
                @Accelerate.performed += instance.OnAccelerate;
                @Accelerate.canceled += instance.OnAccelerate;
            }
        }
    }
    public CarActions @Car => new CarActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    public interface IMapEditorActions
    {
        void OnPlaceRoad(InputAction.CallbackContext context);
        void OnRotateOrientation(InputAction.CallbackContext context);
        void OnSelectButtonStraight(InputAction.CallbackContext context);
        void OnSelectButtonTurn(InputAction.CallbackContext context);
        void OnShowPauseMenu(InputAction.CallbackContext context);
        void OnSelectButtonTJunction(InputAction.CallbackContext context);
        void OnSelectButtonCrossroad(InputAction.CallbackContext context);
        void OnSelectButtonStart(InputAction.CallbackContext context);
        void OnSelectButtonEnd(InputAction.CallbackContext context);
        void OnSelectButtonDelete(InputAction.CallbackContext context);
    }
    public interface ICarActions
    {
        void OnSteer(InputAction.CallbackContext context);
        void OnAccelerate(InputAction.CallbackContext context);
    }
}

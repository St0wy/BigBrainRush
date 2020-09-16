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
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // MapEditor
        m_MapEditor = asset.FindActionMap("MapEditor", throwIfNotFound: true);
        m_MapEditor_PlaceRoad = m_MapEditor.FindAction("PlaceRoad", throwIfNotFound: true);
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
    public struct MapEditorActions
    {
        private @Inputs m_Wrapper;
        public MapEditorActions(@Inputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @PlaceRoad => m_Wrapper.m_MapEditor_PlaceRoad;
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
            }
            m_Wrapper.m_MapEditorActionsCallbackInterface = instance;
            if (instance != null)
            {
                @PlaceRoad.started += instance.OnPlaceRoad;
                @PlaceRoad.performed += instance.OnPlaceRoad;
                @PlaceRoad.canceled += instance.OnPlaceRoad;
            }
        }
    }
    public MapEditorActions @MapEditor => new MapEditorActions(this);
    public interface IMapEditorActions
    {
        void OnPlaceRoad(InputAction.CallbackContext context);
    }
}

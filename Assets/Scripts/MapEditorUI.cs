using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MapEditorUI : MonoBehaviour
{
    public Button buttonStraight;
    public Button buttonTurn;
    public Button buttonTJunction;
    public Button buttonCrossroad;
    public Button buttonStart;
    public Button buttonEnd;
    public Button buttonDelete;

    private Inputs inputActions;

    private void Awake()
    {
        inputActions = new Inputs();

        inputActions.MapEditor.SelectButtonStraight.performed += (ctx) =>
        {
            buttonStraight.onClick.Invoke();
            buttonStraight.Select();
        };

        //inputActions.MapEditor.ShowPauseMenu.started += ctx =>
        //{

        //}
    }

    private void Update()
    {
        //Shortcuts for roads type selection
        if (Keyboard.current.digit1Key.IsPressed())
        {
            buttonStraight.onClick.Invoke();
            buttonStraight.Select();
        }
        if (Keyboard.current.digit2Key.IsPressed())
        {
            buttonTurn.onClick.Invoke();
            buttonTurn.Select();
        }
        if (Keyboard.current.digit3Key.IsPressed())
        {
            buttonTJunction.onClick.Invoke();
            buttonTJunction.Select();
        }
        if (Keyboard.current.digit4Key.IsPressed())
        {
            buttonCrossroad.onClick.Invoke();
            buttonCrossroad.Select();
        }
        if (Keyboard.current.digit5Key.IsPressed())
        {
            buttonStart.onClick.Invoke();
            buttonStart.Select();
        }
        if (Keyboard.current.digit6Key.IsPressed())
        {
            buttonEnd.onClick.Invoke();
            buttonEnd.Select();
        }
        if (Keyboard.current.digit7Key.IsPressed())
        {
            buttonDelete.onClick.Invoke();
            buttonDelete.Select();
        }
    }

    private void OnEnable()
    {
        inputActions.MapEditor.Enable();
    }

    private void OnDisable()
    {
        inputActions.MapEditor.Disable();
    }
}

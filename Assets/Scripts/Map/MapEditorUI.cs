/**
 * @file MapEditorUI.cs
 * @author Gawen Ackermann (gawen.ackrmnn@eduge.ch)
 * @brief Contains the MapEditorUI class.
 * @version 1.0
 * @date 08.10.2020
 *
 * @copyright CFPT (c) 2020
 *
 */

using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Handles the UI elements of the map editor.
/// </summary>
public class MapEditorUI : MonoBehaviour
{
    public Button buttonStraight;
    public Button buttonTurn;
    public Button buttonTJunction;
    public Button buttonCrossroad;
    public Button buttonStart;
    public Button buttonEnd;
    public Button buttonDelete;

    public GameObject pauseMenu;

    private Inputs inputActions;

    private bool isBlockPlacable;

    public bool IsBlockPlacable { get => isBlockPlacable; }

    private void Awake()
    {
        inputActions = new Inputs();

        inputActions.MapEditor.SelectButtonStraight.performed += (ctx) =>
        {
            buttonStraight.onClick.Invoke();
            buttonStraight.Select();
        };

        inputActions.MapEditor.SelectButtonTurn.performed += (ctx) =>
        {
            buttonTurn.onClick.Invoke();
            buttonTurn.Select();
        };

        inputActions.MapEditor.SelectButtonTJunction.performed += (ctx) =>
        {
            buttonTJunction.onClick.Invoke();
            buttonTJunction.Select();
        };

        inputActions.MapEditor.SelectButtonCrossroad.performed += (ctx) =>
        {
            buttonCrossroad.onClick.Invoke();
            buttonCrossroad.Select();
        };

        inputActions.MapEditor.SelectButtonStart.performed += (ctx) =>
        {
            buttonStart.onClick.Invoke();
            buttonStart.Select();
            buttonStart.interactable = false;
        };

        inputActions.MapEditor.SelectButtonEnd.performed += (ctx) =>
        {
            buttonEnd.onClick.Invoke();
            buttonEnd.Select();
            buttonEnd.interactable = false;
        };

        inputActions.MapEditor.SelectButtonDelete.performed += (ctx) =>
        {
            buttonDelete.onClick.Invoke();
            buttonDelete.Select();
        };

        inputActions.MapEditor.ShowPauseMenu.started += ctx => TogglePauseMenu();
    }

    /// <summary>
    /// Turns on or off the pause menu.
    /// </summary>
    public void TogglePauseMenu()
    {
        if (pauseMenu.activeSelf == false)
        {
            isBlockPlacable = true;
        }
        else
        {
            isBlockPlacable = false;
        }
        pauseMenu.SetActive(!pauseMenu.activeSelf);
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
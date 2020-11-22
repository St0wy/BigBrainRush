/**
 * @file SceneController.cs
 * @author Gawen Ackermann (gawen.ackrmnn@eduge.ch)
 * @brief Contains the SceneController class.
 * @version 1.0
 * @date 08.10.2020
 *
 * @copyright CFPT (c) 2020
 *
 */

using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Handles everything related to scene changes.
/// </summary>
public class SceneController : MonoBehaviour
{
    public const int ID_SCENE_MAIN_MENU = 0;
    public const int ID_SCENE_MAP_EDITOR = 1;
    public const int ID_SCENE_RACE = 2;

    /// <summary>
    /// Loads the scene with the main menu.
    /// </summary>
    public static void LoadMainMenu()
    {
        SceneManager.LoadScene(ID_SCENE_MAIN_MENU);
    }

    /// <summary>
    /// Loads the scene of the map editor.
    /// </summary>
    public static void LoadMapEditor()
    {
        SceneManager.LoadScene(ID_SCENE_MAP_EDITOR);
    }

    /// <summary>
    /// Loads the race scene.
    /// </summary>
    public static void LoadRaceScene()
    {
        SceneManager.LoadScene(ID_SCENE_RACE);
    }

    /// <summary>
    /// Exits the game.
    /// </summary>
    public static void ExitGame()
    {
        Application.Quit();
    }
}
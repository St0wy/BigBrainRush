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
    private const int ID_SCENE_MAIN_MENU = 0;
    private const int ID_SCENE_MAP_EDITOR = 1;

    public static void LoadMainMenu()
    {
        SceneManager.LoadScene(ID_SCENE_MAIN_MENU);
    }
    public static void LoadMapEditor()
    {
        SceneManager.LoadScene(ID_SCENE_MAP_EDITOR);
    }

    public static void ExitGame()
    {
        Application.Quit();
    }
}

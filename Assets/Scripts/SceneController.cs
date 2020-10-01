using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private const int ID_SCENE_MAIN_MENU = 0;
    private const int ID_SCENE_MAP_EDITOR = 1;

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(ID_SCENE_MAIN_MENU);
    }
    public void LoadMapEditor()
    {
        SceneManager.LoadScene(ID_SCENE_MAP_EDITOR);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

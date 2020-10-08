using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject startSubMenu;
    private MapEditor mapEditor;

    public void DisplayMainMenu() {
        mainMenu.SetActive(true);
        startSubMenu.SetActive(false);
    }

    public void DisplayStartSubMenu()
    {
        mainMenu.SetActive(false);
        startSubMenu.SetActive(true);
    }
}

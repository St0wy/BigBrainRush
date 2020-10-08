/**
 * @file MenuController.cs
 * @author Gawen Ackermann (gawen.ackrmnn@eduge.ch)
 * @brief Contains the MenuController class.
 * @version 1.0
 * @date 08.10.2020
 *
 * @copyright CFPT (c) 2020
 *
 */

using UnityEngine;

/// <summary>
/// Handles the actions of the main menu.
/// </summary>
public class MenuController : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject startSubMenu;

    /// <summary>
    /// Displays the main menu and hides submenues.
    /// </summary>
    public void DisplayMainMenu() {
        mainMenu.SetActive(true);
        startSubMenu.SetActive(false);
    }

    /// <summary>
    /// Displays the start submenu and hides the main menu.
    /// </summary>
    public void DisplayStartSubMenu()
    {
        mainMenu.SetActive(false);
        startSubMenu.SetActive(true);
    }
}

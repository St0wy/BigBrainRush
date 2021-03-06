﻿/**
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
    public void DisplayMainMenu()
    {
        if (mainMenu != null && startSubMenu != null)
        {
            mainMenu.SetActive(true);
            startSubMenu.SetActive(false);
        }
    }

    /// <summary>
    /// Plays the click sound for the main menu buttons.
    /// </summary>
    public void PlaySound()
    {
        //Play the audio
        FindObjectOfType<AudioController>().Play("Click");
    }
}
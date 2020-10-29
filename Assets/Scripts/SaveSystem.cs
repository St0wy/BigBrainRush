/**
 * @file SaveSystem.cs
 * @author Fabian Huber (fabian.hbr@eduge.ch) and Gawen Ackermann (gawen.ackrmnn@eduge.ch)
 * @brief Contains the SaveSystem class.
 * @version 1.0
 * @date 08.10.2020
 *
 * @copyright CFPT (c) 2020
 *
 */

using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;
using UnityEngine;

/// <summary>
/// Handles everything related to saving and loading.
/// </summary>
public static class SaveSystem
{
    private const string EXTENSION = "bbrm";
    private const string WINDOW_TITLE_SAVE = "Choose a folder to save your map";
    private const string WINDOW_TITLE_LOAD = "Choose a folder to save your map";
    private const string DEFAULT_NAME = "my_map";
    private const string DIRECTORY = "";

    /// <summary>
    /// Saves the map to a binary file.
    /// </summary>
    /// <param name="map">Map to save.</param>
    public static void SaveMap(Map map)
    {
        string path = EditorUtility.SaveFilePanel(WINDOW_TITLE_SAVE, DIRECTORY, DEFAULT_NAME, EXTENSION);

        CheckExtension(path);

        BinaryFormatter formatter = new BinaryFormatter();
        using (FileStream fileStream = new FileStream(path, FileMode.Create))
        {
            formatter.Serialize(fileStream, map);
        }
    }

    /// <summary>
    /// Loads a map from a file and returns it.
    /// </summary>
    /// <returns>Returns the loaded file.</returns>
    public static Map LoadMap()
    {
        string path = EditorUtility.OpenFilePanel(WINDOW_TITLE_LOAD, DIRECTORY, EXTENSION);
        CheckExtension(path);
        if (!File.Exists(path))
        {
            Debug.LogError($"\"${path}\" does not exists.");
            return null;
        }

        BinaryFormatter formatter = new BinaryFormatter();
        using (FileStream fileStream = new FileStream(path, FileMode.Open))
        {
            Map map = formatter.Deserialize(fileStream) as Map;
            return map;
        }
    }

    /// <summary>
    /// Checks if the extension of the path is valid.
    /// </summary>
    /// <param name="path">Path to check.</param>
    private static void CheckExtension(string path)
    {
        if (Path.GetExtension(path) != "." + EXTENSION)
            throw new FormatException($"\"{path}\" is not a \"{EXTENSION}\"");
    }
}

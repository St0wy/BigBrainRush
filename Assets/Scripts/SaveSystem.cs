using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using UnityEditor;
using UnityEngine;

public static class SaveSystem
{
    private const string EXTENSION = "bbrm";
    private const string WINDOW_TITLE = "Choose a folder to save your map";
    private const string DEFAULT_NAME = "my_map";
    private const string DIRECTORY = "";

    public static bool SaveMap(Map map)
    {
        //Regex to get only what is between / and .bbrm
        string path = EditorUtility.SaveFilePanel(WINDOW_TITLE, DIRECTORY, DEFAULT_NAME, EXTENSION);

        CheckExtension(path);

        BinaryFormatter formatter = new BinaryFormatter();
        using (FileStream fileStream = new FileStream(path, FileMode.Create))
        {
            formatter.Serialize(fileStream, map);
            return true;
        }
    }

    public static Map LoadMap()
    {
        string path = EditorUtility.OpenFilePanel(WINDOW_TITLE, DIRECTORY, EXTENSION);
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

    private static void CheckExtension(string path)
    {
        if (Path.GetExtension(path) != "." + EXTENSION)
            throw new FormatException($"\"{path}\" is not a \"{EXTENSION}\"");
    }
}

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
    private const string EXTENSION = ".bbrm";
    public static void SaveMap(Map map, string path)
    {
        CheckExtension(path);

        BinaryFormatter formatter = new BinaryFormatter();
        using (FileStream fileStream = new FileStream(path, FileMode.Create))
        {
            formatter.Serialize(fileStream, map);
        }
    }

    public static Map LoadMap(string path)
    {
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
        if (Path.GetExtension(path) != EXTENSION)
            throw new FormatException($"\"{path}\" is not a \"{EXTENSION}\"");
    }
}

using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;

public class SerializeMap : MonoBehaviour
{
    public List<GameObject> roadsPrefabInGrid;
    public List<Road> roads;

    public void Awake()
    {
    }

    public void Serialize(string filename) {
        roads = GetRoadsClassFromPrefab(roadsPrefabInGrid);
        SerializeRoads(filename, roads);
    }

    private void SerializeRoads(string filename, List<Road> pRoads)
    {
        XmlSerializer serializer =
      new XmlSerializer(typeof(Road));
        TextWriter writer = new StreamWriter(filename);
        serializer.Serialize(writer, pRoads);
        writer.Close();
    }

    public List<Road> GetRoadsClassFromPrefab(List<GameObject> pRoadsPrefab) {
        List<Road> roads = new List<Road>();
        foreach (GameObject road in pRoadsPrefab)
        {
            roads.Add(road.GetComponent<Road>());
        }
        return roads;
    }
}

using System.Collections;
using System.Collections.Generic;
using System.IO;
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
        string str = filename;
        string json = "[{";
        json += "\"Roads\":{";

        foreach (Road r in pRoads)
        {
            json += string.Format("id:{0}, roadPrefab:{1}, orientation:\"{2}\"",r._id, r._roadPrefab, r._orientation);
        }
        json += "}]";

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

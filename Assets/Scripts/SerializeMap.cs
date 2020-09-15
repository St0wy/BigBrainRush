using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SerializeMap : MonoBehaviour
{
    public List<GameObject> roadsPrefabInGrid;
    public List<OldRoad> roads;

    public void Awake()
    {
    }

    public void Serialize(string filename) {
        roads = GetRoadsClassFromPrefab(roadsPrefabInGrid);
        SerializeRoads(filename, roads);
    }

    private void SerializeRoads(string filename, List<OldRoad> pRoads)
    {
        string str = filename;
        string json = "[{";
        json += "\"Roads\":{";

        foreach (OldRoad r in pRoads)
        {
            json += string.Format("id:{0}, roadPrefab:{1}, orientation:\"{2}\"",r._id, r._roadPrefab, r._orientation);
        }
        json += "}]";

    }

    public List<OldRoad> GetRoadsClassFromPrefab(List<GameObject> pRoadsPrefab) {
        List<OldRoad> roads = new List<OldRoad>();
        foreach (GameObject road in pRoadsPrefab)
        {
            roads.Add(road.GetComponent<OldRoad>());
        }
        return roads;
    }
}

using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

[Serializable]
[XmlInclude(typeof(Road))]
public class Map
{
    private const int DEFAULT_MAP_SIZE = 25;

    [SerializeField]
    private readonly Road[,] map;
    [SerializeField]
    private string name;

    public int Size => (int)Math.Sqrt(map.Length);

    public string Name { get => name; set => name = value; }

    public Map(Road[,] map)
    {
        this.map = map;
    }

    public Map(int mapSize)
    {
        map = new Road[mapSize, mapSize];
        for (int x = 0; x < mapSize; x++)
        {
            for (int y = 0; y < mapSize; y++)
            {
                map[x, y] = new Road();
            }
        }
    }

    public Map() : this(DEFAULT_MAP_SIZE) { }

    public void SetRoadType(int x, int y, Road.RoadType roadType)
    {
        map[x, y].Type = roadType;
    }

    public Road.RoadType GetRoadType(int x, int y) => map[x, y].Type;

    public Road.RoadOrientation GetRoadOrientation(int x, int y) => map[x, y].Orientation;

    public int GetRoadAngle(int x, int y) => (int)GetRoadOrientation(x, y) * 90;

    public void SetRoadOrientation(int x, int y, Road.RoadOrientation roadOrientation)
    {
        map[x, y].Orientation = roadOrientation;
    }

    public List<Vector2> GetRoadsOfType(Road.RoadType roadType)
    {
        List<Vector2> result = new List<Vector2>();
        //Verify if a specified road type is already placed
        for (int i = 0; i < Size; i++)
        {
            for (int j = 0; j < Size; j++)
            {
                if (map[i, j].Type == roadType)
                {
                    result.Add(new Vector2(i, j));
                }
            }
        }
        result.Sort();
        return result;
    }
}

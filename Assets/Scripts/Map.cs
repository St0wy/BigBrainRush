using System;
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

    public void SetRoadOrientation(int x, int y, Road.RoadOrientation roadOrientation)
    {
        map[x, y].Orientation = roadOrientation;
    }
}

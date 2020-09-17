using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Map
{
    private const int DEFAULT_MAP_SIZE = 25;
    private readonly Road[,] map;

    public int Size => (int)Math.Sqrt(map.Length);

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

    public void SetRoadOrientation(int x, int y, Road.RoadOrientation roadOrientation)
    {
        map[x, y].Orientation = roadOrientation;
    }
}

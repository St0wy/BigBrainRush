using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Map
{
    private const int DEFAULT_MAP_SIZE = 25;
    private Road[,] map;

    public int Size => (int)Math.Sqrt(map.Length);

    public Map(Road[,] map)
    {
        this.map = map;
    }

    public Map(int mapSize) : this(new Road[mapSize, mapSize]) { }

    public Map() : this(DEFAULT_MAP_SIZE) { }

    public void SetRoadType(int x, int y, Road.RoadType roadType)
    {
        map[x, y].Type = roadType;
    }
}

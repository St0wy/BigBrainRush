using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Map
{
    const int DEFAULT_MAP_SIZE = 50;
    Road[,] map;

    public Map(Road[,] map)
    {
        this.map = map;
    }

    public Map(int mapSize) : this(new Road[mapSize, mapSize]) { }

    public Map() : this(DEFAULT_MAP_SIZE) { }
}

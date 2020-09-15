using Assets.Scripts;
using UnityEngine;

class Road
{
    #region Enums
    /// <summary>
    /// Orientation of the road on the grid.
    /// </summary>
    public enum RoadOrientation
    {
        North, South, East, West
    }

    /// <summary>
    /// The type of the road.
    /// </summary>
    public enum RoadType
    {
        Straight, Turn, TJunction, Crossroads, Start, End
    }
    #endregion

    #region Properties
    public RoadOrientation Orientation { get; private set; }
    public RoadType Type { get; private set; }
    public GameObject Prefab
    {
        get
        {
            return RoadAssets.Instance.roadsPrefabs[(int)Type];
        }
    }
    #endregion

    public Road(RoadOrientation orientation, RoadType type)
    {
        Orientation = orientation;
        Type = type;
    }
}

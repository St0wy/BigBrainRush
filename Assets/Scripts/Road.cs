using Assets.Scripts;
using UnityEngine;

public class Road
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
        Straight, Turn, TJunction, Crossroads, Start, End, Empty
    }
    #endregion

    #region Properties
    public RoadOrientation Orientation { get; set; }

    public RoadType Type { get; set; }

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

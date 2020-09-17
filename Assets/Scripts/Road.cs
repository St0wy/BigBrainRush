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

        East, North, West, South
    }

    /// <summary>
    /// The type of the road.
    /// </summary>
    public enum RoadType
    {
        Straight, Turn, TJunction, Crossroads, Start, End, Empty
    }
    #endregion

    private const RoadOrientation DEFAULT_ORIENTATION = RoadOrientation.North;
    private const RoadType DEFAULT_ROAD_TYPE = RoadType.Empty;

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

    public Road() : this (DEFAULT_ORIENTATION, DEFAULT_ROAD_TYPE) { }
}

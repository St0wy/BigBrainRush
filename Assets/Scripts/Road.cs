using Assets.Scripts;
using System;
using UnityEngine;

[Serializable]
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

    [SerializeField]
    private RoadOrientation orientation;
    [SerializeField]
    private RoadType type;

    #region Properties
    public RoadOrientation Orientation { get => orientation; set => orientation = value; }

    public RoadType Type { get => type; set => type = value; }

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

    public Road() : this(DEFAULT_ORIENTATION, DEFAULT_ROAD_TYPE) { }
}

/**
 * @file Road.cs
 * @author Fabian Huber (fabian.hbr@eduge.ch) and Gawen Ackermann (gawen.ackrmnn@eduge.ch)
 * @brief Contains the Road class.
 * @version 1.0
 * @date 08.10.2020
 *
 * @copyright CFPT (c) 2020
 *
 */

using System;
using UnityEngine;

/// <summary>
/// Represents a road with an orientation and a type.
/// </summary>
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

    /// <summary>
    /// Gets the angle in degrees of the road.
    /// </summary>
    public float Angle { get => GetAngle(orientation); }

    /// <summary>
    /// Gets the equivalent angle in degrees of an orientation.
    /// </summary>
    /// <param name="orientation">Orientation to get the angle of.</param>
    /// <returns>Returns the equivalent angle in degrees of an orientation.</returns>
    public static float GetAngle(RoadOrientation orientation)
    {
        return (float)orientation * 90;
    }
}

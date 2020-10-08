/**
 * @file Map.cs
 * @author Fabian Huber (fabian.hbr@eduge.ch) and Gawen Ackermann (gawen.ackrmnn@eduge.ch)
 * @brief Contains the Map class.
 * @version 1.0
 * @date 08.10.2020
 *
 * @copyright CFPT (c) 2020
 *
 */

using System;
using System.Xml.Serialization;
using UnityEngine;

/// <summary>
/// Represents a map that can have races on it. A map can only be a square.
/// </summary>
[Serializable]
[XmlInclude(typeof(Road))]
public class Map
{
    private const int DEFAULT_MAP_SIZE = 25;

    [SerializeField]
    private readonly Road[,] map;
    [SerializeField]
    private string name;

    /// <summary>
    /// Width or height of the map. 
    /// </summary>
    public int Size => (int)Math.Sqrt(map.Length);

    /// <summary>
    /// Name of the map.
    /// </summary>
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

    /// <summary>
    /// Sets the type of a road in the map.
    /// </summary>
    /// <param name="x">X coordinate of the road.</param>
    /// <param name="y">Y coordinate of the road.</param>
    /// <param name="roadType">New type of the road.</param>
    public void SetRoadType(int x, int y, Road.RoadType roadType)
    {
        map[x, y].Type = roadType;
    }

    /// <summary>
    /// Gets the type of a road in the map.
    /// </summary>
    /// <param name="x">X coordinate of the road.</param>
    /// <param name="y">Y coordinate of the road.</param>
    /// <returns>Returns the type of the specified road.</returns>
    public Road.RoadType GetRoadType(int x, int y) => map[x, y].Type;

    /// <summary>
    /// Gets the orientation of the a road in the map.
    /// </summary>
    /// <param name="x">X coordinate of the road.</param>
    /// <param name="y">Y coordinate of the road.</param>
    /// <returns>Returns the orientation of the specified road.</returns>
    public Road.RoadOrientation GetRoadOrientation(int x, int y) => map[x, y].Orientation;

    /// <summary>
    /// Gets the angle in degrees of a road.
    /// </summary>
    /// <param name="x">X coordinate of the road.</param>
    /// <param name="y">Y coordinate of the road.</param>
    /// <returns>Returns the angle in degrees of the specified road.</returns>
    public float GetRoadAngle(int x, int y) => map[x,y].Angle;

    /// <summary>
    /// Sets the orientation of a road in the map.
    /// </summary>
    /// <param name="x">X coordinate of the road.</param>
    /// <param name="y">Y coordinate of the road.</param>
    /// <param name="roadOrientation">New orientation of the road.</param>
    public void SetRoadOrientation(int x, int y, Road.RoadOrientation roadOrientation)
    {
        map[x, y].Orientation = roadOrientation;
    }
}

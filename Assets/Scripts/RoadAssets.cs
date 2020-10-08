/**
 * @file RoadAssets.cs
 * @author Fabian Huber (fabian.hbr@eduge.ch) and Gawen Ackermann (gawen.ackrmnn@eduge.ch)
 * @brief Contains the RoadAssets class.
 * @version 1.0
 * @date 08.10.2020
 *
 * @copyright CFPT (c) 2020
 *
 */

using UnityEngine;

/// <summary>
/// Singleton class to hold all the assets for the roads.
/// </summary>
public class RoadAssets : Singleton<RoadAssets>
{
    /// <summary>
    /// An array with all the prefabs for the roads, the index of a type is described in the Road.RoadType enum.
    /// </summary>
    [Tooltip("An array with all the prefabs for the roads, the index of a type is described in the Road.RoadType enum.")]
    public GameObject[] roadsPrefabs;
}

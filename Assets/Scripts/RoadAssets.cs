using UnityEngine;
using System.Collections;

namespace Assets.Scripts
{
    public class RoadAssets : Singleton<RoadAssets>
    {
        [Tooltip("An array with all the prefabs for the roads, the index of a type is described in the Road.RoadType enum.")]
        public GameObject[] roadsPrefabs;
    }
}
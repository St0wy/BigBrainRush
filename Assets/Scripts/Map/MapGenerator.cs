/**
 * @file MapGenerator.cs
 * @author Fabian Huber (fabian.hbr@eduge.ch) and Gawen Ackermann (gawen.ackrmnn@eduge.ch)
 * @brief Contains the MapGenerator class.
 * @version 1.0
 * @date 08.10.2020
 *
 * @copyright CFPT (c) 2020
 *
 */
using UnityEngine;

/// <summary>
/// Class responsible for generating the map in a scene.
/// </summary>
public class MapGenerator : MonoBehaviour
{
    private const int DEFAULT_MAP_SIZE = 25;

    [Tooltip("Gameobject where all the generated roads are.")]
    public GameObject roads;
    public GameObject plane;
    public int mapSize = DEFAULT_MAP_SIZE;

    
    protected Renderer planeRenderer;
    protected float blockScale;
    protected GameObject[,] blocks;

    protected virtual void Awake()
    {
        //Check if it's unset
        if (mapSize == 0)
            mapSize = DEFAULT_MAP_SIZE;

        planeRenderer = plane.GetComponent<Renderer>();
        
        blockScale = planeRenderer.bounds.size.x / mapSize;

        blocks = new GameObject[mapSize, mapSize];
    }

    /// <summary>
    /// Generate an grid from a Map on scene.
    /// </summary>
    /// <param name="map">The loaded map.</param>
    public void GenerateGrid(Map map)
    {
        //Delete all the existing roads
        foreach (Transform child in roads.transform)
        {
            Destroy(child.gameObject);
        }

        //Recompute the blockScale depending on the loaded map size
        blockScale = planeRenderer.bounds.size.x / map.Size;

        //Generate grid
        for (int x = 0; x < map.Size; x++)
        {
            for (int y = 0; y < map.Size; y++)
            {
                // Compute position
                Vector3 position = MapPointToWorldPoint(x, y);
                Quaternion roadRotation = Quaternion.Euler(0, map.GetRoadAngle(x, y), 0);

                // Instantiate an empty block and changes its size according to the width of the screen
                GameObject blockPrefab = RoadAssets.Instance.roadsPrefabs[(int)map.GetRoadType(x, y)];
                blockPrefab.transform.localScale = new Vector3(blockScale, blockScale, blockScale);
                GameObject instantiatedBlock = Instantiate(blockPrefab, position, roadRotation);

                instantiatedBlock.name = $"Block [{x}][{y}]";
                instantiatedBlock.transform.parent = roads.transform;
                blocks[x, y] = instantiatedBlock;

                // Add block behaviour
                BlockBehaviour blockBehaviour = instantiatedBlock.AddComponent<BlockBehaviour>();
                blockBehaviour.X = x;
                blockBehaviour.Y = y;
            }
        }
    }

    /// <summary>
    /// Maps a point in the grid to a point in the world.
    /// </summary>
    /// <param name="x">X position in the grid.</param>
    /// <param name="y">Y position in the grid.</param>
    /// <returns>Returns the position in the world of the point that's in the grid.</returns>
    public Vector3 MapPointToWorldPoint(int x, int y)
    {
        float posX = plane.transform.position.x - planeRenderer.bounds.size.x / 2 + blockScale / 2;
        float posZ = plane.transform.position.z + planeRenderer.bounds.size.z / 2 - blockScale / 2;

        Vector3 position = new Vector3(posX, plane.transform.position.y, posZ);
        return new Vector3(position.x + x * blockScale, position.y, position.z - y * blockScale);
    }

    public Vector3 MapPointToWorldPoint(Vector2Int pos)
    {
        return MapPointToWorldPoint(pos.x, pos.y);
    }
}

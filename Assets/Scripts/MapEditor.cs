using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public class MapEditor : MonoBehaviour
{
    private const int NO_GRID_SIZE = 0;

    private Map map;
    private Road.RoadType selectedRoadType;

    public Camera mainCamera;
    public int mapSize;
    public int highlightRange;
    public Transform startPosition;

    private void Awake()
    {
        map = mapSize != NO_GRID_SIZE ? new Map() : new Map(mapSize);

        selectedRoadType = Road.RoadType.Empty;
    }

    private void Start()
    {
        GenerateEmptyGrid();
    }

    private void Update()
    {
        // Ray of the mouse from the camera
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        // Launch a raycast with this ray
        if (Physics.Raycast(ray, out RaycastHit hit, highlightRange))
        {
            Debug.DrawRay(ray.origin, ray.direction * 1000, Color.yellow);
            // Check if we hit something
            if (hit.transform == null)
               return;

        //    //BlockBehaviour blockBehaviour = hit.collider.GetComponent<BlockBehaviour>();

        //    //map.SetRoadType(blockBehaviour.X, blockBehaviour.Y, selectedRoadType);
        //    //if (Input.GetMouseButtonDown(0)) { 
                
        //    }

        }
    }

    /// <summary>
    /// Generate an empty gridon the scene.
    /// </summary>
    private void GenerateEmptyGrid() {
        int sizeBlock = mainCamera.scaledPixelWidth / map.Size;
        for (int x = 0; x < map.Size; x++)
        {
            for (int y = 0; y < map.Size; y++)
            {
                // Compute position
                Vector3 position = startPosition.position;
                position = new Vector3(position.x + x * sizeBlock, position.y, position.z - y * sizeBlock);

                // Instantiate an empty block and changes its size according to the width of the screen
                GameObject blockPrefab = RoadAssets.Instance.roadsPrefabs[(int)Road.RoadType.Empty];
                blockPrefab.transform.localScale = new Vector3(sizeBlock, sizeBlock, sizeBlock);
                GameObject instantiatedBlock = Instantiate(blockPrefab, position, Quaternion.identity);
                instantiatedBlock.name = $"Block [{x}][{y}]";
                instantiatedBlock.transform.parent = transform;

                // Add block behaviour
                BlockBehaviour blockBehaviour = instantiatedBlock.AddComponent<BlockBehaviour>();
                blockBehaviour.X = x;
                blockBehaviour.Y = y;
            }
        }
    }

    /// <summary>
    /// Change the selected road type. 
    /// </summary>
    /// <param name="roadType">The number to use is defined in the Road.RoadType enum.</param>
    public void SelectRoadType(int roadType)
    {
        selectedRoadType = (Road.RoadType)roadType;
    }
}

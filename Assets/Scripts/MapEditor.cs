using Assets.Scripts;
using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class MapEditor : MonoBehaviour
{
    private const int DEFAULT_MAP_SIZE = 25;
    private const int DEFAULT_HIGHLIGHT_RANGE = 5000;

    public Camera mainCamera;
    public GameObject plane;
    public GameObject roads;

    [SerializeField]
    private int mapSize;
    [SerializeField]
    private int highlightRange;

    private Map map;
    private Road.RoadType selectedRoadType;
    private Road.RoadOrientation selectedRoadOrientation;
    private Inputs inputs;
    private float blockScale;
    private Renderer planeRenderer;
    private GameObject[,] blocks;

    private void Awake()
    {
        //Check if it's unset
        if (mapSize == 0)
            mapSize = DEFAULT_MAP_SIZE;
        if (highlightRange == 0)
            highlightRange = DEFAULT_HIGHLIGHT_RANGE;

        map = mapSize == 0 ? new Map() : new Map(mapSize);
        blocks = new GameObject[map.Size, map.Size];

        selectedRoadType = Road.RoadType.Empty;
        inputs = new Inputs();

        inputs.MapEditor.PlaceRoad.performed += PlaceRoadPerformed;
        inputs.MapEditor.RotateOrientation.performed += ctx => RotateOrientation((int)ctx.ReadValue<float>());

        planeRenderer = plane.GetComponent<Renderer>();
        blockScale = planeRenderer.bounds.size.x / map.Size;
    }


    public void SaveMap()
    {
        SaveSystem.SaveMap(map);

    }
    public void LoadMap()
    {
        GenerateGrid(SaveSystem.LoadMap());
    }

    private void Start()
    {
        GenerateGrid(map);
    }

    /// <summary>
    /// Places a block at the position of the mouse.
    /// </summary>
    private void PlaceRoadPerformed(InputAction.CallbackContext obj)
    {
        Vector2Int posInGrid = GetMouseCoordinateInMap();
        if (posInGrid.x == -1 || posInGrid.y == -1)
            return;

        // Sets the block in the map object.
        map.SetRoadType(posInGrid.x, posInGrid.y, selectedRoadType);
        map.SetRoadOrientation(posInGrid.x, posInGrid.y, selectedRoadOrientation);

        // Compute block position
        Vector3 roadPos = MapPointToWorldPoint(posInGrid.x, posInGrid.y);
        Quaternion roadRotation = Quaternion.Euler(0, Road.GetAngle(selectedRoadOrientation), 0);

        // Place the new block 
        GameObject road = Instantiate(RoadAssets.Instance.roadsPrefabs[(int)selectedRoadType], roadPos, roadRotation);
        road.transform.parent = roads.transform;
        road.transform.localScale = new Vector3(blockScale, blockScale, blockScale);

        BlockBehaviour newBlockBehaviour = road.AddComponent<BlockBehaviour>();
        newBlockBehaviour.X = posInGrid.x;
        newBlockBehaviour.Y = posInGrid.y;
        road.name = $"Block [{posInGrid.x}] [{posInGrid.y}]";

        // Place road in array
        GameObject oldBlock = blocks[posInGrid.x, posInGrid.y];
        blocks[posInGrid.x, posInGrid.y] = road;

        // Destroy the old block
        Destroy(oldBlock);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    public Vector3 MapPointToWorldPoint(int x, int y)
    {
        float posX = plane.transform.position.x - planeRenderer.bounds.size.x / 2 + blockScale / 2;
        float posZ = plane.transform.position.z + planeRenderer.bounds.size.z / 2 - blockScale / 2;

        Vector3 position = new Vector3(posX, plane.transform.position.y, posZ);
        return new Vector3(position.x + x * blockScale, position.y, position.z - y * blockScale);
    }

    /// <summary>
    /// Get the position in the map of the mouse.
    /// </summary>
    /// <returns>Return the coordinate in the map. Invalid if X and Y are -1.</returns>
    public Vector2Int GetMouseCoordinateInMap()
    {
        Vector2Int mouseCoord = new Vector2Int(-1, -1);

        // Ray of the mouse from the camera
        Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());

        // Launch a raycast with this ray
        if (Physics.Raycast(ray, out RaycastHit hit, highlightRange))
        {
            Debug.DrawRay(ray.origin, ray.direction * 1000, Color.yellow);
            // Check if we hit something
            if (hit.transform != null)
            {
                BlockBehaviour blockBehaviour = hit.collider.GetComponent<BlockBehaviour>();
                if (blockBehaviour != null)
                {
                    mouseCoord = blockBehaviour.Position;
                }
            }
        }

        return mouseCoord;
    }

    /// <summary>
    /// Generate an grid from a Map on scene
    /// </summary>
    /// <param name="map">The loaded map</param>
    private void GenerateGrid(Map map)
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

                map.SetRoadOrientation(blockBehaviour.X, blockBehaviour.Y, selectedRoadOrientation);
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

    /// <summary>
    /// Rotate the orientation for the next road that's going to be placed.
    /// </summary>
    /// <param name="direction"> 
    /// The direction to go to, see Road.RoadOrientation to see the enum that represents it.
    /// If we are at the east, -1 is going to make us to the north and +1 to the south.
    /// </param>
    public void RotateOrientation(int direction)
    {
        int orientationValue = (int)selectedRoadOrientation + direction;
        if (orientationValue < 0)
        {
            orientationValue = 3;
        }
        else if (orientationValue > 3)
        {
            orientationValue = 0;
        }

        SelectOrientation((Road.RoadOrientation)orientationValue);
    }

    /// <summary>
    /// Change the selected orientation.
    /// </summary>
    /// <param name="orientation">The number to use is defined in the Road.RoadOrientation enum.</param>
    public void SelectOrientation(Road.RoadOrientation orientation)
    {
        selectedRoadOrientation = orientation;
    }

    private void OnEnable()
    {
        inputs.MapEditor.Enable();
    }

    private void OnDisable()
    {
        inputs.MapEditor.Disable();
    }
}

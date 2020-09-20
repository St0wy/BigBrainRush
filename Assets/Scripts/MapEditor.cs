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

    private void Awake()
    {
        //Check if it's unset
        if (mapSize == 0)
            mapSize = DEFAULT_MAP_SIZE;
        if (highlightRange == 0)
            highlightRange = DEFAULT_HIGHLIGHT_RANGE;

        map = mapSize == 0 ? new Map() : new Map(mapSize);

        selectedRoadType = Road.RoadType.Empty;
        inputs = new Inputs();

        inputs.MapEditor.PlaceRoad.performed += PlaceRoadPerformed;
        inputs.MapEditor.RotateOrientation.performed += ctx => RotateOrientation((int)ctx.ReadValue<float>());

        planeRenderer = plane.GetComponent<Renderer>();
        blockScale = planeRenderer.bounds.size.x / map.Size;
    }

    private void Update()
    {
        if (Keyboard.current.sKey.IsPressed())
        {
            Debug.Log("Saving ^^");
            SaveSystem.SaveMap(map, $"{Application.persistentDataPath}/mamap.bbrm");
        }
        if (Keyboard.current.lKey.IsPressed())
        {
            Debug.Log("Loading :3");
            // TODO: Load map ^^'
        }
    }

    private void Start()
    {
        GenerateEmptyGrid();
    }

    /// <summary>
    /// Places a block at the position of the mouse.
    /// </summary>
    private void PlaceRoadPerformed(InputAction.CallbackContext obj)
    {
        // Ray of the mouse from the camera
        Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());

        // Launch a raycast with this ray
        if (Physics.Raycast(ray, out RaycastHit hit, highlightRange))
        {
            Debug.DrawRay(ray.origin, ray.direction * 1000, Color.yellow);
            // Check if we hit something
            if (hit.transform == null)
                return;

            // Get the positions of the clicked block
            BlockBehaviour blockBehaviour = hit.collider.GetComponent<BlockBehaviour>();

            // Check if we clicked on an object with a blockBehaviour
            if (blockBehaviour == null)
                return;

            // Sets the block in the map object.
            map.SetRoadType(blockBehaviour.X, blockBehaviour.Y, selectedRoadType);
            map.SetRoadOrientation(blockBehaviour.X, blockBehaviour.Y, selectedRoadOrientation);

            // Place the new block 
            Vector3 roadPos = hit.transform.position;
            Quaternion roadRotation = Quaternion.Euler(0, (int)selectedRoadOrientation * 90, 0);
            GameObject road = Instantiate(RoadAssets.Instance.roadsPrefabs[(int)selectedRoadType], roadPos, roadRotation);
            road.transform.parent = GameObject.FindWithTag("MapEditor").transform;
            road.transform.localScale = new Vector3(blockScale, blockScale, blockScale);
            BlockBehaviour newBlockBehaviour = road.AddComponent<BlockBehaviour>();
            newBlockBehaviour.X = blockBehaviour.X;
            newBlockBehaviour.Y = blockBehaviour.Y;
            road.name = $"Block [{blockBehaviour.X}] [{blockBehaviour.Y}]";


            // Destroy the old block
            Destroy(blockBehaviour.gameObject);
        }
    }

    /// <summary>
    /// Generate an empty gridon the scene.
    /// </summary>
    private void GenerateEmptyGrid()
    {
        for (int x = 0; x < map.Size; x++)
        {
            for (int y = 0; y < map.Size; y++)
            {
                // Compute position
                float posX = plane.transform.position.x - planeRenderer.bounds.size.x / 2 + blockScale / 2;
                float posZ = plane.transform.position.z + planeRenderer.bounds.size.z / 2 - blockScale / 2;

                Vector3 position = new Vector3(posX, plane.transform.position.y, posZ);
                position = new Vector3(position.x + x * blockScale, position.y, position.z - y * blockScale);

                // Instantiate an empty block and changes its size according to the width of the screen
                GameObject blockPrefab = RoadAssets.Instance.roadsPrefabs[(int)map.GetRoadType(x, y)];
                blockPrefab.transform.localScale = new Vector3(blockScale, blockScale, blockScale);
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

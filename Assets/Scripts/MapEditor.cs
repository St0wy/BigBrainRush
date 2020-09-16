using Assets.Scripts;
using UnityEngine;
using UnityEngine.InputSystem;

public class MapEditor : MonoBehaviour
{
    private const int NO_GRID_SIZE = 0;

    public Camera mainCamera;
    public int mapSize;
    public int highlightRange;
    public Transform startPosition;

    private Map map;
    private Road.RoadType selectedRoadType;
    private Inputs inputs;
    private int blockScale;

    private void Awake()
    {
        map = mapSize == NO_GRID_SIZE ? new Map() : new Map(mapSize);

        selectedRoadType = Road.RoadType.Empty;
        inputs = new Inputs();

        inputs.MapEditor.PlaceRoad.performed += PlaceRoadPerformed;
        blockScale = mainCamera.scaledPixelWidth / map.Size;
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
            Debug.Log($"X : {blockBehaviour.X}, Y : {blockBehaviour.Y}");

            // Check if we clicked on an object with a blockBehaviour
            if (blockBehaviour == null)
                return;

            // Sets the block in the map object.
            map.SetRoadType(blockBehaviour.X, blockBehaviour.Y, selectedRoadType);

            // Place the new block 
            Vector3 roadPos = hit.transform.position;
            GameObject road = Instantiate(RoadAssets.Instance.roadsPrefabs[(int)selectedRoadType], roadPos, Quaternion.identity);
            road.transform.localScale = new Vector3(blockScale, blockScale, blockScale);
            BlockBehaviour newBlockBehaviour = road.AddComponent<BlockBehaviour>();
            newBlockBehaviour.X = blockBehaviour.X;
            newBlockBehaviour.Y = blockBehaviour.Y;


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
                Vector3 position = startPosition.position;
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

    private void OnEnable()
    {
        inputs.MapEditor.Enable();
    }

    private void OnDisable()
    {
        inputs.MapEditor.Disable();
    }
}

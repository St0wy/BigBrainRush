/**
 * @file MapEditor.cs
 * @author Fabian Huber (fabian.hbr@eduge.ch) and Gawen Ackermann (gawen.ackrmnn@eduge.ch)
 * @brief Contains the MapEditor class.
 * @version 1.0
 * @date 08.10.2020
 *
 * @copyright CFPT (c) 2020
 *
 */
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

/// <summary>
/// Mono behaviour that handles everyting related to the map editor.
/// </summary>
public class MapEditor : MapGenerator
{
    private const int DEFAULT_MAP_SIZE = 25;
    private const int DEFAULT_HIGHLIGHT_RANGE = 5000;

    public Camera mainCamera;
    public MapEditorUI mapEditorUI;
    public LayerMask wallLayer;

    [SerializeField]
    private int highlightRange;

    private Road.RoadType selectedRoadType;
    private Road.RoadOrientation selectedRoadOrientation;
    private Inputs inputs;
    private Map map;


    protected override void Awake()
    {
        base.Awake();

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

    /// <summary>
    /// Saves the map.
    /// </summary>
    public void SaveMap()
    {
        SaveSystem.SaveMap(map);
    }

    /// <summary>
    /// Loads the map from a file.
    /// </summary>
    public void LoadMap()
    {
        map = SaveSystem.LoadMap();
        GenerateGrid(map);
    }

    private void Start()
    {
        GenerateGrid(map);
    }

    /// <summary>
    /// Checks if the the provided button has road of his type placed. If yes, it disable it.
    /// </summary>
    /// <param name="type">Selected road type.</param>
    /// <param name="button">Button assiociated to this type.</param>
    /// <returns>Returns if the button is interactable or not.</returns>
    public bool CheckUniqueButtonsActivation(Road.RoadType type, Button button)
    {
        button.interactable = false;
        if (map.GetRoadsOfType(type).Count == 0)
        {
            button.interactable = true;
        }
        return button.interactable;
    }

    /// <summary>
    /// Places a block at the position of the mouse.
    /// </summary>
    private void PlaceRoadPerformed(InputAction.CallbackContext _)
    {
        Vector2Int posInGrid = GetMouseCoordinateInMap();
        if (posInGrid.x == -1 || posInGrid.y == -1 || mapEditorUI.IsBlockPlacable)
            return;

        if (!CheckUniqueButtonsActivation(Road.RoadType.Start, mapEditorUI.buttonStart))
        {
            if (selectedRoadType == Road.RoadType.Start)
                return;
        }
        if (!CheckUniqueButtonsActivation(Road.RoadType.End, mapEditorUI.buttonEnd))
        {
            if (selectedRoadType == Road.RoadType.End)
                return;
        }

        string nameOfAudioToPlay = "BlockPlaced";
        if (selectedRoadType == Road.RoadType.Empty) {
            nameOfAudioToPlay = "BlockRemoved";
        }

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

        //Verify if we can enable the button for the start and end
        CheckUniqueButtonsActivation(Road.RoadType.Start, mapEditorUI.buttonStart);
        CheckUniqueButtonsActivation(Road.RoadType.End, mapEditorUI.buttonEnd);

        //Play the audio
        FindObjectOfType<AudioController>().Play(nameOfAudioToPlay);

        // Destroy the old block
        Destroy(oldBlock);
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
        if (Physics.Raycast(ray, out RaycastHit hit, highlightRange, ~wallLayer))
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
        //Play the audio
        FindObjectOfType<AudioController>().Play("BlockOrientationChanged");
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

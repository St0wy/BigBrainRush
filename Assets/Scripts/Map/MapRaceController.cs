/**
 * @file MapRaceController.cs
 * @author Fabian Huber (fabian.hbr@eduge.ch)
 * @brief Contains the MapRaceController class.
 * @version 1.0
 * @date 22.11.2020
 *
 * @copyright CFPT (c) 2020
 *
 */
using UnityEngine;

/// <summary>
/// Handles the loading of a map on the race scene.
/// </summary>
[RequireComponent(typeof(MapGenerator))]
public class MapRaceController : MonoBehaviour
{
    public const float CAR_OFFSET = 5f;
    public const float CAR_ANGLE_OFFSET = 180f;

    public Camera mainCam;
    public GameObject car;

    private MapGenerator generator;
    private Map map;

    private void Awake()
    {
        generator = GetComponent<MapGenerator>();
    }

    private void Start()
    {
        LoadMap();
        mainCam.clearFlags = CameraClearFlags.Skybox;
    }

    /// <summary>
    /// Loads the map from a file.
    /// </summary>
    public void LoadMap()
    {
        // Loads the file of the map
        map = SaveSystem.LoadMap();

        // Generates the map on the scene
        generator.GenerateGrid(map);

        // Sets the start point of the car
        Road startRoad = map.Start;
        Vector2Int startCoordinate = map.GetCoordinate(startRoad);
        Vector3 startPos = generator.MapPointToWorldPoint(startCoordinate);
        startPos.y += CAR_OFFSET;
        car.transform.position = startPos;
        float angle = map.GetRoadAngle(startCoordinate.x, startCoordinate.y);
        car.transform.rotation = Quaternion.Euler(
            car.transform.rotation.eulerAngles.x,
            angle + CAR_ANGLE_OFFSET,
            car.transform.rotation.eulerAngles.z);
        car.gameObject.SetActive(true);
    }
}
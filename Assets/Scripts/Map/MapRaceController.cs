using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        Debug.Log(startRoad);
        Vector3 startPos = generator.MapPointToWorldPoint(startCoordinate);
        startPos.y += CAR_OFFSET;
        car.transform.position = startPos;
        float angle = map.GetRoadAngle(startCoordinate.x, startCoordinate.y);
        Debug.Log($"Angle : {angle + CAR_ANGLE_OFFSET}");
        car.transform.rotation = Quaternion.Euler(
            car.transform.rotation.eulerAngles.x,
            angle + CAR_ANGLE_OFFSET,
            car.transform.rotation.eulerAngles.z);
        car.gameObject.SetActive(true);
    }
}

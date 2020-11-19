using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(MapGenerator))]
class MapIARace : MonoBehaviour
{
    public const float CAR_OFFSET = 5f;

    public GameObject car;
    public string mapName = "trainMap.bbrm";
    public Camera mainCam;

    private MapGenerator generator;
    private Map map;

    private void Awake()
    {
        generator = GetComponent<MapGenerator>();
    }

    private void Start()
    {
        map = SaveSystem.LoadMap($"{Application.dataPath}/Maps/{mapName}");
        generator.GenerateGrid(map);
        Vector2Int startCoordinate = map.GetCoordinate(map.Start);
        Vector3 startPos = generator.MapPointToWorldPoint(startCoordinate);
        startPos.y += CAR_OFFSET;
        car.transform.position = startPos;
        float angle = map.GetRoadAngle(startCoordinate.x, startCoordinate.y);
        car.transform.rotation = Quaternion.Euler(
            car.transform.rotation.eulerAngles.x,
            angle + 90,
            car.transform.rotation.eulerAngles.z);
        car.gameObject.SetActive(true);
        mainCam.clearFlags = CameraClearFlags.Skybox;
    }
}

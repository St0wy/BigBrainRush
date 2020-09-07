using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateGrid : MonoBehaviour
{
    private const int GRID_SIZE = 25;

    public GameObject roadPrefab;
    public GameObject[,] roads = new GameObject[GRID_SIZE, GRID_SIZE];
    public Camera mainCamera;
    public Transform startPos;

    void Start()
    {
        InitGrid(roadPrefab, GRID_SIZE, mainCamera);
    }
    /// <summary>
    /// Initialise la grille
    /// </summary>
    /// <param name="pRoads">La liste des prefabs de routes</param>
    /// <param name="sizeGrid">la taille de la grille</param>
    /// <param name="cam">la caméra</param>
    public void InitGrid(GameObject pRoads, int sizeGrid, Camera cam)
    {
        GameObject go = pRoads;
        int sizeBlock = cam.scaledPixelWidth / sizeGrid;
        go.transform.localScale = new Vector3(sizeBlock, sizeBlock, sizeBlock);
        for (int x = 0; x < sizeGrid; x++)
        {
            for (int y = 0; y < sizeGrid; y++)
            {
                GameObject instantiatedPrefab = Instantiate(go, new Vector3(startPos.transform.position.x + x * sizeBlock, startPos.transform.position.y, startPos.transform.position.z - y * sizeBlock), Quaternion.identity);
                instantiatedPrefab.name = string.Format("Road [{0}][{1}]", x,y);
                Road refRoad = instantiatedPrefab.AddComponent<Road>() as Road;
                refRoad.InitRoad(instantiatedPrefab, Orientation.North);
                instantiatedPrefab.transform.parent = GameObject.Find("Grid Generation").transform;
            }
        }
    }



    // Update is called once per frame
    void Update()
    {

    }
}

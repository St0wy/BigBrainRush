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
    public List<GameObject> roadsPrefab;

    void Start()
    {
        SetPrefabsSize(roadsPrefab, GRID_SIZE, mainCamera);
        InitGrid(roadPrefab, GRID_SIZE, mainCamera);
    }
    /// <summary>
    /// Initialise la grille
    /// </summary>
    /// <param name="pRoad">La liste des prefabs de routes</param>
    /// <param name="sizeGrid">la taille de la grille</param>
    /// <param name="cam">la caméra</param>
    public void InitGrid(GameObject pRoad, int sizeGrid, Camera cam)
    {
        GameObject go = pRoad;
       int sizeBlock = cam.scaledPixelWidth / sizeGrid;
        
        for (int x = 0; x < sizeGrid; x++)
        {
            for (int y = 0; y < sizeGrid; y++)
            {
                GameObject instantiatedPrefab = (GameObject)Instantiate(go, new Vector3(startPos.transform.position.x + x * sizeBlock, startPos.transform.position.y, startPos.transform.position.z - y * sizeBlock), Quaternion.identity);
                instantiatedPrefab.name = string.Format("Road [{0}][{1}]", x,y);
                //instantiatedPrefab.transform.localScale = new Vector3(sizeBlock, sizeBlock, sizeBlock);
                Road refRoad = instantiatedPrefab.AddComponent<Road>() as Road;
                refRoad.InitRoad(instantiatedPrefab, Orientation.North);
                instantiatedPrefab.transform.parent = GameObject.Find("Grid Generation").transform;
            }
        }
    }

    private void SetPrefabsSize(List<GameObject> pRoads, int sizeGrid, Camera cam)
    {
        int sizeBlock = cam.scaledPixelWidth / sizeGrid;
        foreach (GameObject go in pRoads)
        {
            go.transform.localScale = new Vector3(sizeBlock, sizeBlock, sizeBlock);
        }
    }
}

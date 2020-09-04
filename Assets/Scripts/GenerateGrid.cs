using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateGrid : MonoBehaviour
{
    private const int GRID_SIZE = 25;

    private Color baseColor;

    public List<GameObject> roadsPrefab;
    public GameObject[,] roads = new GameObject[GRID_SIZE, GRID_SIZE];
    public Camera mainCamera;
    public Transform startPos;

    void Start()
    {
        if (roadsPrefab == null)
        {
            roadsPrefab = new List<GameObject>();
        }
        InitGrid(roadsPrefab, GRID_SIZE, mainCamera);
    }
    /// <summary>
    /// Initialise la grille
    /// </summary>
    /// <param name="pRoads">La liste des prefabs de routes</param>
    /// <param name="sizeGrid">la taille de la grille</param>
    /// <param name="cam">la caméra</param>
    private void InitGrid(List<GameObject> pRoads, int sizeGrid, Camera cam)
    {
        GameObject go = pRoads[3];
        int sizeBlock = cam.scaledPixelWidth / sizeGrid;
        go.transform.localScale = new Vector3(sizeBlock, sizeBlock, sizeBlock);
        for (int x = 0; x < sizeGrid; x++)
        {
            for (int y = 0; y < sizeGrid; y++)
            {
                GameObject instantiatedPrefab = Instantiate(go, new Vector3(startPos.transform.position.x + x * sizeBlock, startPos.transform.position.y, startPos.transform.position.z - y * sizeBlock), Quaternion.identity);
            }
        }
    }



    // Update is called once per frame
    void Update()
    {

    }
}

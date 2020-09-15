using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeRoadBlock : MonoBehaviour
{
    public List<GameObject> roadsInGrid;
    public GameObject selectedRoad;
    public GameObject roadPrefab;
    public float dist;
    public SerializeMap sm;

    private void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        HandleLookAtRay();
    }

    private void HandleLookAtRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, dist))
        {
            Debug.DrawRay(ray.origin, ray.direction * 1000, Color.green);
            if (hit.transform != null)
            {
                if (hit.collider.CompareTag("Interact"))
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        selectedRoad = hit.collider.gameObject;
                        ReplacingBlock(roadPrefab);
                    }
                }
            }
        }
    }

    public void ReplacingBlock(GameObject pRoadPrefab)
    {
        ChangeRoad(pRoadPrefab, roadsInGrid);
    }

    public void ChangeRoad(GameObject pRoadPrefab, List<GameObject> roads)
    {

        if (pRoadPrefab == null)
        {
            roadPrefab = selectedRoad;
        }
        else
        {
            roadPrefab = pRoadPrefab;
        }
        GameObject oldRoad = selectedRoad;

        OldRoad refRoad = selectedRoad.GetComponent<OldRoad>();
        OldRoad oldRefRoad = oldRoad.GetComponent<OldRoad>();


        if (EventSystem.current.currentSelectedGameObject != null)
        {
            switch (EventSystem.current.currentSelectedGameObject.name)
            {
                case "Start":
                    selectedRoad = pRoadPrefab;
                    break;
                case "End":
                    selectedRoad = pRoadPrefab;
                    break;
                case "Straight":
                    selectedRoad = pRoadPrefab;
                    break;
                case "Corner":
                    selectedRoad = pRoadPrefab;
                    break;
                case "TJunction":
                    selectedRoad = pRoadPrefab;
                    break;
                case "CrossJunction":
                    selectedRoad = pRoadPrefab;
                    break;
                case "ResetGrid":
                    Scene scene = SceneManager.GetActiveScene();
                    SceneManager.LoadScene(scene.name);
                    break;
                case "RemoveRoad":
                    selectedRoad = pRoadPrefab;
                    break;
                default: break;
            }
            refRoad._id = oldRefRoad._id;
            roads.RemoveAt(oldRefRoad._id);
            roads.Insert(refRoad._id, selectedRoad);
            sm = GameObject.Find("Serialize").GetComponent<SerializeMap>();
            if (sm != null)
            {
                sm.roadsPrefabInGrid = roads;
            }
            GameObject newRoad = (GameObject)Instantiate(selectedRoad, oldRoad.transform.position, quaternion.identity);
            if (newRoad.gameObject.GetComponent<OldRoad>() == null)
            {
                newRoad.gameObject.AddComponent<OldRoad>().InitRoad(newRoad.gameObject);
            }
            selectedRoad = newRoad;
            oldRoad.SetActive(false);
        }
    }
}

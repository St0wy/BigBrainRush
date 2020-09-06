using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChangeRoadBlock : MonoBehaviour
{
    public GameObject selectedRoad;
    public GameObject roadPrefab;
    public float dist;
    void Start()
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
                        ChangeRoad(roadPrefab);
                    }
                }
            }
        }
    }

    public void ChangeRoad(GameObject pRoadPrefab)
    {
        Road refRoad = selectedRoad.GetComponent<Road>();
        Quaternion roadRotation = quaternion.identity;
        Orientation roadOrientation = Orientation.North;
        if (pRoadPrefab == null)
        {
            roadPrefab = selectedRoad;
        }
        else
        {
            roadPrefab = pRoadPrefab;
        }
        GameObject oldRoad = selectedRoad;

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
                case "Orientation North":
                    selectedRoad = refRoad.ChangeOrientation(Orientation.North);
                    roadRotation = selectedRoad.transform.rotation;
                    roadOrientation = Orientation.North;
                    break;
                case "Orientation East":
                    selectedRoad = refRoad.ChangeOrientation(Orientation.East);
                    roadRotation = selectedRoad.transform.rotation;
                    roadOrientation = Orientation.East;
                    break;
                case "Orientation South":
                    selectedRoad = refRoad.ChangeOrientation(Orientation.South);
                    roadRotation = selectedRoad.transform.rotation;
                    roadOrientation = Orientation.South;
                    break;
                case "Orientation West":
                    selectedRoad = refRoad.ChangeOrientation(Orientation.West);
                    roadRotation = selectedRoad.transform.rotation;
                    roadOrientation = Orientation.West;
                    break;
                case "Reset":
                    Debug.LogError("IL FAUDRAIT REGEN LA GRILLE EN FAIT");
                    break;
                default: break;
            }

            GameObject newRoad = Instantiate(selectedRoad, oldRoad.transform.position, roadRotation);
            refRoad = newRoad.AddComponent<Road>();
            newRoad.name = selectedRoad.name;

            refRoad = refRoad.InitRoad(newRoad.gameObject, roadOrientation);

            selectedRoad = newRoad;

            oldRoad.SetActive(false);
        }
    }
}

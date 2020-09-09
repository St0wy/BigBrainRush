using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeRoadBlock : MonoBehaviour
{
    public GameObject selectedRoad;
    public GameObject roadPrefab;
    public float dist;

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
                case "ResetGrid":
                    Scene scene = SceneManager.GetActiveScene();
                    SceneManager.LoadScene(scene.name);
                    break;
                case "RemoveRoad":
                    selectedRoad = pRoadPrefab;
                    break;
                default: break;
            }

            GameObject newRoad = (GameObject)Instantiate(selectedRoad, oldRoad.transform.position, quaternion.identity);
            if (newRoad.gameObject.GetComponent<Road>() == null)
            {
                newRoad.gameObject.AddComponent<Road>().InitRoad(newRoad.gameObject);
            }
            selectedRoad = newRoad;
            oldRoad.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChangeRoadOrientation : MonoBehaviour
{
    public GameObject selectedRoad;
    public float dist;
    void Awake()
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
                    }
                }
            }
        }
    }

    public void SelectOrientation(string pOrientation) {
        switch (pOrientation)
        {
            case "North":
                ChangeOrientation(selectedRoad, Orientation.North);
                break;
            case "East":
                ChangeOrientation(selectedRoad, Orientation.East);

                break;
            case "South":
                ChangeOrientation(selectedRoad, Orientation.South);

                break;
            case "West":
                ChangeOrientation(selectedRoad, Orientation.West);
                break;
            default:
                break;
        }
    }

    public GameObject ChangeOrientation(GameObject roadToRotate, Orientation pOrientation)
    {
        if (roadToRotate != null)
        {
            switch (pOrientation)
            {
                case Orientation.North:
                    selectedRoad = roadToRotate.gameObject.GetComponent<Road>().ChangeOrientation(pOrientation);
                    break;
                case Orientation.East:
                    selectedRoad = roadToRotate.gameObject.GetComponent<Road>().ChangeOrientation(pOrientation);
                    break;
                case Orientation.South:
                    selectedRoad = roadToRotate.gameObject.GetComponent<Road>().ChangeOrientation(pOrientation);
                    break;
                case Orientation.West:
                    selectedRoad = roadToRotate.gameObject.GetComponent<Road>().ChangeOrientation(pOrientation);
                    break;
                default:
                    break;
            }
        }
        return selectedRoad;
    }
}

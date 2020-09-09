using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChangeRoadOrientation : MonoBehaviour
{
    public GameObject selectedRoad;
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
                    if (Input.GetMouseButtonDown(1))
                    {
                        selectedRoad = hit.collider.gameObject;
                        ChangeOrientation(selectedRoad);
                        Debug.Log(selectedRoad);
                        Debug.Log(selectedRoad.GetComponent<Road>()._orientation);
                    }
                }
            }
        }
    }

    public void ChangeOrientation(GameObject roadToRotate)
    {
        GameObject clickedButton = EventSystem.current.currentSelectedGameObject.gameObject;
        if (clickedButton != null)
        {
            if (roadToRotate != null)
            {
                Debug.Log("javel");
                switch (EventSystem.current.currentSelectedGameObject.name)
                {
                    case "Orientation North":
                        selectedRoad = roadToRotate.gameObject.GetComponent<Road>().ChangeOrientation(Orientation.North);
                        break;
                    case "Orientation East":
                        selectedRoad = roadToRotate.gameObject.GetComponent<Road>().ChangeOrientation(Orientation.East);
                        break;
                    case "Orientation South":
                        selectedRoad = roadToRotate.gameObject.GetComponent<Road>().ChangeOrientation(Orientation.South);
                        break;
                    case "Orientation West":
                        selectedRoad = roadToRotate.gameObject.GetComponent<Road>().ChangeOrientation(Orientation.West);
                        break;
                }
            }
        }
    }
}

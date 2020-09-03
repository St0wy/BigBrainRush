using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineLookat : MonoBehaviour
{
    public Camera cam;
    public float dist;

    private OutlineController previousController;
    private OutlineController currentController;



    private void Update()
    {
        HandleLookAtRay();
    }
    private void HandleLookAtRay() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, dist))
        {
            if (hit.transform != null) {
                Vector3 oldPos = hit.transform.position;
                if (hit.collider.CompareTag("Interact"))
                {
                    hit.transform.position = new Vector3(hit.transform.position.x, hit.transform.position.y + 20, hit.transform.position.z);
                    currentController = hit.collider.GetComponent<OutlineController>();

                    if (previousController != currentController)
                    {
                        HideOutline();
                        ShowOutline();
                    }
                    previousController = currentController;
                }
                else
                {
                    hit.transform.position = new Vector3(oldPos.x, oldPos.y - 20, oldPos.z);
                    HideOutline();
                }
            }
        }
        else {
            HideOutline();
        }
    }

    private void ShowOutline() {
        if (currentController != null) {
            currentController.ShowOutline();
        }
    }
    private void HideOutline() {
        if (previousController != null)
        {
            previousController.HideOutline();
            previousController = null;
        }
    }
}

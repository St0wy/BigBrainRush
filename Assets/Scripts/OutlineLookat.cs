using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class OutlineLookat : MonoBehaviour
{
    public Camera cam;
    public float dist;

    private bool blockUp;
    private OutlineController previousController;
    private OutlineController currentController;


    private void Update()
    {
        HandleLookAtRay();
    }
    private void HandleLookAtRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, dist))
        {
            Debug.DrawRay(ray.origin, ray.direction * 1000, Color.yellow);
            if (hit.transform != null)
            {
                if (hit.collider.CompareTag("Interact"))
                {
                    if (Input.GetMouseButtonDown(0)) { 
                        
                    }

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
                    HideOutline();
                }
            }
        }
        else
        {
            HideOutline();

        }
    }

    private void ShowOutline()
    {
        if (currentController != null)
        {
            currentController.ShowOutline();
        }
    }
    private void HideOutline()
    {
        if (previousController != null)
        {
            previousController.HideOutline();
            previousController = null;
        }
    }
}

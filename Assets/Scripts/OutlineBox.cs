using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineBox : MonoBehaviour
{
    public GameObject go;

    void OnMouseEnter()
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        go.GetComponent<Renderer>().material.SetShaderPassEnabled("Custom/chr_outline", true);
    }
    void OnMouseExit()
    {
        go.GetComponent<Renderer>().material.SetShaderPassEnabled("Custom/chr_outline", false);
    }
}

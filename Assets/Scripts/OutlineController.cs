using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineController : MonoBehaviour
{
    private MeshRenderer renderer;

    public float maxOutlineWidth;

    public Color outlineColor;


    private void Start()
    {
        renderer = GetComponent<MeshRenderer>();
    }

    public void ShowOutline()
    {
        renderer.material.SetFloat("_OutlineWidth", maxOutlineWidth);
        renderer.material.SetColor("_OutlineColor", outlineColor);
    }public void HideOutline()
    {
        renderer.material.SetFloat("_OutlineWidth", 0f);
    }
}

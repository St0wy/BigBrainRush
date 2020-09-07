using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineController : MonoBehaviour
{
    private MeshRenderer meshRenderer;

    public float maxOutlineWidth;

    public Color outlineColor;


    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    public void ShowOutline()
    {
        meshRenderer.material.SetFloat("_OutlineWidth", maxOutlineWidth);
        meshRenderer.material.SetColor("_OutlineColor", outlineColor);
    }public void HideOutline()
    {
        meshRenderer.material.SetFloat("_OutlineWidth", 0f);
    }
}

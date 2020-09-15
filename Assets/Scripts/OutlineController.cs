using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class OutlineController : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    public float maxOutlineWidth;
    public Color outlineColor;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    /// <summary>
    /// Shows the outline of the mesh of the game object.
    /// </summary>
    public void ShowOutline()
    {
        meshRenderer.material.SetFloat("_OutlineWidth", maxOutlineWidth);
        meshRenderer.material.SetColor("_OutlineColor", outlineColor);
    }

    /// <summary>
    /// Hides the outline.
    /// </summary>
    public void HideOutline()
    {
        meshRenderer.material.SetFloat("_OutlineWidth", 0f);
    }
}

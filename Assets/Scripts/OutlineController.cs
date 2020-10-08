/**
 * @file OutlineController.cs
 * @author Gawen Ackermann (gawen.ackrmnn@eduge.ch)
 * @brief Contains the OutlineController class.
 * @version 1.0
 * @date 08.10.2020
 *
 * @copyright CFPT (c) 2020
 *
 */

using UnityEngine;

/// <summary>
/// Handles the displayal of outlines.
/// </summary>
[RequireComponent(typeof(MeshRenderer))]
public class OutlineController : MonoBehaviour
{
    public float maxOutlineWidth;
    public Color outlineColor;

    private MeshRenderer meshRenderer;

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

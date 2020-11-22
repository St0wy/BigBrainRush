/**
 * @file BlockBehaviour.cs
 * @author Fabian Huber (fabian.hbr@eduge.ch) and Gawen Ackermann (gawen.ackrmnn@eduge.ch)
 * @brief Contains the BlockBehaviour class.
 * @version 1.0
 * @date 08.10.2020
 *
 * @copyright CFPT (c) 2020
 *
 */

using UnityEngine;

/// <summary>
/// Behaviour that's placed on blocks (or roads) in the map editor.
/// </summary>
public class BlockBehaviour : MonoBehaviour
{
    [SerializeField]
    [Tooltip("X position in the map of the block.")]
    private int x;

    [SerializeField]
    [Tooltip("Y position in the map of the block.")]
    private int y;

    /// <summary>
    /// X position in the map of the block.
    /// </summary>
    public int X { get => x; set => x = value; }

    /// <summary>
    /// Y position in the map of the block.
    /// </summary>
    public int Y { get => y; set => y = value; }

    /// <summary>
    /// Position in the map of the block.
    /// </summary>
    public Vector2Int Position { get => new Vector2Int(X, Y); }
}
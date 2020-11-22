/**
 * @file Sound.cs
 * @author Gawen Ackermann (gawen.ackrmnn@eduge.ch)
 * @brief Contains the Sound class.
 * @version 1.0
 * @date 22.11.2020
 *
 * @copyright CFPT (c) 2020
 *
 */

using System;
using UnityEngine;

/// <summary>
/// Represents a sound and how it should be played.
/// </summary>
[Serializable]
public class Sound
{
    [NonSerialized]
    public AudioClip clip;
    public string name;

    [Range(0f, 1f)]
    public float volume;

    [Range(.3f, 3f)]
    public float pitch;

    [NonSerialized]
    public AudioSource source;
}

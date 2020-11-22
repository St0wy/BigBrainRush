/**
 * @file AudioController.cs
 * @author Gawen Ackermann (gawen.ackrmnn@eduge.ch)
 * @brief Contains the AudioController class.
 * @version 1.0
 * @date 22.11.2020
 *
 * @copyright CFPT (c) 2020
 *
 */

using System;
using UnityEngine;

/// <summary>
/// Handles everything related to audio.
/// </summary>
public class AudioController : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioController instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }

    /// <summary>
    /// Plays the specified sound.
    /// </summary>
    /// <param name="name">Name of the sound to play.</param>
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }
}
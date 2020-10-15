using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Audio;

namespace Assets.Scripts
{
    [System.Serializable]
    public class Sound
    {
        public AudioClip clip;
        public string name;
        [Range(0f, 1f)]
        public float volume;
        [Range(.3f, 3f)]
        public float pitch;

        public AudioSource source;

    }
}

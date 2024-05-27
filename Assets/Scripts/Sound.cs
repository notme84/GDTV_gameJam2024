using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    [HideInInspector]public AudioSource audioSource;
    public AudioClip[] audioClips;
    public string clipName;
    [Range(0,1)]public float volume = 0.5f;
    public float pitch;
    public bool playOnAwake;
    public bool loop;

}

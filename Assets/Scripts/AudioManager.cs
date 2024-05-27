using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //serialfield allows us to see the variable in the inspector
    [SerializeField] private Sound[] sounds;

    private void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.audioSource = gameObject.AddComponent<AudioSource>();
            s.audioSource.clip = s.audioClips[0];
            s.audioSource.volume = s.volume;
            s.audioSource.pitch = s.pitch;
            s.audioSource.loop = s.loop;
            s.audioSource.playOnAwake = s.playOnAwake;

            if (s.playOnAwake)
            {
                s.audioSource.Play();
            }
        }
    }

    public void PlayClipByName(string clipName)
    {
        Sound s = System.Array.Find(sounds, sound => sound.clipName == clipName);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + clipName + " not found!");
            return;
        }
        s.audioSource.Play();
    }

    public void StopClipByName(string clipName)
    {
        Sound s = System.Array.Find(sounds, sound => sound.clipName == clipName);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + clipName + " not found!");
            return;
        }
        s.audioSource.Stop();
    }
}

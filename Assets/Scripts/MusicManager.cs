using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance; // Singleton instance

    [System.Serializable]
    public struct SceneMusic
    {
        public string sceneName; // Name of the scene
        public AudioClip song; // Song to play in the scene
    }

    public List<SceneMusic> sceneMusics; // List of scene-specific music
    public AudioSource audioSource; // Reference to the AudioSource component

    private string currentSceneName; // Name of the currently loaded scene

    void Awake()
    {
        // Singleton pattern to ensure only one instance of MusicManager exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Don't destroy this object when loading new scenes
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
        }

        // Initialize AudioSource component
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = false; // Ensure looping is off initially
    }

    void Start()
    {
        // Subscribe to scene loaded event
        SceneManager.sceneLoaded += OnSceneLoaded;
        // Get the initial scene
        Scene initialScene = SceneManager.GetActiveScene();
        currentSceneName = initialScene.name;
        // Play music for the initial scene
        PlaySceneMusic(currentSceneName);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Update the current scene name
        currentSceneName = scene.name;
        // Play music for the new scene
        PlaySceneMusic(currentSceneName);
    }

    // Method to play music for the current scene
    void PlaySceneMusic(string sceneName)
    {
        // Find the corresponding music for the scene
        foreach (SceneMusic sceneMusic in sceneMusics)
        {
            if (sceneMusic.sceneName == sceneName)
            {
                // Set and play the music
                audioSource.clip = sceneMusic.song;
                audioSource.Play();
                return;
            }
        }
        // If no music is found for the scene, stop playing
        audioSource.Stop();
    }
}

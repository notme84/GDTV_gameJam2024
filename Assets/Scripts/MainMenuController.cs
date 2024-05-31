using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        // get the audio source component


    }
    public void StartGame()
    {
        //play the click sound
        //GetComponent<AudioSource>().Play();
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }

    public void OpenSettings()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("OptionsMenuScene");
    }

    public void QuitGame()
    {
#if (UNITY_EDITOR || DEVELOPMENT_BUILD)
        Debug.Log(this.name + " : " + this.GetType() + " : " + System.Reflection.MethodBase.GetCurrentMethod().Name);
#endif
#if (UNITY_EDITOR)
        UnityEditor.EditorApplication.isPlaying = false;
#elif (UNITY_STANDALONE) 
    Application.Quit();
#elif (UNITY_WEBGL)
    Application.OpenURL("about:blank");
#endif
    }

    public void MusicButton()
    {
        
    }

    public void MainMenuButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }

    void PlayClickSound()
    {
        // Play the assigned click sound
        audioSource.Play();
    }

}

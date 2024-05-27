using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    //serialize field to expose in the inspector
    [SerializeField] private GameObject pausePanelGO;
    [SerializeField] private Image pauseButtonImage;
    [SerializeField] private Sprite pauseSprite;
    [SerializeField] private Sprite playSprite;

    private bool isGamePaused = false;
    private bool canPause = true;
    private float timeBeforePause;

    // function to toggle the pause state
    public void TogglePause()
    {
        if (!canPause)
            return;

        isGamePaused = !isGamePaused;

        if (isGamePaused)
        {
            pausePanelGO.SetActive(true);
            pauseButtonImage.sprite = playSprite;
            timeBeforePause = Time.timeScale;
            Time.timeScale = 0;
        }
        else
        {
            pausePanelGO.SetActive(false);
            pauseButtonImage.sprite = pauseSprite;
            Time.timeScale = timeBeforePause;
        }
    }

    // function to set the pause state
    //public void changePauseState(bool pauseState)
    //{   
    //    canPause = pauseState;
    //}
}

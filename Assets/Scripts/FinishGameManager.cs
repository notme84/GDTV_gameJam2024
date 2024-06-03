using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinishGameManager : MonoBehaviour
{
    //singleton pattern
    public static FinishGameManager Instance;
    [SerializeField] TextMeshProUGUI scoreText;
    int playerScore = 0;


    [SerializeField] private GameObject gameOverPanel;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Debug.LogWarning("There are multiple FinishGameManagers in the scene. Destroying the newest one.");
            Destroy(gameObject);
        }
    }

    void Start()
    {
        scoreText.text = playerScore.ToString();
    }

    public void FinishGame()
    {
        //Load game over scene
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOverScene");
        //Time.timeScale = 0;
        //gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        playerScore = 0;
        scoreText.text = playerScore.ToString();
        gameOverPanel.SetActive(false);
        // Load the active scene in the build settings
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }

    public void ScorePoints()
    {
        playerScore += 100;
        scoreText.text = playerScore.ToString();
    }
}

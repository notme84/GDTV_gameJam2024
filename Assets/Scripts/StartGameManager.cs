using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class StartGameManager : MonoBehaviour
{
    [SerializeField] private ShuffleBackgroundSprites[] movingBackgrounds;

    private void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        SpawnManager.Instance.StartSpawning();
        DistanceManager.Instance.StartScript();
        enabled = false;

        foreach (ShuffleBackgroundSprites m in movingBackgrounds)
        {
            m.StartScript();
        }
    }
}
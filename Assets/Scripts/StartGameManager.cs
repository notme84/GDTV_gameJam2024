using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class StartGameManager : MonoBehaviour
{
    private void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        SpawnManager.Instance.StartSpawning();
        DistanceManager.Instance.StartScript();
        enabled = false;
    }
}
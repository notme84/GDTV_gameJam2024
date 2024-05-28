using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockEnemiesManager : MonoBehaviour
{
    [SerializeField] private int yardsToBeAtToIncreaseDifficulty;
    private int previousYardsMet;

    private void Update()
    {
        int currentYards = (int)DistanceManager.Instance.distanceTravelled;
        if (currentYards % yardsToBeAtToIncreaseDifficulty == 0 && currentYards != previousYardsMet)
        {
            previousYardsMet = currentYards;
            GetEnemyManager.Instance.AddEnemy();
        }
    }
}

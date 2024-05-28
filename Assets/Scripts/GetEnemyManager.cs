using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetEnemyManager : MonoBehaviour
{
    //singleton pattern
    public static GetEnemyManager Instance;


    [SerializeField] private int howManyEnemiesUnlocked;
    [SerializeField] private int howManyEnemiesUnlockedMax;
    [SerializeField] private int howManyByDefault = 2;
    [SerializeField] private GameObject[] entitiesPrefabs;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Debug.LogWarning("There are multiple GetMobManagers in the scene. Destroying the newest one.");
            Destroy(gameObject);
        }

        howManyEnemiesUnlockedMax = entitiesPrefabs.Length - howManyByDefault;

    }


    public GameObject GetEnemy()
    {
        return entitiesPrefabs[Random.Range(0, howManyByDefault + howManyEnemiesUnlocked)];
    }

    public void AddEnemy()
    {
        if (howManyEnemiesUnlocked < howManyEnemiesUnlockedMax)
        {
            howManyEnemiesUnlocked++;
        }
    }
}

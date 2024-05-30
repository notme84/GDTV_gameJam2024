using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseSpawnManager : MonoBehaviour
{
    public static HouseSpawnManager Instance;

    // get a list of houses prefabs
    [SerializeField] private GameObject[] housesPrefabs;
    [SerializeField] private Vector3 spawnPosition;

    [Header("Scaling Values")]
    [SerializeField] private float scalingMultiplier = 1.0001f;
    [SerializeField] private float entitiesSpeed = 2f;
    [SerializeField] private float scaledEntitiesSpeed = 18f;
    private bool maxVelocityReached;

    private void Awake()
    {
        // Singleton pattern
        if (Instance == null)
            Instance = this;
        else
        {
            Debug.LogWarning("There are multiple HouseSpawnManager in the scene. Destroying the newest one.");
            Destroy(gameObject);
        }

    }

    private void Update()
    {
        //if (!canSpawn) { return; }
        IncreaseSpeed();
    }

    // instantiate a house prefab from the list
    public void SpawnHouse()
    {
        Instantiate(GetHouse(), spawnPosition, Quaternion.identity);
    }

    // get a random house prefab
    public GameObject GetHouse()
    {
        return housesPrefabs[Random.Range(0, housesPrefabs.Length)];
    }

    private void IncreaseSpeed()
    {
        if (maxVelocityReached || Time.frameCount % 5 != 0 || Time.timeScale == 0)
            return;

        if (entitiesSpeed < scaledEntitiesSpeed)
            entitiesSpeed *= scalingMultiplier;
        else
            entitiesSpeed = scaledEntitiesSpeed;

        GameObject[] entitiesInGame = GameObject.FindGameObjectsWithTag("Home");
        foreach (GameObject e in entitiesInGame)
        {
            if (e.TryGetComponent(out Rigidbody2D entityRB))
                entityRB.velocity = new Vector2(entityRB.velocity.x, -entitiesSpeed);
        }
    }

}

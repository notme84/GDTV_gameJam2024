using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHouseManager : MonoBehaviour
{
    public static GetHouseManager Instance;

    private void Awake()
    {
        // Singleton pattern
        if (Instance == null)
            Instance = this;
        else
        {
            Debug.LogWarning("There are multiple GetHouseManager in the scene. Destroying the newest one.");
            Destroy(gameObject);
        }
    }

    public GameObject GetHouse()
    {
        // Add your logic to get the house prefab here
        return null;
    }
}

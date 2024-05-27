using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private const float PLAYER_DISTANCE_SPAWN = 15f;
    private const float PLAYER_DISTANCE_DESPAWN = 15f;
    [SerializeField] private Transform block;
    [SerializeField] private Player player;
    List<Transform> neighborhood;

    private Vector3 lastEndPosition = new Vector3(0, 0, 0);
    
    void Awake()
    {
        SpawnBlock(new Vector3(0, 0));
        SpawnBlock();
    }

    private void Update()
    {
        if (Vector3.Distance(player.transform.position, lastEndPosition) 
                < PLAYER_DISTANCE_SPAWN)
        {
            SpawnBlock();

            //TODO: destroy far old houses
            /*foreach (Transform neighbor in neighborhood)
            {
                if (Vector3.Distance(player.transform.position, neighbor.transform.position) 
                        < PLAYER_DISTANCE_DESPAWN)
                {
                    neighborhood.Remove(neighbor);
                    Destroy(neighbor);
                }
            }*/
        }
    }

    private void SpawnBlock()
    {
        Transform lastLevelTransform = SpawnBlock(lastEndPosition);
        lastEndPosition = lastLevelTransform.Find("EndPosition").position;
    }

    private Transform SpawnBlock(Vector3 spawnPoint)
    {
        lastEndPosition = block.Find("EndPosition").position;
        //neighborhood.Add(block);
        return Instantiate(block, spawnPoint, Quaternion.identity);
    }
}

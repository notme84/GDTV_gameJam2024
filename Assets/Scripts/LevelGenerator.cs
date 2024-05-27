using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private const float PLAYER_DISTANCE_SPAWN_LEVEL_BLOCK = 15f;
    [SerializeField] private Transform block;
    [SerializeField] private Player player;

    private Vector3 lastEndPosition;
    
    void Awake()
    {
        SpawnBlock(new Vector3(0, 0));
        SpawnBlock();
    }

    private void Update()
    {
        if (Vector3.Distance(player.transform.position, lastEndPosition) 
                < PLAYER_DISTANCE_SPAWN_LEVEL_BLOCK)
        {
            SpawnBlock();
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
        return Instantiate(block, spawnPoint, Quaternion.identity);
    }
}

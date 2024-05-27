using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> waveConfigs;
    [SerializeField] float timeBetweenWaves = 0f;
    [SerializeField] bool isLooping = false;
    [SerializeField] Transform block;
    WaveConfigSO currentWave;

    void Start()
    {
        //StartCoroutine(SpawnEnemyWaves());
    }

    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }

    
    public IEnumerator SpawnEnemyWave(WaveConfigSO wave, UnityEngine.Vector3 position)
    {
        for(int i = 0; i < wave.GetEnemyCount(); i++)
        {
            Instantiate(wave.GetEnemyPrefab(i), 
                        position,
                        UnityEngine.Quaternion.identity,
                        transform);
            yield return new WaitForSeconds(wave.GetRandomSpawnTime());
        }
    }
    
    //TODO: Fix enemy position Y spawn issue
    public IEnumerator SpawnEnemyWaves(UnityEngine.Vector3 position)
    {
        do
        {
            foreach (WaveConfigSO wave in waveConfigs)
            {
                currentWave = wave;
                for(int i = 0; i < currentWave.GetEnemyCount(); i++)
                {
                    Instantiate(currentWave.GetEnemyPrefab(i), 
                                position,
                                UnityEngine.Quaternion.identity,
                                transform);
                    Debug.Log("Block Y position: " + position);
                    yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
                }
                yield return new WaitForSeconds(timeBetweenWaves);
            }
        }
        while(isLooping);
    }
}

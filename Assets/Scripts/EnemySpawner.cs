using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> waveConfigs;
    [SerializeField] float timeBetweenWaves = 0f;
    [SerializeField] bool isLooping = false;
    [SerializeField] Player player;
    WaveConfigSO currentWave;
    

    void Start()
    {
        StartCoroutine(SpawnEnemyWaves());
    }

    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }

    IEnumerator SpawnEnemyWave(WaveConfigSO wave)
    {
        Vector3 playerWavePosition = new Vector3(wave.GetStartingWaypoint().position.x, 
                player.transform.position.y + wave.GetStartingWaypoint().position.y);
        for(int i = 0; i < wave.GetEnemyCount(); i++)
        {
            Instantiate(wave.GetEnemyPrefab(i), 
                        playerWavePosition,
                        Quaternion.identity,
                        transform);
            yield return new WaitForSeconds(wave.GetRandomSpawnTime());
        }
    }

    IEnumerator SpawnEnemyWaves()
    {
        do
        {
            foreach (WaveConfigSO wave in waveConfigs)
            {
                currentWave = wave;
                for(int i = 0; i < currentWave.GetEnemyCount(); i++)
                {
                    Instantiate(currentWave.GetEnemyPrefab(i), 
                                currentWave.GetStartingWaypoint().position,
                                Quaternion.identity,
                                transform);
                    yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
                }
                yield return new WaitForSeconds(timeBetweenWaves);
            }
        }
        while(isLooping);
    }
}

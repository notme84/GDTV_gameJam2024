using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance;

    [Header("Spawn Values")]
    [SerializeField] private bool canSpawn;
    [SerializeField] private Vector3 spawnPosition;
    [SerializeField] private float spawnTimer;
    [SerializeField] private float xMargin = 8;
    [SerializeField] private float xPosToTheRight = 4;


    [Header("Scaling Values")]
    [SerializeField] private float scalingMultiplier = 1.0001f;
    [SerializeField] private float spawnTimerMax = 3f;
    [SerializeField] private float scaledSpawnTimerMax = 0.8f;
    [SerializeField] private float entitiesSpeed = 1.4f;
    [SerializeField] private float scaledEntitiesSpeed = 18f;
    private bool maxVelocityReached;

    private void Awake()
    {
        // Singleton pattern
        if (Instance == null)
            Instance = this;
        else
        {
            Debug.LogWarning("There are multiple SpawnManagers in the scene. Destroying the newest one.");
            Destroy(gameObject);
        }

        scaledEntitiesSpeed = spawnTimerMax / scaledSpawnTimerMax * entitiesSpeed;
    }

    private void Update()
    {
        if (!canSpawn) { return; }
        IncreaseSpeed();
        TrySpawn();
    }

    private void TrySpawn()
    {
        if (spawnTimer > 0)
        {
            spawnTimer -= Time.deltaTime;
        }
        else
        {
            spawnTimer = spawnTimerMax;
            SpawnEntity();
        }
    }

    public void StartSpawning()
    {   
        canSpawn = true;
        spawnTimer = spawnTimerMax;
    }

    private void SpawnEntity()
    {
        GameObject entityToSpawn = GetEnemyManager.Instance.GetEnemy();

        spawnPosition.x = Random.Range(-xMargin, xMargin) + xPosToTheRight;

        GameObject spawnedEntity = Instantiate(entityToSpawn, spawnPosition, Quaternion.identity);
        spawnedEntity.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -entitiesSpeed);
    }

    private void IncreaseSpeed()
    {
        if (maxVelocityReached || Time.frameCount % 5 != 0 || Time.timeScale == 0)
            return;

        if (spawnTimerMax > scaledSpawnTimerMax)
            spawnTimerMax /= scalingMultiplier;
        else
            spawnTimerMax = scaledSpawnTimerMax;

        if (entitiesSpeed < scaledEntitiesSpeed)
            entitiesSpeed *= scalingMultiplier;
        else
            entitiesSpeed = scaledEntitiesSpeed;

        if (spawnTimerMax == scaledSpawnTimerMax
            && entitiesSpeed == scaledEntitiesSpeed)
            maxVelocityReached = true;

        GameObject[] entitiesInGame = GameObject.FindGameObjectsWithTag("Entity");
        foreach (GameObject e in entitiesInGame)
        {
            if (e.TryGetComponent(out Rigidbody2D entityRB))
                entityRB.velocity = new Vector2(entityRB.velocity.x, -entitiesSpeed);
        }
    }
}
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [Header("AccelerationEvent")]
    public GameObject[] obstacles;
    public float SpawnTime = 1f;
    public float SpawnRange = 10f;
    public float SpawnDistance = 50f;

    public Transform player;

    private float obstacleTimer;

    void Update()
    {
        if (player == null) return;

        obstacleTimer += Time.deltaTime;
        if (obstacleTimer >= SpawnTime)
        {
            SpawnObstacles();
            obstacleTimer = 0f;
        }
    }

    void SpawnObstacles()
    {
        if (obstacles.Length == 0) return;
        
        int randomIndex = Random.Range(0, obstacles.Length);
        float randomRangeX = Random.Range(-SpawnRange, SpawnRange);
        float randomRangeY = Random.Range(-SpawnRange, SpawnRange);

        Vector3 spawnPos = new Vector3(
           player.position.x + randomRangeX,
           player.position.y + randomRangeY,
           player.position.z + SpawnDistance);

        Instantiate(obstacles[randomIndex], spawnPos, Quaternion.identity);
    }
}
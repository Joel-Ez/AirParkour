using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [Header("AccelerationEvent")]
    public GameObject[] obstacles;
    public float SpawnTime = 1f;
    public float SpawnDistance = 50f;

    public Transform player;

    private Camera mainCamera;
    private float obstacleTimer;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (player == null || mainCamera == null) return;

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
        float randomViewportX = (Random.Range(0.1f, 0.9f) + Random.Range(0.1f, 0.9f)) / 2f;
        float randomViewportY = (Random.Range(0.1f, 0.9f) + Random.Range(0.1f, 0.9f)) / 2f;

        Vector3 viewportPoint = new Vector3(randomViewportX, randomViewportY, SpawnDistance);
        Vector3 spawnPos = mainCamera.ViewportToWorldPoint(viewportPoint);

        GameObject newObstacle = Instantiate(obstacles[randomIndex], spawnPos, Quaternion.identity);

        if (!newObstacle.GetComponent<DestroyOnExit>())
        {
            newObstacle.AddComponent<DestroyOnExit>();
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class ObstacleData
{
    public GameObject obstaclePrefab; // The prefab for the obstacle
}

public class JumpOverObstacleSpawnerManager : MonoBehaviour
{
    public ObstacleData[] obstacles; // Array to hold obstacle data (prefab)
    public float obstacleSpeed = 4f; // Initial speed of the obstacles
    public float spawnInterval = 3.5f; // Time interval between obstacle spawns
    public Transform destroyPoint; // The point at which obstacles will be destroyed
    public float speedIncrementValue = 0.5f; // Speed increment value
    public float speedIncrementInterval = 5f; // Interval for increasing speed

    // New boolean to control obstacle spawning
    public bool isSpawningEnabled = true;

    private Coroutine spawnRoutine;
    private Coroutine speedIncreaseRoutine;
    private List<ObstacleData> availableObstacles; // List to store available obstacles

    private void Start()
    {
        // Initialize the available obstacles list
        availableObstacles = new List<ObstacleData>(obstacles);

        // Start spawning only if enabled
        if (isSpawningEnabled)
        {
            StartSpawning();
        }

        StartIncreasingSpeed();
    }

    public void StartSpawning()
    {
        // Validate if obstacles array contains any data
        if (obstacles == null || obstacles.Length == 0)
        {
            Debug.LogError("Obstacle array is empty! Please assign obstacle data.");
            return;
        }

        spawnRoutine = StartCoroutine(SpawnObstacles());
    }

    public void StopSpawning()
    {
        if (spawnRoutine != null)
        {
            StopCoroutine(spawnRoutine);
        }

        if (speedIncreaseRoutine != null)
        {
            StopCoroutine(speedIncreaseRoutine);
        }
    }

    private IEnumerator SpawnObstacles()
    {
        while (true)
        {
            // Check if spawning is enabled
            if (isSpawningEnabled)
            {
                SpawnObstacle();
            }
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnObstacle()
    {
        // If there are no available obstacles, refill the list
        if (availableObstacles.Count == 0)
        {
            availableObstacles = new List<ObstacleData>(obstacles);
        }

        // Choose a random obstacle from the available list
        int randomIndex = Random.Range(0, availableObstacles.Count);
        ObstacleData chosenObstacle = availableObstacles[randomIndex];

        // Spawn the chosen obstacle at the spawner's position
        GameObject spawnedObstacle = Instantiate(chosenObstacle.obstaclePrefab, transform.position, Quaternion.identity);

        // Add speed to the spawned obstacle
        Rigidbody2D obstacleRigidbody = spawnedObstacle.GetComponent<Rigidbody2D>();
        if (obstacleRigidbody != null)
        {
            // Set the speed of the spawned obstacle
            obstacleRigidbody.velocity = Vector2.left * obstacleSpeed;
        }

        // Add the destroyer component with the destroy point reference
        spawnedObstacle.AddComponent<JumOverObstacleDestroyer>().destroyPoint = destroyPoint;

        // Remove the chosen obstacle from the available list to prevent duplicates
        availableObstacles.RemoveAt(randomIndex);
    }

    private void StartIncreasingSpeed()
    {
        // Start coroutine to increase obstacle speed over time
        speedIncreaseRoutine = StartCoroutine(IncreaseSpeedOverTime());
    }

    private IEnumerator IncreaseSpeedOverTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(speedIncrementInterval);
            obstacleSpeed += speedIncrementValue;
            Debug.Log("Obstacle speed increased to: " + obstacleSpeed);
        }
    }

    // Method to enable spawning
    public void EnableSpawning()
    {
        isSpawningEnabled = true;
        if (spawnRoutine == null) // Only start if not already spawning
        {
            StartSpawning();
        }
    }

    // Method to disable spawning
    public void DisableSpawning()
    {
        isSpawningEnabled = false;
    }
}

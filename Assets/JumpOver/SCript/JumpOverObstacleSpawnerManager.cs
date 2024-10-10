using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpOverObstacleSpawnerManager : MonoBehaviour
{
    public GameObject[] obstacles; // Array untuk menampung beberapa prefab rintangan
    public float obstacleSpeed = 3f; // Kecepatan awal rintangan
    public float spawnInterval = 5f; // Interval waktu antara spawn rintangan
    public Transform destroyPoint; // Titik penghancur untuk obstacle
    public float speedIncrementValue = 0.5f; // Nilai penambahan kecepatan
    public float speedIncrementInterval = 10f; // Interval waktu untuk meningkatkan kecepatan

    private Coroutine spawnRoutine;
    private Coroutine speedIncreaseRoutine;

    private void Start()
    {
        StartSpawning();
        StartIncreasingSpeed();
    }

    public void StartSpawning()
    {
        // Validasi apakah obstacles array berisi prefab atau tidak
        if (obstacles == null || obstacles.Length == 0)
        {
            Debug.LogError("Obstacle array is empty! Please assign obstacle prefabs.");
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
            SpawnObstacle();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnObstacle()
    {
        // Pilih obstacle secara acak dari array
        GameObject obstacleToSpawn = obstacles[Random.Range(0, obstacles.Length)];
        // Spawn obstacle di posisi spawner
        GameObject spawnedObstacle = Instantiate(obstacleToSpawn, transform.position, Quaternion.identity);
        // Tambahkan kecepatan ke obstacle
        Rigidbody2D obstacleRigidbody = spawnedObstacle.GetComponent<Rigidbody2D>();
        if (obstacleRigidbody != null)
        {
            // Set kecepatan obstacle yang baru di-spawn berdasarkan kecepatan tetap
            obstacleRigidbody.velocity = Vector2.left * obstacleSpeed;
        }

        // Set parent atau referensi untuk memeriksa posisi obstacle
        spawnedObstacle.AddComponent<JumOverObstacleDestroyer>().destroyPoint = destroyPoint;
    }

    private void StartIncreasingSpeed()
    {
        // Mulai coroutine untuk meningkatkan kecepatan obstacle seiring waktu
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
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public GameObject targetPrefab; // Prefab objek yang akan diserang
    public Transform[] spawnPoints; // Tempat di mana objek akan muncul
    public float minSpawnInterval = 2f; // Interval spawn minimum
    public float maxSpawnInterval = 4f; // Interval spawn maksimum
    private float spawnInterval; // Waktu interval antar spawn
    private float timer;

    void Start()
    {
        SetRandomSpawnInterval(); // Set interval spawn acak saat permainan dimulai
        timer = spawnInterval;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            SpawnTarget();
            SetRandomSpawnInterval(); // Set interval spawn acak untuk spawn berikutnya
            timer = spawnInterval; // Reset timer dengan interval baru
        }
    }

    void SpawnTarget()
    {
        // Pilih jalur secara acak
        int randomLaneIndex = Random.Range(0, spawnPoints.Length);
        GameObject spawnedTarget = Instantiate(targetPrefab, spawnPoints[randomLaneIndex].position, Quaternion.identity);

        Debug.Log("Musuh di-spawn di lane " + (randomLaneIndex + 1)); // Log untuk memeriksa lane

        // Set jalur tetap untuk musuh di `EnemyController`
        EnemyController enemyController = spawnedTarget.GetComponent<EnemyController>();
        if (enemyController != null)
        {
            enemyController.SetLane(spawnPoints[randomLaneIndex].position);
        }
    }

    void SetRandomSpawnInterval()
    {
        spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
        Debug.Log("Interval spawn baru: " + spawnInterval + " detik");
    }
}

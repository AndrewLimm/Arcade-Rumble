using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public GameObject targetPrefab; // Prefab objek yang akan diserang
    public Transform[] spawnPoints; // Tempat di mana objek akan muncul
    public float spawnInterval = 2f; // Waktu interval antar spawn
    private float timer;

    void Start()
    {
        timer = spawnInterval;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            SpawnTarget();
            timer = spawnInterval; // Reset timer
        }
    }

    void SpawnTarget()
    {
        // Pilih jalur secara acak
        int randomLaneIndex = Random.Range(0, spawnPoints.Length);
        GameObject spawnedTarget = Instantiate(targetPrefab, spawnPoints[randomLaneIndex].position, Quaternion.identity);

        // Set jalur tetap untuk musuh di `EnemyController`
        EnemyController enemyController = spawnedTarget.GetComponent<EnemyController>();
        if (enemyController != null)
        {
            // Tetapkan lane position sebagai tujuan musuh
            enemyController.SetLane(spawnPoints[randomLaneIndex].position);
        }

    }
}

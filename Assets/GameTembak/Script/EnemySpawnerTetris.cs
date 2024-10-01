using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerTetris : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints; // Tempat spawn musuh

    public float spawnInterval = 2f; // Interval waktu spawn

    void Start()
    {
        // Memulai spawn musuh dengan interval waktu tertentu
        InvokeRepeating("SpawnEnemy", 1f, spawnInterval);
    }

    void SpawnEnemy()
    {
        // Memilih titik spawn secara acak
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex];

        // Spawning musuh di titik spawn yang dipilih
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}

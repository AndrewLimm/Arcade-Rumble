using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoinSpawnerCoin : MonoBehaviour
{
    public GameObject coinPrefab; // Prefab dari koin
    public List<Transform> spawnPoints; // List posisi tempat koin akan muncul secara acak
    public float minSpawnTime = 2f; // Waktu spawn minimum
    public float maxSpawnTime = 4f; // Waktu spawn maksimum

    void Start()
    {
        // Spawn koin pertama kali saat permainan dimulai
        SpawnCoin();
        // Mulai spawn koin dengan waktu acak
        StartSpawningCoins();
    }

    // Mulai spawn koin dengan waktu acak
    void StartSpawningCoins()
    {
        Invoke("SpawnCoin", Random.Range(minSpawnTime, maxSpawnTime));
    }

    void SpawnCoin()
    {
        // Pilih titik spawn secara acak dari list spawnPoints
        int spawnIndex = Random.Range(0, spawnPoints.Count);

        // Spawn koin di posisi yang dipilih
        Instantiate(coinPrefab, spawnPoints[spawnIndex].position, Quaternion.identity);

        // Set waktu spawn berikutnya
        StartSpawningCoins();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollecCoinPotionSpawner : MonoBehaviour
{
    public GameObject potionPrefab; // Prefab dari potion yang akan di-spawn
    public Transform[] spawnPoints;  // Array dari posisi spawn yang tersedia
    public float spawnInterval = 15f; // Interval waktu antara spawn potion

    private void Start()
    {
        // Spawn potion saat permainan dimulai
        SpawnPotion();

        // Mulai coroutine untuk spawn potion secara berkala
        InvokeRepeating(nameof(SpawnPotion), spawnInterval, spawnInterval);
    }

    void SpawnPotion()
    {
        // Pilih posisi spawn secara acak dari spawnPoints
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex];

        // Spawn potion di posisi yang dipilih
        Instantiate(potionPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}

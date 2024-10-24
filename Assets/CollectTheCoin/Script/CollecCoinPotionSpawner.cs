using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollecCoinPotionSpawner : MonoBehaviour
{
    public GameObject potionPrefab; // Prefab dari potion yang akan di-spawn
    public Transform[] spawnPoints;  // Array dari posisi spawn yang tersedia
    public float spawnInterval = 15f; // Interval waktu antara spawn potion

    // Variabel kontrol untuk mengetahui apakah spawn sudah aktif
    private bool isSpawning = false;

    private void Start()
    {
        // Jangan spawn apapun sampai fungsi StartSpawning dipanggil oleh GameManager
    }

    // Fungsi untuk memulai spawn setelah tombol start ditekan
    public void StartSpawning()
    {
        if (!isSpawning)
        {
            isSpawning = true; // Set flag bahwa spawning sudah dimulai

            // Spawn potion saat permainan dimulai
            SpawnPotion();

            // Mulai coroutine untuk spawn potion secara berkala
            InvokeRepeating(nameof(SpawnPotion), spawnInterval, spawnInterval);
        }
    }

    void SpawnPotion()
    {
        if (spawnPoints.Length == 0) return; // Cek jika tidak ada spawn points

        // Pilih posisi spawn secara acak dari spawnPoints
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex];

        // Spawn potion di posisi yang dipilih
        Instantiate(potionPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerTetris : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints; // Tempat spawn musuh

    public float spawnInterval = 2f; // Interval waktu spawn
    private bool isSpawning = false; // Variabel untuk mengontrol status spawn


    void Start()
    {
        // Spawn musuh tidak langsung dimulai saat Start, harus diaktifkan secara manual
        isSpawning = false;
    }

    void Update()
    {
        // Menjalankan SpawnEnemy hanya jika isSpawning bernilai true
        if (isSpawning)
        {
            // Cek apakah musuh harus spawn dengan interval waktu tertentu
            CancelInvoke("SpawnEnemy");
            InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
            isSpawning = false; // Memastikan SpawnEnemy tidak dipanggil berulang kali
        }
    }

    void SpawnEnemy()
    {
        // Memilih titik spawn secara acak
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex];

        // Spawning musuh di titik spawn yang dipilih
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    // Fungsi untuk memulai spawning musuh
    public void StartSpawning()
    {
        isSpawning = true; // Mengaktifkan proses spawning
    }

    // Fungsi untuk menghentikan spawning musuh
    public void StopSpawning()
    {
        CancelInvoke("SpawnEnemy");
    }
}

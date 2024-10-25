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

    public bool canSpawn = false;

    [SerializeField] KarateAnimalTimerGamer gameTimer;

    void Start()
    {
        SetRandomSpawnInterval(); // Set interval spawn acak saat permainan dimulai
        timer = spawnInterval;
    }

    void Update()
    {
        // Check if spawning is allowed and if there are more than 5 seconds remaining
        if (canSpawn && gameTimer.GetRemainingTime() > 5f)
        {
            timer -= Time.deltaTime;

            if (timer <= 0f)
            {
                SpawnTarget();
                SetRandomSpawnInterval(); // Set a new random spawn interval for the next spawn
                timer = spawnInterval; // Reset timer with the new interval
            }
        }
        else if (gameTimer.GetRemainingTime() <= 5f)
        {
            // Stop spawning when there are 5 seconds or less remaining
            canSpawn = false;
            Debug.Log("Spawner berhenti karena waktu tersisa 5 detik atau kurang.");
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

    public void enableSpawn()
    {
        canSpawn = true;
    }
    public void disableSpawn()
    {
        canSpawn = false;
    }
}

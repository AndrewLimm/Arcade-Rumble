using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayAliveBotItemSpawner : MonoBehaviour
{
    public GameObject itemPrefab; // The item to be spawned by the bot
    public Transform[] spawnPoints; // Array of possible spawn points
    public float minSpawnInterval = 2f; // Minimum interval for spawning items
    public float maxSpawnInterval = 4f; // Maximum interval for spawning items

    private float spawnInterval; // Time interval for item spawning
    private float nextSpawnTime; // Next spawn time

    void Start()
    {
        // Set the initial spawn interval to a random value between minSpawnInterval and maxSpawnInterval
        spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
        nextSpawnTime = Time.time + spawnInterval;
    }

    void Update()
    {
        SpawnItem();
    }

    void SpawnItem()
    {
        // Check if it's time to spawn an item
        if (Time.time >= nextSpawnTime)
        {
            // Choose a random spawn point from the array
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Instantiate(itemPrefab, spawnPoints[spawnIndex].position, Quaternion.identity);

            // Set the next spawn time to a random value between minSpawnInterval and maxSpawnInterval
            spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
            nextSpawnTime = Time.time + spawnInterval;
        }
    }
}

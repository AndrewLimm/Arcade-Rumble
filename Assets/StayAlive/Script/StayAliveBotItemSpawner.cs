using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayAliveBotItemSpawner : MonoBehaviour
{
    public GameObject itemPrefab; // The item to be spawned by the bot
    public Transform[] spawnPoints; // Array of possible spawn points
    public float minSpawnInterval = 2f; // Minimum interval for spawning items
    public float maxSpawnInterval = 4f; // Maximum interval for spawning items

    private bool isSpawning = false; // Flag to control the spawning process

    // Audio
    [SerializeField] private AudioClip shootSound; // Audio clip for the shooting sound
    private AudioSource audioSource;
    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>(); // Tambahkan AudioSource jika belum ada
    }

    public void StartSpawning()
    {
        isSpawning = true; // Enable item spawning
        // Start the spawning coroutine for each bot
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            StartCoroutine(SpawnItemCoroutine(i));
        }
    }

    public void StopSpawning()
    {
        isSpawning = false; // Disable item spawning
        // Optionally, you could stop all coroutines if you want to halt the spawning immediately
        StopAllCoroutines();
    }

    private IEnumerator SpawnItemCoroutine(int botIndex)
    {
        // Define spawn interval for each bot
        float spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
        float nextSpawnTime = Time.time + spawnInterval;

        while (isSpawning) // Keep spawning items while isSpawning is true
        {
            // Check if it's time to spawn an item
            if (Time.time >= nextSpawnTime)
            {
                // Spawn item at the specific spawn point for this bot
                Instantiate(itemPrefab, spawnPoints[botIndex].position, Quaternion.identity);

                // Play shooting sound
                PlayShootSound();

                // Set the next spawn time to a random value
                spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
                nextSpawnTime = Time.time + spawnInterval;
            }
            yield return null; // Wait for the next frame
        }
    }
    private void PlayShootSound()
    {
        if (audioSource != null && shootSound != null)
        {
            audioSource.PlayOneShot(shootSound); // Play the shooting sound effect
        }
    }
}

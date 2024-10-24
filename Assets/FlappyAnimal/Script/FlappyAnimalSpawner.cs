using UnityEngine;

public class FlappyAnimalSpawner : MonoBehaviour
{
    public FlappyAnimalPipes prefab;
    public float spawnRate = 1f;
    public float minHeight = -1f;
    public float maxHeight = 0.5f;
    public float verticalGap = 1.5f;
    private bool canSpawn = false; // Add the condition for spawning


    private void OnEnable()
    {
        // Check if spawning is allowed
        if (canSpawn)
        {
            InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
        }
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        FlappyAnimalPipes pipes = Instantiate(prefab, transform.position, Quaternion.identity);
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
        pipes.gap = verticalGap;

        pipes.canMove = true;
    }
    // Method to enable spawning
    public void EnableSpawning()
    {
        canSpawn = true;
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    // Method to disable spawning
    public void DisableSpawning()
    {
        canSpawn = false;
        CancelInvoke(nameof(Spawn));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollect : MonoBehaviour
{
    public int playerNumber; // Assign 1 for Player 1, 2 for Player 2 in the Inspector
    public KeyCode collectKey; // Set the collect key for the player in the Inspector (e.g. A for Player 1, L for Player 2)
    public int playerScore = 0;
    public float range = 100f;

    private SpawnerManager spawnManager;

    private void Start()
    {
        spawnManager = FindObjectOfType<SpawnerManager>(); // Find the SpawnManager script in the scene
    }

    private void Update()
    {
        if (spawnManager.spawnedObject != null && Input.GetKeyDown(collectKey))
        {
            // Check if the player is close enough to collect the object
            float distance = Vector3.Distance(transform.position, spawnManager.spawnedObject.transform.position);

            if (distance < range) // Adjust the collection range if needed
            {
                CollectObject();
            }
        }
    }

    private void CollectObject()
    {
        playerScore += 1;
        Debug.Log("Player " + playerNumber + " Score: " + playerScore);
        spawnManager.ObjectCollected(); // Trigger the respawn
    }
}

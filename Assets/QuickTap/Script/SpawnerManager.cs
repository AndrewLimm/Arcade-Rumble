using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public Transform _spawnerPosition;
    public GameObject objectPrefab; // Assign the object prefab in the inspector
    public GameObject spawnedObject;

    // Interval for respawning the object
    public float respawnTime = 3f;

    private void Start()
    {
        SpawnObject(); // Initial spawn
    }

    public void SpawnObject()
    {
        if (spawnedObject == null)
        {
            spawnedObject = Instantiate(objectPrefab, _spawnerPosition.position, Quaternion.identity);
            Debug.Log("Object Spawned at: " + Time.time);

        }
    }

    public void ObjectCollected()
    {
        // Destroy the collected object
        Destroy(spawnedObject);
        Debug.Log("Object Destroyed at: " + Time.time);

        // Respawn the object after a delay
        Invoke("SpawnObject", respawnTime);
        Debug.Log("Respawn in " + respawnTime + " seconds...");
    }
}

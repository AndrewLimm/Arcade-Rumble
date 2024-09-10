using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoTest : MonoBehaviour
{
    [SerializeField] SpawnerManager spawnerManager; // Drag the SpawnerManager component in the Inspector

    [ContextMenu("Destroy Object")]
    private void DestroyObject()
    {
        if (spawnerManager != null && spawnerManager.spawnedObject != null)
        {
            spawnerManager.ObjectCollected();
            Debug.Log("Test: Object destroyed and will respawn in " + spawnerManager.respawnTime + " seconds.");
        }
        else
        {
            Debug.LogWarning("No object is currently spawned to destroy.");
        }
    }


}

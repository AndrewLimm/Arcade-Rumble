using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollect : MonoBehaviour
{
    public int playerNumber; // Assign 1 for Player 1, 2 for Player 2 in the Inspector
    public int playerScore = 0; // Score pemain
    public float range = 100f; // Collection range
    private SpawnerManager spawnManager;

    private void Start()
    {
        spawnManager = FindObjectOfType<SpawnerManager>(); // Find the SpawnManager script in the scene
    }

    public GameObject GetFrontFoodInRange()
    {
        if (spawnManager.spawnedObjects.Count > 0)
        {
            GameObject frontFood = spawnManager.spawnedObjects[0];
            float distance = Vector3.Distance(transform.position, frontFood.transform.position);

            if (distance < range)
            {
                return frontFood;
            }
        }

        return null; // Jika tidak ada objek dalam range
    }

    public void CollectEdible(GameObject food)
    {
        if (food == null) return; // Check if the food object is null

        playerScore += 1; // Tambahkan skor
        Debug.Log("Player " + playerNumber + " collected edible food! Score: " + playerScore);
        spawnManager.ShiftFoodItems(); // Shift makanan ke bawah
    }

    public void CollectTrash(GameObject food)
    {
        if (food == null) return; // Check if the food object is null

        playerScore += 1; // Tambahkan skor
        Debug.Log("Player " + playerNumber + " collected trash correctly! Score: " + playerScore);
        spawnManager.ShiftFoodItems(); // Shift makanan ke bawah
    }

    public void WrongCollection(GameObject food)
    {
        if (food == null) return; // Check if the food object is null

        playerScore -= 1; // Kurangi skor
        Debug.Log("Player " + playerNumber + " collected the wrong item! Score: " + playerScore);
        spawnManager.ShiftFoodItems(); // Shift makanan ke bawah
    }
}

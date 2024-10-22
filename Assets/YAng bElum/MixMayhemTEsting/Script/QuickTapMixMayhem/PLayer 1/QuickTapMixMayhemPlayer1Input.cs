using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickTapMixMayhemPlayer1Input : MonoBehaviour
{
    public int playerScore = 0; // Player 1's score
    public float range = 100f; // Collection range
    private SpawnerManager spawnManager;
    private QuickTapMixMayhemPlayer1ScoreUI player1ScoreUI;

    private void Start()
    {
        spawnManager = FindObjectOfType<SpawnerManager>(); // Find the SpawnManager script in the scene
        player1ScoreUI = FindObjectOfType<QuickTapMixMayhemPlayer1ScoreUI>(); // Find the Player1ScoreUI script in the scene
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

        return null; // If no object is within range
    }

    public void CollectEdible(GameObject food)
    {
        if (food == null) return; // Check if the food object is null

        playerScore += 1; // Increase score
        Debug.Log("Player 1 collected edible food! Score: " + playerScore);

        // Update Player 1's score on the UI
        player1ScoreUI.UpdatePlayer1Score(playerScore);

        spawnManager.ShiftFoodItems(); // Shift food items downward
    }

    public void CollectTrash(GameObject food)
    {
        if (food == null) return; // Check if the food object is null

        playerScore += 1; // Increase score
        Debug.Log("Player 1 collected trash correctly! Score: " + playerScore);

        // Update Player 1's score on the UI
        player1ScoreUI.UpdatePlayer1Score(playerScore);

        spawnManager.ShiftFoodItems(); // Shift food items downward
    }

    public void WrongCollection(GameObject food)
    {
        if (food == null) return; // Check if the food object is null

        playerScore -= 1; // Decrease score
        Debug.Log("Player 1 collected the wrong item! Score: " + playerScore);

        // Update Player 1's score on the UI
        player1ScoreUI.UpdatePlayer1Score(playerScore);

        spawnManager.ShiftFoodItems(); // Shift food items downward

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickTapMixMAyhemPlayer2Input : MonoBehaviour
{
    public int playerScore = 0; // Player 1's score
    public float range = 100f; // Collection range
    private QuickTapPlayer2Spawner spawnManagerplayer2;
    private QuickTapMixMayhemPlayer2ScoreUI player2ScoreUI;

    private void Start()
    {
        spawnManagerplayer2 = FindObjectOfType<QuickTapPlayer2Spawner>(); // Find the SpawnManager script in the scene
        player2ScoreUI = FindObjectOfType<QuickTapMixMayhemPlayer2ScoreUI>(); // Find the Player1ScoreUI script in the scene
    }

    public GameObject GetFrontFoodInRange()
    {
        if (spawnManagerplayer2.spawnedObjectsPlayer2.Count > 0)
        {
            GameObject frontFood = spawnManagerplayer2.spawnedObjectsPlayer2[0];
            float distance = Vector3.Distance(transform.position, frontFood.transform.position);
            Debug.Log("Jarak ke objek: " + distance);

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
        Debug.Log("Player 2 collected edible food! Score: " + playerScore);

        // Update Player 1's score on the UI
        player2ScoreUI.UpdatePlayer2Score(playerScore);

        spawnManagerplayer2.ShiftFoodItems(); // Shift food items downward
    }

    public void CollectTrash(GameObject food)
    {
        if (food == null) return; // Check if the food object is null

        playerScore += 1; // Increase score
        Debug.Log("Player 2 collected trash correctly! Score: " + playerScore);

        // Update Player 1's score on the UI
        player2ScoreUI.UpdatePlayer2Score(playerScore);

        spawnManagerplayer2.ShiftFoodItems(); // Shift food items downward
    }

    public void WrongCollection(GameObject food)
    {
        if (food == null) return; // Check if the food object is null

        playerScore -= 1; // Decrease score
        Debug.Log("Player 1 collected the wrong item! Score: " + playerScore);

        // Update Player 1's score on the UI
        player2ScoreUI.UpdatePlayer2Score(playerScore);

        spawnManagerplayer2.ShiftFoodItems(); // Shift food items downward

    }

    private void OnDrawGizmos()
    {
        // Set the color for the Gizmos
        Gizmos.color = Color.green;
        // Draw a wire sphere to represent the collection range
        Gizmos.DrawWireSphere(transform.position, range);
    }
}

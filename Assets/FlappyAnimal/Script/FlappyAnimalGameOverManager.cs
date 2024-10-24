using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FlappyAnimalGameOverManager : MonoBehaviour
{
      private bool player1Alive = true; // Track if Player 1 is alive
    private bool player2Alive = true; // Track if Player 2 is alive

    public TMP_Text winnerText; // Reference to the TMP Text component

    // Reference to FlappyAnimalGameManager to disable game components
    [SerializeField] FlappyAnimalGameManager gameManager;

    // Call this function when Player 1 dies
    public void Player1GameOver()
    {
        player1Alive = false;
        CheckGameOver();
    }

    // Call this function when Player 2 dies
    public void Player2GameOver()
    {
        player2Alive = false;
        CheckGameOver();
    }

    // Check for game over conditions and determine the winner
    private void CheckGameOver()
    {
        // Check if both players are dead
        if (!player1Alive && !player2Alive)
        {
            // If both players are dead, it's a draw
            DisplayWinner("It's a Draw!");
        }
        else if (!player1Alive)
        {
            // If Player 1 is dead, Player 2 wins
            DisplayWinner("Player 2 Wins!");
        }
        else if (!player2Alive)
        {
            // If Player 2 is dead, Player 1 wins
            DisplayWinner("Player 1 Wins!");
        }

        // After determining the winner, stop the game
        gameManager.DisableGameComponents();
    }

    // Display the winner message using TMP text
    private void DisplayWinner(string message)
    {
        if (winnerText != null)
        {
            winnerText.text = message; // Set the winner text
            Debug.Log(message); // Log the winner message
        }
        else
        {
            Debug.LogWarning("Winner text TMP reference is not set!");
        }
    }

    // Reset game state for a new round if needed
    public void ResetGameState()
    {
        player1Alive = true;
        player2Alive = true;
        winnerText.text = ""; // Clear the winner message
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameTetrisGameOver : MonoBehaviour
{
    [SerializeField] private TMP_Text winnerText; // Reference to the UI Text component for the winner display

    [SerializeField] private GameTetrisScoreManager scoreManager; // Reference to the score manager

    private void Start()
    {
        // Clear the winner text at the start
        if (winnerText != null)
        {
            winnerText.text = ""; // Clear the text at the start
        }
    }

    // Method to check game over conditions
    public void CheckGameOver()
    {
        Debug.Log("Checking Game Over conditions..."); // Debug statement

        // Retrieve current scores
        int player1Score = scoreManager.currentScorePlayer1;
        int player2Score = scoreManager.currentScorePlayer2;

        // Determine winner based on scores
        if (player1Score > player2Score)
        {
            Debug.Log("Player 1 wins!");
            DisplayWinner("Player 1 Wins!");
        }
        else if (player2Score > player1Score)
        {
            Debug.Log("Player 2 wins!");
            DisplayWinner("Player 2 Wins!");
        }
        else
        {
            Debug.Log("It's a tie!");
            DisplayWinner("It's a Tie!");
        }

        // Optional: Stop the game (e.g., pause it)
        Time.timeScale = 0f; // Stop the game
    }

    // Method to update the winner text
    private void DisplayWinner(string winnerMessage)
    {
        if (winnerText != null)
        {
            winnerText.text = winnerMessage; // Update the winner text
        }
    }
}

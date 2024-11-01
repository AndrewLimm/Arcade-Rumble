using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StayAliveGameOverManager : MonoBehaviour
{
    [SerializeField] private TMP_Text winnerText; // Reference to the UI Text component

    [SerializeField] private StayAlivePlayerHEalth player1Health; // Reference to Player 1's health
    [SerializeField] private StayAlivePlayerHEalth player2Health; // Reference to Player 2's health

    private bool endLineTouched = false; // Track if the end line was touched


    void Start()
    {
        // Optional: You can initialize the winner text to be empty or a default message
        if (winnerText != null)
        {
            winnerText.text = ""; // Clear the text at the start
        }
    }

    // Method to trigger game over conditions
    public void TriggerEnd()
    {
        Debug.Log("Checking Game Over conditions..."); // Debug statement

        // Check if either player's health is zero
        if (player1Health.currentHealth <= 0 && player2Health.currentHealth <= 0)
        {
            Debug.Log("It's a tie!");
            DisplayWinner("It's a tie!");
            LoadSpecialMiniGame();
        }
        else if (player1Health.currentHealth <= 0 || endLineTouched)
        {
            Debug.Log("Player 2 wins!");
            DisplayWinner("Player 2 Wins!");
            GameRumbleGameManagerForScore.instance.AddWinPoint(2);
            Invoke("GoToResultScreen", 0.5f); // Menunggu 2 detik sebelum pindah
        }
        else if (player2Health.currentHealth <= 0 || endLineTouched)
        {
            Debug.Log("Player 1 wins!");
            DisplayWinner("Player 1 Wins!");
            GameRumbleGameManagerForScore.instance.AddWinPoint(1);
            Invoke("GoToResultScreen", 0.5f); // Menunggu 2 detik sebelum pindah
        }
        // Stop the game (optional)
        // Removed gameOverUI logic as per your request
    }

    // Method to update the winner text
    private void DisplayWinner(string winnerMessage)
    {
        if (winnerText != null)
        {
            winnerText.text = winnerMessage; // Update the winner text
        }
    }


    // Method to set the end line touched state
    public void SetEndLineTouched(bool touched)
    {
        endLineTouched = touched;
    }

    public void LoadSpecialMiniGame()
    {
        SceneManager.LoadScene("RaceToTheFinish"); // Ganti dengan nama scene mini-game khusus
    }

    private void GoToResultScreen()
    {
        SceneManager.LoadScene("ArcadeRumbleResultScreen"); // Ganti dengan nama scene layar hasil yang sesuai
    }
}

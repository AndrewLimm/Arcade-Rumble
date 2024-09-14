using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameEnded : MonoBehaviour
{
    public GameObject gameEndCanvas;  // Reference to the Canvas that shows the game end message
    public TMP_Text winnerText;           // Reference to the UI Text element to display the winner

    private bool gameEnded = false;

    // Call this function when a player wins
    public void EndGame(string winner)
    {
        if (gameEnded)
            return;

        gameEnded = true;
        gameEndCanvas.SetActive(true);   // Show the game end canvas
        winnerText.text = winner + " Wins!";   // Display the winner message
        Time.timeScale = 0f;   // Pause the game (optional)
    }
}

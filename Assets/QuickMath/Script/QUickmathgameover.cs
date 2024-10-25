using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QUickmathgameover : MonoBehaviour
{
    [SerializeField] private QuickMathScoreManager scoreManager; // Reference to the score manager
    [SerializeField] private TMP_Text winnerText; // Text to display the winner

    void Start()
    {
        // Make sure the winner text is hidden before the game starts
        winnerText.gameObject.SetActive(false);
        gameObject.SetActive(false); // Ensure the game over panel is hidden at the start
    }

    // Method to determine the game result based on players' scores
    public void CheckWinner()
    {
        // Determine the winner based on scores
        if (scoreManager.skorPemain1 < scoreManager.skorPemain2)
        {
            winnerText.text = "Player 2 Wins!";
        }
        else if (scoreManager.skorPemain1 > scoreManager.skorPemain2)
        {
            winnerText.text = "Player 1 Wins!";
        }
        else
        {
            winnerText.text = "It's a Tie!";
        }

        // Enable the game over panel and display the winner text
        winnerText.gameObject.SetActive(true);
        gameObject.SetActive(true);
    }
}

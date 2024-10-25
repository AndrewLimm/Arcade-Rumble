using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuickTapGameOver : MonoBehaviour
{
    [SerializeField] PlayerCollect playerCollect;
    [SerializeField] QuickTapPlayer2Input player2Collect;

    // Reference to TMP Text for displaying the winner
    [SerializeField] private TMP_Text winnerText;

    private void Start()
    {
        // Hide the winner text at the start of the game
        if (winnerText != null)
        {
            winnerText.gameObject.SetActive(false);
        }
    }

    public void EndGameCondition()
    {
        if (winnerText != null)
        {
            winnerText.gameObject.SetActive(true); // Show the text when game ends

            // Check the scores and display the winner
            if (playerCollect.playerScore > player2Collect.playerScore)
            {
                winnerText.text = "Player 1 Wins!";
            }
            else if (playerCollect.playerScore < player2Collect.playerScore)
            {
                winnerText.text = "Player 2 Wins!";
            }
            else
            {
                winnerText.text = "It's a Draw!";
            }
        }
    }
}

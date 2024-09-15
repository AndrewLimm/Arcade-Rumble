using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ReactionTestScoreManager : MonoBehaviour
{
    public TMP_Text player1ScoreText;  // UI untuk skor Player 1
    public TMP_Text player2ScoreText;  // UI untuk skor Player 2

    private int player1Score = 0;
    private int player2Score = 0;

    void Start()
    {
        UpdateScoreUI();
    }

    public void UpdateScore(int playerNumber)
    {
        if (playerNumber == 1)
        {
            player1Score++;
        }
        else if (playerNumber == 2)
        {
            player2Score++;
        }
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        player1ScoreText.text = "Player 1 Score: " + player1Score;
        player2ScoreText.text = "Player 2 Score: " + player2Score;
    }
}

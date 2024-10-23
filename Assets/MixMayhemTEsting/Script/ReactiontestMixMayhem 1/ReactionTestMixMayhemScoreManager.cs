using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ReactionTestMixMayhemScoreManager : MonoBehaviour
{
    public TMP_Text player1ScoreText;  // UI untuk skor Player 1
    public TMP_Text player2ScoreText;  // UI untuk skor Player 2

    public int reactiontestplayer1Score = 0;
    public int reactiontestplayer2Score = 0;

    void Start()
    {
        UpdateScoreUI();
    }

    public void UpdateScore(int playerNumber)
    {
        if (playerNumber == 1)
        {
            reactiontestplayer1Score++;
        }
        else if (playerNumber == 2)
        {
            reactiontestplayer2Score++;
        }
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        player1ScoreText.text = "Player 1 Score: " + reactiontestplayer1Score;
        player2ScoreText.text = "Player 2 Score: " + reactiontestplayer2Score;
    }
}

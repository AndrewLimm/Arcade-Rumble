using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyAnimalScoreManager : MonoBehaviour
{
    public static FlappyAnimalScoreManager Instance { get; private set; }

    public int player1Score { get; private set; } = 0;
    public int player2Score { get; private set; } = 0;

    private void Awake()
    {
        if (Instance != null)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    public void IncreasePlayer1Score()
    {
        player1Score++;
        FlappyAnimalScoreUI.Instance.UpdatePlayer1ScoreText(player1Score);
    }

    public void IncreasePlayer2Score()
    {
        player2Score++;
        FlappyAnimalScoreUI.Instance.UpdatePlayer2ScoreText(player2Score);
    }

    public void ResetScores()
    {
        player1Score = 0;
        player2Score = 0;
        FlappyAnimalScoreUI.Instance.UpdatePlayer1ScoreText(player1Score);
        FlappyAnimalScoreUI.Instance.UpdatePlayer2ScoreText(player2Score);
    }
}

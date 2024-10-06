using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FlappyAnimalScoreUI : MonoBehaviour
{
    public static FlappyAnimalScoreUI Instance { get; private set; }

    public TMP_Text player1ScoreText;
    public TMP_Text player2ScoreText;

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

    public void UpdatePlayer1ScoreText(int newScore)
    {
        player1ScoreText.text = newScore.ToString();
    }

    public void UpdatePlayer2ScoreText(int newScore)
    {
        player2ScoreText.text = newScore.ToString();
    }
}

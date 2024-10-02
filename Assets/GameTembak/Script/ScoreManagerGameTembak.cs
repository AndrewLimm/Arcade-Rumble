using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManagerGameTembak : MonoBehaviour
{

    [SerializeField] UIScoreManagerGameTembak uIScoreManagerGameTembak; // Set through Inspector

    public int player1Score = 0;
    public int player2Score = 0;

    // Fungsi untuk menambah skor Player 1
    public void AddScorePlayer1(int points)
    {
        player1Score += points;
        uIScoreManagerGameTembak.UpdateScoreUIPlayer1(player1Score);
    }

    // Fungsi untuk menambah skor Player 2
    public void AddScorePlayer2(int points)
    {
        player2Score += points;
        uIScoreManagerGameTembak.UpdateScoreUIPlayer2(player2Score);
    }

    // Fungsi untuk mendapatkan skor Player 1
    public int GetScorePlayer1()
    {
        return player1Score;
    }

    // Fungsi untuk mendapatkan skor Player 2
    public int GetScorePlayer2()
    {
        return player2Score;
    }
}

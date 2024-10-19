using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MemoryMatchPlayer1Score : MonoBehaviour
{
    public int player1Score = 0; // Skor awal untuk Player 1
    public TMP_Text player1ScoreText; // UI Text untuk menampilkan skor Player 1
    public int pointsPerCorrectAnswer = 10; // Poin yang didapatkan untuk setiap jawaban benar

    // Fungsi untuk menambah skor
    public void AddScore()
    {
        player1Score += pointsPerCorrectAnswer;
        UpdateScoreUI();
    }

    // Fungsi untuk memperbarui tampilan UI skor
    private void UpdateScoreUI()
    {
        if (player1ScoreText != null)
        {
            player1ScoreText.text = "Player 1 Score: " + player1Score.ToString();
        }
    }
}

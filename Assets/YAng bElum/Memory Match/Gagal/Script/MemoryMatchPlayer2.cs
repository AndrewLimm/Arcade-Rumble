using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MemoryMatchPlayer2 : MonoBehaviour
{
    public int player2Score = 0; // Skor awal untuk Player 2
    public TMP_Text player2ScoreText; // UI Text untuk menampilkan skor Player 2
    public int pointsPerCorrectAnswer = 10; // Poin yang didapatkan untuk setiap jawaban benar

    // Fungsi untuk menambah skor
    public void AddScore()
    {
        player2Score += pointsPerCorrectAnswer;
        UpdateScoreUI();
    }

    // Fungsi untuk memperbarui tampilan UI skor
    private void UpdateScoreUI()
    {
        if (player2ScoreText != null)
        {
            player2ScoreText.text = "Player 2 Score: " + player2Score.ToString();
        }
    }
}

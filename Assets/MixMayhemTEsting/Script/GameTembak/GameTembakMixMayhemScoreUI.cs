using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameTembakMixMayhemScoreUI : MonoBehaviour
{
    [SerializeField] private TMP_Text player1ScoreText; // Set through Inspector
    [SerializeField] private TMP_Text player2ScoreText; // Set through Inspector

    // Fungsi untuk memperbarui tampilan skor di UI
    public void UpdateScoreUIPlayer1(int player1Score)
    {
        player1ScoreText.text = "Player 1 Score: " + player1Score.ToString();
    }

    public void UpdateScoreUIPlayer2(int player2Score)
    {
        player2ScoreText.text = "Player 2 Score: " + player2Score.ToString();
    }
}

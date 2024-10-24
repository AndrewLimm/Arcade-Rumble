using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameTembakGameOverManager : MonoBehaviour
{
    [SerializeField] ScoreManagerGameTembak scoreManagerGameTembak;
    [SerializeField] private TMP_Text resultText; // Referensi ke UI Text untuk menampilkan hasil

    [SerializeField] private GameTembakGameManager gameTembakGameManager;

    void Start()
    {
        // Sembunyikan teks Game Over saat permainan dimulai
        if (resultText != null)
        {
            resultText.gameObject.SetActive(false); // Menyembunyikan GameOverText
        }
    }

    public void CheckGameOver()
    {
        int player1Score = scoreManagerGameTembak.player1Score;
        int player2Score = scoreManagerGameTembak.player2Score;

        if (player1Score < player2Score)
        {
            DisplayResult("Player 2 Wins!");

        }
        else if (player1Score > player2Score)
        {
            DisplayResult("Player 1 Wins!");

        }
        else if (player1Score == player2Score)
        {
            DisplayResult("Draw!");
        }
    }
    public void DisplayResult(string result)
    {
        resultText.text = result; // Tampilkan hasil di UI Text
        resultText.gameObject.SetActive(true); // Tampilkan Game Over Text
        Debug.Log(result); // Log hasil

        gameTembakGameManager.StopGame(); // Hentikan permainan
    }
}

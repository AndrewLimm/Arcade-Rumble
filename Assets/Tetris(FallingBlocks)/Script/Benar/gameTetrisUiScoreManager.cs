using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class gameTetrisUiScoreManager : MonoBehaviour
{
    public TMP_Text scoreTextPlayer1; // Elemen teks UI untuk menampilkan skor Player 1
    public TMP_Text scoreTextPlayer2; // Elemen teks UI untuk menampilkan skor Player 2

    private GameTetrisScoreManager scoreManager;

    private void Start()
    {
        scoreManager = FindObjectOfType<GameTetrisScoreManager>();
        UpdateScoreUI();
    }

    private void OnEnable()
    {
        UpdateScoreUI(); // Memastikan UI diperbarui saat skrip aktif
    }

    public void UpdateScoreUI()
    {
        if (scoreManager != null)
        {
            // Perbarui skor untuk Player 1
            if (scoreTextPlayer1 != null)
            {
                scoreTextPlayer1.text = "Skor Player 1: " + scoreManager.currentScorePlayer1.ToString();
            }

            // Perbarui skor untuk Player 2
            if (scoreTextPlayer2 != null)
            {
                scoreTextPlayer2.text = "Skor Player 2: " + scoreManager.currentScorePlayer2.ToString();
            }
        }
    }
}

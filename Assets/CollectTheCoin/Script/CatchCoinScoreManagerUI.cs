using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CatchCoinScoreManagerUI : MonoBehaviour
{
    public TMP_Text player1ScoreText; // Referensi ke Text UI Player 1
    public TMP_Text player2ScoreText; // Referensi ke Text UI Player 2

    private CollectCoinPlayer1CoinCollector player1Collector; // Referensi ke script Player1CoinCollector
    private CollectCoinPlayer2CoinCollector player2Collector; // Referensi ke script Player2CoinCollector

    private void Start()
    {
        // Temukan dan ambil referensi dari script collector
        player1Collector = FindObjectOfType<CollectCoinPlayer1CoinCollector>();
        player2Collector = FindObjectOfType<CollectCoinPlayer2CoinCollector>();

        UpdateScoreUI(); // Memperbarui tampilan skor di awal
    }

    private void Update()
    {
        UpdateScoreUI(); // Memperbarui tampilan skor setiap frame
    }

    // Update UI skor berdasarkan nilai saat ini
    void UpdateScoreUI()
    {
        player1ScoreText.text = "Player 1 Score: " + player1Collector.scoreplayer1.ToString();
        player2ScoreText.text = "Player 2 Score: " + player2Collector.scoreplayer2.ToString();
    }
}

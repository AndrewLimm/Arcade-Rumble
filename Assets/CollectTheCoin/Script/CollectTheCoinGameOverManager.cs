using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectTheCoinGameOverManager : MonoBehaviour
{
    [SerializeField] CollectCoinPlayer1CoinCollector collectCoinPlayer1CoinCollector;
    [SerializeField] CollectCoinPlayer2CoinCollector collectCoinPlayer2CoinCollector;

    public void CheckGameOver()
    {
        int player1Score = collectCoinPlayer1CoinCollector.GetScore(); // Mendapatkan skor Player 1
        int player2Score = collectCoinPlayer2CoinCollector.GetScore(); // Mendapatkan skor Player 2

        // Kondisi untuk memeriksa siapa yang menang atau kalah
        if (player1Score > player2Score)
        {
            Player1Wins();
        }
        else if (player1Score < player2Score)
        {
            Player2Wins();
        }
        else
        {
            Draw(); // Kondisi jika skor imbang
        }
    }

    // Metode untuk menangani kemenangan Player 1
    private void Player1Wins()
    {
        Debug.Log("Player 1 wins!");
        // Tambahkan logika lain di sini, misalnya tampilkan UI atau efek kemenangan
    }

    // Metode untuk menangani kemenangan Player 2
    private void Player2Wins()
    {
        Debug.Log("Player 2 wins!");
        // Tambahkan logika lain di sini, misalnya tampilkan UI atau efek kemenangan
    }

    // Metode untuk menangani hasil imbang
    private void Draw()
    {
        Debug.Log("It's a draw!");
        // Tambahkan logika lain di sini untuk hasil imbang, misalnya UI spesifik
    }
}
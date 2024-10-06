using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoinPlayer1CoinCollector : MonoBehaviour
{
    public int score = 0; // Skor awal Player 1
    public int pointValue = 10; // Nilai koin yang ditambahkan saat diambil

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Cek apakah yang disentuh adalah koin
        if (other.CompareTag("Coin"))
        {
            // Tambahkan skor untuk Player 1
            score += pointValue;
            Debug.Log("Player 1 Score: " + score);

            // Hancurkan koin setelah diklaim
            Destroy(other.gameObject);
        }
    }
}

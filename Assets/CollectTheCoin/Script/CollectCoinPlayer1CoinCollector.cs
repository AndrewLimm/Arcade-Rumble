using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoinPlayer1CoinCollector : MonoBehaviour
{
    public int scoreplayer1 = 0; // Skor awal Player 1
    public int pointValue = 10; // Nilai koin yang ditambahkan saat diambil


    [SerializeField] public AudioClip coinCollectSound; // Suara untuk koleksi koin
    public AudioSource audioSource;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Cek apakah yang disentuh adalah koin
        if (other.CompareTag("Coin"))
        {
            // Tambahkan skor untuk Player 1
            scoreplayer1 += pointValue;
            Debug.Log("Player 1 Score: " + scoreplayer1);

            if (coinCollectSound != null)
            {
                audioSource.PlayOneShot(coinCollectSound);
            }


            // Hancurkan koin setelah diklaim
            Destroy(other.gameObject);
        }
    }

    public int GetScore()
    {
        return scoreplayer1;
    }
}

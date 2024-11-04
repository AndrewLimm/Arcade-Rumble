using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoinPlayer2CoinCollector : MonoBehaviour
{
    public int scoreplayer2 = 0; // Skor awal Player 2
    public int pointValue = 10; // Nilai koin yang ditambahkan saat diambil
    [SerializeField] public AudioClip coinCollectSound; // Suara untuk koleksi koin
    public AudioSource audioSource;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Cek apakah yang disentuh adalah koin
        if (other.CompareTag("Coin"))
        {
            // Tambahkan skor untuk Player 2
            scoreplayer2 += pointValue;
            Debug.Log("Player 2 Score: " + scoreplayer2);


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
        return scoreplayer2;
    }
}

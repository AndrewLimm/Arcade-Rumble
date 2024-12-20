using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoinSpeedBoost : MonoBehaviour
{
    public float boostDuration = 3f; // Durasi speed boost
    public float boostMultiplier = 2f; // Pengganda kecepatan

    [SerializeField] public AudioClip collectSound; // AudioClip untuk suara pengumpulan
    public AudioSource audioSource; // AudioSource untuk memutar suara

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Jika Player 1 yang menyentuh item, berikan speed boost ke Player 1
        if (other.CompareTag("Player1Collector"))
        {
            CollectCoinPlayer1Movement player1Movement = other.GetComponent<CollectCoinPlayer1Movement>();
            if (player1Movement != null)
            {
                player1Movement.ActivateSpeedBoost(boostMultiplier, boostDuration); // Aktifkan speed boost
                if (collectSound != null)
                {
                    audioSource.PlayOneShot(collectSound);
                }

                // Hancurkan item setelah sedikit waktu untuk memastikan suara sempat dimainkan
                Destroy(gameObject, collectSound.length);
            }
        }
        // Jika Player 2 yang menyentuh item, berikan speed boost ke Player 2
        else if (other.CompareTag("Player2Collector"))
        {
            CollectCoinPlayer2Movement player2Movement = other.GetComponent<CollectCoinPlayer2Movement>();
            if (player2Movement != null)
            {
                player2Movement.ActivateSpeedBoost(boostMultiplier, boostDuration); // Aktifkan speed boost
                if (collectSound != null)
                {
                    audioSource.PlayOneShot(collectSound);
                }

                // Hancurkan item setelah sedikit waktu untuk memastikan suara sempat dimainkan
                Destroy(gameObject, collectSound.length);
            }
        }
    }
}

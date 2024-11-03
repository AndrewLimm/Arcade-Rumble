using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchItemCollectibleOnHIt : MonoBehaviour
{
    [SerializeField] CatchItemCollectible _collectible;
    private CatchItemScoreManagerPlayer1 _scoreManagerPlayer1;


    [SerializeField] private AudioClip collectSound; // AudioClip untuk suara koleksi
    private AudioSource audioSource; // AudioSource untuk memutar suara

    private void Start()
    {
        // Mengambil referensi ke CatchItemScoreManagerPlayer1 di scene
        _scoreManagerPlayer1 = FindObjectOfType<CatchItemScoreManagerPlayer1>();
        if (_scoreManagerPlayer1 == null)
        {
            Debug.LogError("CatchItemScoreManagerPlayer1 is missing in the scene.");
        }
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false; // Memastikan tidak memutar saat diaktifkan
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player1Collector") && _scoreManagerPlayer1 != null)
        {
            // Tambahkan skor untuk Player 1
            _scoreManagerPlayer1.AddScore(_collectible.value);
            _collectible.TriggerCollection(collision.gameObject);

            // Jika ada suara koleksi, mainkan dengan AudioSource sementara
            if (collectSound != null)
            {
                PlayCollectSound();
            }

            // Nonaktifkan collectible setelah item dikumpulkan
            gameObject.SetActive(false);
        }
    }
    private void PlayCollectSound()
    {
        // Membuat game object sementara untuk audio source
        GameObject audioObject = new GameObject("TempAudio");
        AudioSource audioSource = audioObject.AddComponent<AudioSource>();

        // Set AudioClip dan volume
        audioSource.clip = collectSound;
        audioSource.Play();

        // Hancurkan audioObject setelah durasi clip selesai
        Destroy(audioObject, collectSound.length);
    }
}


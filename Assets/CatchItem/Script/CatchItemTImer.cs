using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class CatchItemTImer : MonoBehaviour
{
    [SerializeField] public float gameDuration = 60f; // Durasi permainan dalam detik
    [SerializeField] private TMP_Text timerText; // Referensi ke UI text untuk menampilkan timer
    [SerializeField] private CatchItemGameOverManager gameOverManager; // Referensi ke Game Over Manager
    [SerializeField] private CatchItemGameManager catchItemGameManager;


    private float timeRemaining; // Waktu yang tersisa
    private Coroutine timerCoroutine; // Menyimpan coroutine timer

    private void Start()
    {
        timeRemaining = gameDuration; // Inisialisasi waktu tersisa
        UpdateTimerText(); // Update teks timer di UI
    }

    public void StartTimer() // Method untuk memulai timer
    {
        if (timerCoroutine != null) // Jika timer sudah berjalan, hentikan
        {
            StopCoroutine(timerCoroutine);
        }
        timerCoroutine = StartCoroutine(TimerCoroutine()); // Mulai coroutine timer
    }

    private IEnumerator TimerCoroutine()
    {
        while (timeRemaining > 0)
        {
            yield return new WaitForSeconds(1f); // Tunggu 1 detik
            timeRemaining--; // Kurangi waktu tersisa
            UpdateTimerText(); // Perbarui teks timer di UI
        }

        // Jika waktu habis, panggil metode untuk mengecek game over
        EndGame();
    }

    private void UpdateTimerText()
    {
        // Tampilkan waktu yang tersisa dalam format menit:detik
        timerText.text = $"Time: {timeRemaining}s";
    }

    private void EndGame()
    {
        //mematikan semua game object
        catchItemGameManager.DisableAllGameObjects(); // Pastikan ini ada di GameManager


        // Panggil metode untuk memeriksa kondisi game over
        gameOverManager.CheckGameOver();
    }
}

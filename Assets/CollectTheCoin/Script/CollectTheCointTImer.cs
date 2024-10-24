using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollectTheCointTImer : MonoBehaviour
{
    public float gameDuration = 60f;
    public TMP_Text CollectTheCoinTImer;

    private float timeRemaining; // Waktu yang tersisa
    private Coroutine timerCoroutine; // Menyimpan coroutine timer

    [SerializeField] CollectTheCoinGameOverManager collectTheCoinGameOverManager;

    private void Start()
    {
        timeRemaining = gameDuration; // Inisialisasi waktu tersisa
        UpdateTimerText(); // Perbarui teks timer di UI
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

        // Ketika waktu habis
        EndGame();
    }

    private void UpdateTimerText()
    {
        // Tampilkan waktu yang tersisa dalam format detik
        CollectTheCoinTImer.text = $"Time: {timeRemaining}s";
    }

    private void EndGame()
    {
        // Di sini Anda dapat memanggil fungsi lain untuk mengakhiri permainan,
        // seperti menampilkan pesan game over, atau logika lain yang relevan.

        collectTheCoinGameOverManager.CheckGameOver();
        Debug.Log("Waktu habis! Game selesai.");
    }
}

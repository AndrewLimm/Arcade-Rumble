using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MemoryMatchGameTImer : MonoBehaviour
{
    public float gameDuration = 60f; // Total durasi permainan dalam detik
    private float currentTime; // Waktu tersisa untuk permainan
    public TMP_Text timerText; // UI Text untuk menampilkan timer
    private bool isGameRunning = false; // Flag untuk mengecek apakah permainan sedang berjalan

    private void Start()
    {
        StartGameTimer(); // Mulai timer saat permainan dimulai
    }

    private void Update()
    {
        if (isGameRunning)
        {
            currentTime -= Time.deltaTime; // Kurangi waktu berdasarkan waktu berlalu per frame
            UpdateTimerUI();

            if (currentTime <= 0)
            {
                EndGame(); // Jika waktu habis, panggil fungsi ini
            }
        }
    }

    public void StartGameTimer()
    {
        currentTime = gameDuration; // Setel waktu ke durasi permainan
        isGameRunning = true; // Mulai permainan
        UpdateTimerUI();
    }

    public void StopGameTimer()
    {
        isGameRunning = false; // Hentikan timer permainan
    }

    private void UpdateTimerUI()
    {
        timerText.text = "Time Left: " + Mathf.Ceil(currentTime).ToString() + "s"; // Perbarui tampilan UI dengan waktu tersisa
    }

    private void EndGame()
    {
        isGameRunning = false; // Hentikan permainan
        Debug.Log("Waktu Permainan Habis! Permainan Berakhir.");
        // Panggil logika untuk menampilkan layar Game Over atau hasil akhir

        // Misalnya, panggil fungsi untuk menampilkan skor akhir pemain di sini

    }
}

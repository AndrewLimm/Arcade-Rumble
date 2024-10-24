using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameTembakTImer : MonoBehaviour
{
    public float gameDuration = 60f; // Durasi permainan dalam detik
    private float timeRemaining; // Waktu yang tersisa
    public TMP_Text timerText; // UI Text untuk menampilkan waktu
    [SerializeField] private GameTembakGameOverManager gameOverManager; // Referensi ke GameOverManager

    private bool timerIsRunning = false; // Flag untuk mengontrol timer

    void Start()
    {
        timeRemaining = gameDuration; // Inisialisasi waktu yang tersisa
        UpdateTimerText();
    }

    void Update()
    {
        if (timerIsRunning)
        {
            // Kurangi waktu yang tersisa
            timeRemaining -= Time.deltaTime;

            if (timeRemaining <= 0)
            {
                timeRemaining = 0;
                timerIsRunning = false;
                EndGame(); // Panggil fungsi untuk mengakhiri permainan
            }

            UpdateTimerText();
        }
    }

    public void StartTimer()
    {
        timerIsRunning = true; // Mulai timer
    }

    public void StopTimer()
    {
        timerIsRunning = false; // Hentikan timer
    }

    private void UpdateTimerText()
    {
        // Perbarui UI Text untuk menampilkan waktu yang tersisa
        timerText.text = "Time Remaining: " + Mathf.Round(timeRemaining).ToString();
    }

    private void EndGame()
    {
        gameOverManager.CheckGameOver(); // Panggil fungsi untuk memeriksa hasil permainan
        Debug.Log("Game Over!"); // Contoh logika Game Over
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuickTapTImer : MonoBehaviour
{
    [SerializeField] public float gameDuration = 60f; // Durasi permainan dalam detik
    [SerializeField] private TMP_Text timerText; // Referensi ke UI text untuk menampilkan timer
    [SerializeField] private QuickTapGameOver gameOverManager;

    public bool isGameActive;
    private float timeRemaining; // Waktu yang tersisa
    private Coroutine timerCoroutine; // Menyimpan coroutine timer

    void Start()
    {
        timeRemaining = gameDuration; // Set the initial time to game duration
        UpdateTimerText();
    }

    // Method to start the timer
    public void StartTimer()
    {
        if (timerCoroutine == null)
        {
            timerCoroutine = StartCoroutine(TimerCountdown());
        }
    }

    // Coroutine for the countdown timer
    private IEnumerator TimerCountdown()
    {
        while (timeRemaining > 0)
        {
            yield return new WaitForSeconds(1f);
            timeRemaining--;
            UpdateTimerText();
        }

        EndGame(); // Call EndGame when time runs out
    }

    // Method to update the timer text UI
    private void UpdateTimerText()
    {
        timerText.text = $"Time: {timeRemaining} s";
    }

    // Method to stop the timer and end the game
    private void EndGame()
    {
        if (timerCoroutine != null)
        {
            StopCoroutine(timerCoroutine);
            timerCoroutine = null;
        }
        isGameActive = false; // Set permainan tidak aktif

        // Trigger game over logic
        gameOverManager.EndGameCondition();
    }

    public float GetRemainingTime()
    {
        return timeRemaining;
    }

    public bool IsGameActive() // Method untuk memeriksa status permainan
    {
        return timeRemaining > 0; // Mengembalikan true jika waktu masih ada
    }
}

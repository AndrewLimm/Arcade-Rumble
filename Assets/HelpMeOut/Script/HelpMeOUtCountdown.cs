using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HelpMeOUtCountdown : MonoBehaviour
{
    public TMP_Text countdownText; // UI Text untuk menampilkan countdown
    public float countdownTime = 5f; // Durasi countdown dalam detik
    public HelpMeOutPlayer1Controller player1Controller; // Referensi ke controller Player 1
    public HelpMeOutPlayer2Controller player2Controller; // Referensi ke controller Player 2

    public delegate void CountdownFinished();
    public static event CountdownFinished OnCountdownFinished; // Event untuk menandakan countdown selesai

    void Start()
    {
        // Menyembunyikan countdown text secara default
        if (countdownText != null)
        {
            countdownText.gameObject.SetActive(false);
            Debug.Log("Countdown text disembunyikan saat permainan dimulai.");
        }
    }

    public void StartCountDown()
    {
        countdownText.gameObject.SetActive(true); // Mengaktifkan countdown text saat mulai
        StartCoroutine(StartCountdown());
    }

    private IEnumerator StartCountdown()
    {
        float remainingTime = countdownTime;

        while (remainingTime > 0)
        {
            countdownText.text = Mathf.Ceil(remainingTime).ToString(); // Tampilkan waktu countdown
            yield return new WaitForSeconds(1f);
            remainingTime--;
        }

        countdownText.text = "GO!";
        yield return new WaitForSeconds(1f);
        countdownText.gameObject.SetActive(false); // Sembunyikan countdown setelah selesai

        OnCountdownFinished?.Invoke(); // Memicu event saat countdown selesai
    }
}


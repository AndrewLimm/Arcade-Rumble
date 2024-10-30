using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuickTapCOuntDOwn : MonoBehaviour
{
    public TMP_Text countdownText; // UI Text untuk menampilkan countdown
    public float countdownTime = 5f; // Durasi countdown dalam detik
    public QuickTapGameManager gameManager; // Referensi ke GameManager

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

        // Langsung panggil metode di GameManager setelah countdown selesai
        if (gameManager != null)
        {
            gameManager.OnCountdownFinished();
        }
    }
}

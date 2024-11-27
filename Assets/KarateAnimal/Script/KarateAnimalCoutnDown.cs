using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KarateAnimalCoutnDown : MonoBehaviour
{
    public TMP_Text countdownText; // UI Text untuk menampilkan countdown
    public float countdownTime = 5f; // Durasi countdown dalam detik

    public delegate void CountdownFinished();
    public static event CountdownFinished OnCountdownFinished; // Event untuk menandakan countdown selesai

    public GameObject attentionObject1; // Objek yang muncul di awal dan menghilang setelah countdown
    public GameObject attentionObject2; // Objek kedua yang muncul sebelum "GO!"

    void Start()
    {
        // Menyembunyikan countdown text secara default
        if (countdownText != null)
        {
            countdownText.gameObject.SetActive(false);
            Debug.Log("Countdown text disembunyikan saat permainan dimulai.");
        }
        if (attentionObject1 != null)
            attentionObject1.SetActive(false);

        if (attentionObject2 != null)
            attentionObject2.SetActive(false);
    }

    public void StartCountDown()
    {
        if (attentionObject1 != null)
            attentionObject1.SetActive(true); // Menampilkan objek perhatian di awal

        if (attentionObject2 != null)
            attentionObject2.SetActive(true); // Menampilkan objek perhatian di awal

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

        if (countdownText != null)
            countdownText.gameObject.SetActive(false); // Sembunyikan teks countdown

        if (attentionObject1 != null)
            attentionObject1.SetActive(false); // Sembunyikan objek perhatian setelah countdown

        if (attentionObject2 != null)   
            attentionObject2.SetActive(false); // Sembunyikan objek perhatian setelah countdown

        OnCountdownFinished?.Invoke(); // Memicu event saat countdown selesai
    }
}

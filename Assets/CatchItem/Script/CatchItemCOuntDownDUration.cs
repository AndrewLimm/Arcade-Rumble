using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CatchItemCOuntDownDUration : MonoBehaviour
{
    public float countdownDuration = 5f; // Durasi countdown
    public TMP_Text countdownText; // Referensi ke TMP_Text untuk menampilkan countdown
    public GameObject attentionObject1; // Objek yang muncul di awal dan menghilang setelah countdown
    public GameObject attentionObject2; // Objek kedua yang muncul sebelum "GO!"

    private void Start()
    {
        if (countdownText != null)
            countdownText.gameObject.SetActive(false);

        if (attentionObject1 != null)
            attentionObject1.SetActive(false);

        if (attentionObject2 != null)
            attentionObject2.SetActive(false);
    }

    // Fungsi yang dipanggil ketika tombol ditekan
    public void StartCountdown()
    {
        if (attentionObject1 != null)
            attentionObject1.SetActive(true); // Menampilkan objek perhatian di awal

        if (attentionObject2 != null)
            attentionObject2.SetActive(true); // Menampilkan objek perhatian di awal
        // Mulai countdown
        StartCoroutine(Countdown());
    }

    private IEnumerator Countdown()
    {
        countdownText.gameObject.SetActive(true); // Menampilkan teks countdown

        float realTimeCountdown = countdownDuration; // Menggunakan real-time countdown terlepas dari Time.timeScale

        // Loop untuk countdown timer
        while (realTimeCountdown > 0)
        {
            countdownText.text = Mathf.Ceil(realTimeCountdown).ToString(); // Tampilkan angka countdown
            yield return new WaitForSecondsRealtime(1f); // Gunakan waktu real-time
            realTimeCountdown--; // Kurangi waktu real-time countdown
        }

        countdownText.text = "GO!"; // Menampilkan 'GO!' setelah countdown selesai
        yield return new WaitForSecondsRealtime(1f); // Tampilkan "GO!" selama 1 detik

        if (countdownText != null)
            countdownText.gameObject.SetActive(false); // Sembunyikan teks countdown

        if (attentionObject1 != null)
            attentionObject1.SetActive(false); // Sembunyikan objek perhatian setelah countdown

        if (attentionObject2 != null)
            attentionObject2.SetActive(false); // Sembunyikan objek perhatian setelah countdown
    }
}

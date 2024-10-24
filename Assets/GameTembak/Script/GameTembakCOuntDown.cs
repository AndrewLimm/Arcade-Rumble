using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameTembakCOuntDown : MonoBehaviour
{
    public float countdownDuration = 5f; // Durasi countdown
    public TMP_Text countdownText; // Referensi ke TMP_Text untuk menampilkan countdown

    private void Start()
    {
        // Sembunyikan countdown text pada awal game
        countdownText.gameObject.SetActive(false);
    }

    // Fungsi yang dipanggil ketika tombol ditekan
    public void StartCountdown()
    {
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

        countdownText.gameObject.SetActive(false); // Sembunyikan teks countdown
    }
}

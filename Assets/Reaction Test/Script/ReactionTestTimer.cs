using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ReactionTestTimer : MonoBehaviour
{
    public float roundDuration = 60f;  // Durasi ronde keseluruhan
    private bool timerActive = false;  // Cek apakah timer aktif
    public ReactionMechanic reactionMechanic;  // Referensi ke ReactionMechanic

    [SerializeField] private TMP_Text timerText;  // Referensi ke TextMeshPro untuk timer

    public void StartTimer()
    {
        timerActive = true;  // Aktifkan timer
        StartCoroutine(TimerCountdown());
    }

    // Coroutine untuk menghitung mundur timer
    private IEnumerator TimerCountdown()
    {
        float remainingTime = roundDuration;

        while (remainingTime > 0 && timerActive)
        {
            remainingTime -= Time.deltaTime;
            UpdateTimerText(remainingTime);  // Update timer text
            yield return null;  // Tunggu hingga frame berikutnya
        }

        if (timerActive)
        {
            timerActive = false;  // Matikan timer
            reactionMechanic.EndGame();  // Panggil fungsi untuk mengakhiri permainan
        }
    }

    // Menghentikan timer jika diperlukan
    public void StopTimer()
    {
        timerActive = false;  // Set timer tidak aktif
    }

    // Fungsi untuk memperbarui teks timer
    private void UpdateTimerText(float time)
    {
        timerText.text = Mathf.Ceil(time).ToString();  // Tampilkan waktu yang tersisa dalam format bulat
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MixMayhemCountdownTImer : MonoBehaviour
{
    public float countdownDuration = 5f; // Durasi countdown
    public TMP_Text countdownText; // Referensi ke TMP_Text untuk menampilkan countdown
    public MixMayhemGameManager gameManager; // Referensi ke Game Manager

    private void Start()
    {
        StartCoroutine(Countdown());
    }

    private IEnumerator Countdown()
    {
        countdownText.gameObject.SetActive(true); // Pastikan teks countdown aktif
        for (int i = (int)countdownDuration; i > 0; i--)
        {
            countdownText.text = i.ToString(); // Tampilkan angka countdown menggunakan TMP_Text
            yield return new WaitForSeconds(1f);
        }

        countdownText.gameObject.SetActive(false); // Sembunyikan teks countdown setelah selesai
        gameManager.StartMiniGame1(); // Panggil fungsi untuk memulai mini-game
    }
}

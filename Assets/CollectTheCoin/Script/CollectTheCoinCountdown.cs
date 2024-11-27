using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollectTheCoinCountdown : MonoBehaviour
{
    public float CountdownTime = 5f;
    public TMP_Text CountDownText;
    public GameObject attentionObject1; // Objek yang muncul di awal dan menghilang setelah countdown
    public GameObject attentionObject2; // Objek kedua yang muncul sebelum "GO!"

    private void Start()
    {
        // Sembunyikan countdown text pada awal game
        CountDownText.gameObject.SetActive(false);

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
        CountDownText.gameObject.SetActive(true); // Menampilkan teks countdown

        float realTimeCountdown = CountdownTime; // Menggunakan real-time countdown terlepas dari Time.timeScale

        // Loop untuk countdown timer
        while (realTimeCountdown > 0)
        {
            CountDownText.text = Mathf.Ceil(realTimeCountdown).ToString(); // Tampilkan angka countdown
            yield return new WaitForSecondsRealtime(1f); // Gunakan waktu real-time
            realTimeCountdown--; // Kurangi waktu real-time countdown
        }

        CountDownText.text = "GO!"; // Menampilkan 'GO!' setelah countdown selesai
        yield return new WaitForSecondsRealtime(1f); // Tampilkan "GO!" selama 1 detik

        if (CountDownText != null)
            CountDownText.gameObject.SetActive(false); // Sembunyikan teks countdown

        if (attentionObject1 != null)
            attentionObject1.SetActive(false); // Sembunyikan objek perhatian setelah countdown

        if (attentionObject2 != null)
            attentionObject2.SetActive(false); // Sembunyikan objek perhatian setelah countdown
    }
}

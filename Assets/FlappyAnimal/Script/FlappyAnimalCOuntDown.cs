using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FlappyAnimalCOuntDown : MonoBehaviour
{
    public float CountdownTime = 5f;
    public TMP_Text CountDownText;

    [SerializeField] FlappyAnimalGameManager flappyAnimalGameManager;

    private void Start()
    {
        // Sembunyikan countdown text pada awal game
        CountDownText.gameObject.SetActive(false);
    }

    // Fungsi yang dipanggil ketika tombol ditekan
    public void StartCountdown()
    {
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

        CountDownText.gameObject.SetActive(false); // Sembunyikan teks countdown

        flappyAnimalGameManager.StartGame();
    }
}

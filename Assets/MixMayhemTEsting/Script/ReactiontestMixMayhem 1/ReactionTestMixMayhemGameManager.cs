using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactionTestMixMayhemGameManager : MonoBehaviour
{
    public Renderer signalRenderer;  // Renderer untuk mengganti warna sinyal
    public float minWaitTime = 3f;  // Waktu minimum sebelum lampu hijau muncul
    public float maxWaitTime = 5f;  // Waktu maksimum sebelum lampu hijau muncul
    public ReactionTestMixMayhemScoreManager scoreManager;  // Referensi ke ScoreManager

    private bool signalShown = false;  // Cek apakah lampu hijau sudah muncul
    private bool gameActive = true;  // Cek apakah game sedang aktif
    private bool inputLocked = false;

    void Start()
    {
        StartCoroutine(GameLoop());
    }

    // Coroutine untuk memulai game
    public IEnumerator GameLoop()
    {
        while (gameActive)
        {
            signalRenderer.material.color = Color.red;  // Mulai dengan lampu merah
            signalShown = false;  // Reset status lampu hijau
            float randomWait = Random.Range(minWaitTime, maxWaitTime);  // Waktu acak untuk menunggu lampu hijau
            yield return new WaitForSeconds(randomWait);

            ShowSignal();  // Ganti ke hijau setelah menunggu
            yield return new WaitUntil(() => inputLocked);  // Tunggu hingga pemain menekan tombol
        }
    }

    // Fungsi untuk menampilkan lampu hijau
    void ShowSignal()
    {
        signalShown = true;  // Tandai bahwa lampu hijau sudah muncul
        signalRenderer.material.color = Color.green;  // Ganti warna menjadi hijau
    }

    // Fungsi ketika pemain menang
    public void PlayerWin(int playerNumber)
    {
        if (!signalShown)  // Cegah input jika lampu hijau belum muncul
            return;

        // Update skor dan reset status
        if (scoreManager != null)
        {
            scoreManager.UpdateScore(playerNumber);  // Update skor pemain
        }

        // Reset status untuk ronde berikutnya
        signalRenderer.material.color = Color.red;  // Kembalikan lampu merah
        signalShown = false;  // Reset status lampu hijau

        // Tampilkan lampu hijau lagi untuk ronde berikutnya
        StartCoroutine(GameLoop());  // Mulai ronde berikutnya
    }

    // Fungsi untuk mengakhiri game (jika diperlukan)
    // Tambahkan logika di sini jika ingin
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactionMechanic : MonoBehaviour
{
    public Renderer signalRenderer;  // Renderer untuk mengganti warna sinyal
    public float roundDuration = 60f;  // Durasi ronde keseluruhan
    public float minWaitTime = 3f;  // Waktu minimum sebelum lampu hijau muncul
    public float maxWaitTime = 5f;  // Waktu maksimum sebelum lampu hijau muncul
    // public GameReset gameReset;  // Referensi ke script reset
    public ReactionTestScoreManager scoreManager;  // Referensi ke ScoreManager

    private bool signalShown = false;  // Cek apakah lampu hijau sudah muncul
    private bool gameActive = true;  // Cek apakah game sedang aktif
    private bool gameFinished = false;  // Cek apakah game sudah selesai
    private bool inputLocked = false;

    public delegate void OnGameEnd(string result);
    public static event OnGameEnd GameEndEvent;  // Event untuk mengirim hasil ke UI

    void Start()
    {
        StartCoroutine(GameLoop());
    }

    void Update()
    {
        if (gameActive)
        {
            roundDuration -= Time.deltaTime;
            if (roundDuration <= 0 && !gameFinished)
            {
                EndGame();
            }
        }
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
        if (gameFinished) return;  // Cegah jika game sudah berakhir
        signalShown = true;  // Tandai bahwa lampu hijau sudah muncul
        signalRenderer.material.color = Color.green;  // Ganti warna menjadi hijau
    }

    // Fungsi ketika pemain menang
    public void PlayerWin(int playerNumber)
    {
        if (!signalShown || gameFinished)  // Cegah input jika lampu hijau belum muncul atau game sudah selesai
            return;

        // Update skor dan reset status
        if (scoreManager != null)
        {
            scoreManager.UpdateScore(playerNumber);  // Update skor pemain
        }

        // Reset status untuk ronde berikutnya
        signalRenderer.material.color = Color.red;  // Kembalikan lampu merah
        signalShown = false;  // Reset status lampu hijau

        // Jika durasi ronde masih ada, teruskan permainan, jika tidak, akhiri permainan
        if (roundDuration > 0)
        {
            StartCoroutine(GameLoop());  // Mulai ronde berikutnya
        }
        else
        {
            EndGame();  // Akhiri permainan jika ronde selesai
        }
    }

    // Fungsi untuk mengakhiri game
    void EndGame()
    {
        gameActive = false;
        gameFinished = true;  // Tandai bahwa permainan sudah berakhir
        if (GameEndEvent != null)
        {
            GameEndEvent("Game Over!");  // Kirim hasil akhir ke UI atau sistem lain
        }
    }
}

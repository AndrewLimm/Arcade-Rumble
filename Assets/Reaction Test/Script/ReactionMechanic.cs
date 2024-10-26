using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactionMechanic : MonoBehaviour
{
    public Renderer signalRenderer;  // Renderer untuk mengganti warna sinyal
    public float minWaitTime = 3f;  // Waktu minimum sebelum lampu hijau muncul
    public float maxWaitTime = 5f;  // Waktu maksimum sebelum lampu hijau muncul
    public ReactionTestScoreManager scoreManager;  // Referensi ke ScoreManager
    public GameOverManagerTextReactionGame gameOverManager;  // Referensi ke GameOverManager

    private bool gameActive = true;  // Cek apakah game sedang aktif
    private bool gameFinished = false;  // Cek apakah game sudah selesai
    private bool signalShown = false;  // Cek apakah lampu hijau sudah muncul
    private bool inputLocked = false;  // Cek apakah input pemain terkunci

    public delegate void OnGameEnd(string result);
    public static event OnGameEnd GameEndEvent;  // Event untuk mengirim hasil ke UI

    void Update()
    {
    }

    public void StartGameLoop()
    {
        StartCoroutine(GameLoop());
    }

    // Coroutine untuk memulai game
    private IEnumerator GameLoop()
    {
        while (gameActive)
        {
            PrepareNextRound();
            yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));
            ShowSignal();
            yield return new WaitUntil(() => inputLocked);
            ResetSignal();
        }
    }

    // Persiapkan ronde berikutnya
    private void PrepareNextRound()
    {
        signalRenderer.material.color = Color.red;  // Mulai dengan lampu merah
        signalShown = false;  // Reset status lampu hijau
        inputLocked = false;  // Reset input lock
    }

    // Fungsi untuk menampilkan lampu hijau
    private void ShowSignal()
    {
        if (gameFinished) return;  // Cegah jika game sudah berakhir
        signalShown = true;  // Tandai bahwa lampu hijau sudah muncul
        signalRenderer.material.color = Color.green;  // Ganti warna menjadi hijau
        inputLocked = false;  // Izinkan input
    }

    // Fungsi ketika pemain menang
    public void PlayerWin(int playerNumber)
    {
        if (!signalShown || gameFinished || inputLocked)  // Cegah input jika lampu hijau belum muncul, game sudah selesai, atau input sudah terkunci
            return;

        inputLocked = true;  // Kunci input untuk mencegah pemain menang lebih dari sekali
        UpdateScore(playerNumber);
        // Assuming the timer handles the game duration
    }

    // Update skor pemain
    private void UpdateScore(int playerNumber)
    {
        if (scoreManager != null)
        {
            scoreManager.UpdateScore(playerNumber);  // Update skor pemain
        }
    }

    // Fungsi untuk mengakhiri game
    public void EndGame()
    {
        gameActive = false;
        gameFinished = true;  // Tandai bahwa permainan sudah berakhir
        GameEndEvent?.Invoke("Game Over!");  // Kirim hasil akhir ke UI atau sistem lain
        gameOverManager.EndGameCondition();  // Panggil fungsi untuk menampilkan hasil akhir
    }

    // Reset sinyal ke kondisi awal
    private void ResetSignal()
    {
        signalRenderer.material.color = Color.red;  // Kembalikan lampu merah
        signalShown = false;  // Reset status lampu hijau
    }
}

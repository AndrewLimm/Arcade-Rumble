using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CatchItemGameOverManager : MonoBehaviour
{
    [SerializeField] CatchItemScoreManagerPlayer1 catchItemScoreManagerPlayer1;
    [SerializeField] CatchItemScoreManagerPlayer2 catchItemScoreManagerPlayer2;

    public TMP_Text GameOverText;

    private void Start()
    {
        // Sembunyikan teks Game Over saat permainan dimulai
        if (GameOverText != null)
        {
            GameOverText.gameObject.SetActive(false); // Menyembunyikan GameOverText
        }
    }

    // Metode ini harus dipanggil untuk memeriksa kondisi game over
    public void CheckGameOver()
    {
        // Ambil skor dari kedua pemain
        int scorePlayer1 = catchItemScoreManagerPlayer1.GetScore();
        int scorePlayer2 = catchItemScoreManagerPlayer2.GetScore();

        // Tentukan siapa yang menang dan tampilkan hasil
        if (scorePlayer1 > scorePlayer2)
        {
            DisplayResult("Player 1 Wins!");
            GameRumbleGameManagerForScore.instance.AddWinPoint(1);
            Invoke("GoToResultScreen", 0.3f); // Menunggu 2 detik sebelum pindah
        }
        else if (scorePlayer2 > scorePlayer1)
        {
            DisplayResult("Player 2 Wins!");
            GameRumbleGameManagerForScore.instance.AddWinPoint(2);
            Invoke("GoToResultScreen", 0.3f); // Menunggu 2 detik sebelum pindah

        }
        else if (scorePlayer1 == scorePlayer2)
        {
            DisplayResult("It's a Tie!");
            LoadSpecialMiniGame();
        }
    }

    // Metode untuk menampilkan hasil di UI
    private void DisplayResult(string message)
    {
        // Tampilkan pesan hasil di UI
        if (GameOverText != null)
        {
            GameOverText.text = message;
            GameOverText.gameObject.SetActive(true); // Aktifkan GameOverText

        }
        Debug.Log(message); // Untuk debug, bisa dihapus jika tidak diperlukan
    }

    private void LoadSpecialMiniGame()
    {
        SceneManager.LoadScene("RaceToTheFinish"); // Ganti dengan nama scene mini-game khusus
    }

    // Metode untuk memindahkan ke layar hasil
    private void GoToResultScreen()
    {
        SceneManager.LoadScene("ArcadeRumbleResultScreen"); // Ganti dengan nama scene layar hasil yang sesuai
    }
}

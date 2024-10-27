using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRumbleResultGameScreenManager : MonoBehaviour
{
    public TMP_Text player1ScoreText;
    public TMP_Text player2ScoreText;

    private void Start()
    {
        // Menampilkan skor sementara dari GameManager
        player1ScoreText.text = "Player 1 Score: " + GameRumbleGameManagerForScore.instance.player1Wins;
        player2ScoreText.text = "Player 2 Score: " + GameRumbleGameManagerForScore.instance.player2Wins;
    }

    public void OnContinueButtonPressed()
    {
        // Kembali ke Game Selection tanpa mereset skor
        GameRumbleGameManagerForScore.instance.GoToGameSelection();
    }

    public void OnEndGameButtonPressed()
    {
        // Mereset skor saat pemain memilih End Game dan pindah ke Final Result Screen
        GameRumbleGameManagerForScore.instance.ResetScores();
        SceneManager.LoadScene("ArcandeRumbleResultFinish");
    }
}

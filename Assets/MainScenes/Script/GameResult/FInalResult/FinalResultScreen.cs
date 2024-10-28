using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalResultScreen : MonoBehaviour
{
    public TMP_Text finalPlayer1ScoreText;
    public TMP_Text finalPlayer2ScoreText;
    public TMP_Text winnerText;

    private void Start()
    {
        // Menampilkan skor akhir dari GameManager
        finalPlayer1ScoreText.text = "Final Score - Player 1: " + GameRumbleGameManagerForScore.instance.player1Wins;
        finalPlayer2ScoreText.text = "Final Score - Player 2: " + GameRumbleGameManagerForScore.instance.player2Wins;

        // Menentukan dan menampilkan pemenang berdasarkan skor akhir
        if (GameRumbleGameManagerForScore.instance.player1Wins > GameRumbleGameManagerForScore.instance.player2Wins)
        {
            winnerText.text = "Player 1 Wins!";
        }
        else if (GameRumbleGameManagerForScore.instance.player2Wins > GameRumbleGameManagerForScore.instance.player1Wins)
        {
            winnerText.text = "Player 2 Wins!";
        }
    }   

    public void OnExitGamePressed()
    {
        // Reset skor dan kembali ke main menu (GameRumbleMainScene)
        GameRumbleGameManagerForScore.instance.ResetScores();
        SceneManager.LoadScene("ArcadeRumbleMainScene");
    }
}

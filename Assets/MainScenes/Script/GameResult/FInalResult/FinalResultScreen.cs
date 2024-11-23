using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Tambahkan ini untuk menggunakan komponen Image


public class FinalResultScreen : MonoBehaviour
{
    public TMP_Text finalPlayer1ScoreText;
    public TMP_Text finalPlayer2ScoreText;
    public TMP_Text winnerText;

    // Tambahkan variabel untuk gambar kemenangan
    public Image winnerImage;           // Image UI component untuk menampilkan gambar
    public Sprite blueTeamWinSprite;    // Gambar A (untuk Tim Biru menang)
    public Sprite redTeamWinSprite;     // Gambar B (untuk Tim Merah menang)
    public Sprite drawSprite;           // Gambar C (untuk kondisi Draw)


    private void Start()
    {
        // Menampilkan skor akhir dari GameManager
        finalPlayer1ScoreText.text = GameRumbleGameManagerForScore.instance.player1Wins.ToString();
        finalPlayer2ScoreText.text = GameRumbleGameManagerForScore.instance.player2Wins.ToString();

        // Menentukan dan menampilkan pemenang berdasarkan skor akhir
        if (GameRumbleGameManagerForScore.instance.player1Wins > GameRumbleGameManagerForScore.instance.player2Wins)
        {
            winnerText.text = "Blue Team Wins!";
            winnerImage.sprite = blueTeamWinSprite;  // Tampilkan gambar A jika Tim Biru menang
        }
        else if (GameRumbleGameManagerForScore.instance.player1Wins < GameRumbleGameManagerForScore.instance.player2Wins)
        {
            winnerText.text = "Red Team Wins!";
            winnerImage.sprite = redTeamWinSprite;   // Tampilkan gambar B jika Tim Merah menang
        }
        else
        {
            winnerText.text = "Draw!";               // Jika skor seri
            winnerImage.sprite = drawSprite;         // Tampilkan gambar Draw
        }
    }

    public void OnExitGamePressed()
    {
        // Reset skor dan kembali ke main menu (GameRumbleMainScene)
        GameRumbleGameManagerForScore.instance.ResetScores();
        SceneManager.LoadScene("ArcadeRumbleMainScene");
    }
}

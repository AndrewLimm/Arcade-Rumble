using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRumbleGameManagerForScore : MonoBehaviour
{
    public static GameRumbleGameManagerForScore instance;

    public int player1Wins = 0;
    public int player2Wins = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Agar GameManager tetap ada di semua scene
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Menambahkan poin untuk pemain yang menang
    public void AddWinPoint(int winningPlayer)
    {
        if (winningPlayer == 1)
            player1Wins++;
        else if (winningPlayer == 2)
            player2Wins++;
    }

    // Reset skor saat pemain memilih untuk mengakhiri permainan
    public void ResetScores()
    {
        player1Wins = 0;
        player2Wins = 0;
    }

    // Pindah ke Result Screen setelah mini-game selesai
    public void GoToResultScreen()
    {
        SceneManager.LoadScene("ArcadeRumbleResultScreen");
    }

    // Pindah ke Game Selection tanpa mereset skor
    public void GoToGameSelection()
    {
        SceneManager.LoadScene("ArcadeRumbleGameSelection");
    }
}

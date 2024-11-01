using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QUickmathgameover : MonoBehaviour
{
    [SerializeField] private QuickMathScoreManager scoreManager; // Reference to the score manager
    [SerializeField] private TMP_Text winnerText; // Text to display the winner

    void Start()
    {
        // Make sure the winner text is hidden before the game starts
        winnerText.gameObject.SetActive(false);
        gameObject.SetActive(false); // Ensure the game over panel is hidden at the start
    }

    // Method to determine the game result based on players' scores
    public void CheckWinner()
    {
        // Determine the winner based on scores
        if (scoreManager.skorPemain1 < scoreManager.skorPemain2)
        {
            winnerText.text = "Player 2 Wins!";
            GameRumbleGameManagerForScore.instance.AddWinPoint(2);
            Invoke("GoToResultScreen", 0.5f); // Menunggu 2 detik sebelum pindah
        }
        else if (scoreManager.skorPemain1 > scoreManager.skorPemain2)
        {
            winnerText.text = "Player 1 Wins!";
            GameRumbleGameManagerForScore.instance.AddWinPoint(1);
            Invoke("GoToResultScreen", 0.5f); // Menunggu 2 detik sebelum pindah
        }
        else
        {
            winnerText.text = "It's a Tie!";
            LoadSpecialMiniGame();
        }

        // Enable the game over panel and display the winner text
        winnerText.gameObject.SetActive(true);
        gameObject.SetActive(true);
    }

    public void LoadSpecialMiniGame()
    {
        SceneManager.LoadScene("RaceToTheFinish"); // Ganti dengan nama scene mini-game khusus
    }

    private void GoToResultScreen()
    {
        SceneManager.LoadScene("ArcadeRumbleResultScreen"); // Ganti dengan nama scene layar hasil yang sesuai
    }
}

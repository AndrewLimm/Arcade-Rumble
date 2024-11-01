using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MemoryMatchGameOver : MonoBehaviour
{
    [SerializeField] MemoryMatchPlayer1Score memoryMatchPlayer1Score; // Reference to Player 1's score
    [SerializeField] MemoryMatchPlayer2 memoryMatchPlayer2; // Reference to Player 2's score

    [SerializeField] TMP_Text winnerText; // Text to display the winner

    private void Start()
    {
        // Initially hide the winner text
        winnerText.gameObject.SetActive(false);
    }

    public void EndCondition()
    {
        // Determine the winner based on the scores
        if (memoryMatchPlayer1Score.player1Score > memoryMatchPlayer2.player2Score)
        {
            winnerText.text = "Player 1 Wins!";
            GameRumbleGameManagerForScore.instance.AddWinPoint(1);
            Invoke("GoToResultScreen", 0.5f); // Menunggu 2 detik sebelum pindah

        }
        else if (memoryMatchPlayer1Score.player1Score < memoryMatchPlayer2.player2Score)
        {
            winnerText.text = "Player 2 Wins!";
            GameRumbleGameManagerForScore.instance.AddWinPoint(2);
            Invoke("GoToResultScreen", 0.5f); // Menunggu 2 detik sebelum pindah
        }
        else
        {
            winnerText.text = "It's a Draw!";
            LoadSpecialMiniGame();
        }

        // Activate the winner text to display the result
        winnerText.gameObject.SetActive(true);
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
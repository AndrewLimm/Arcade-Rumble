using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KarateAnimalGameOverManager : MonoBehaviour
{
    [SerializeField] private KarateAnimalScoreManager karateAnimalScoreManager;
    [SerializeField] private KarateAnimalPlayer2Score karateAnimalPlayer2Score;
    [SerializeField] private KarateAnimalGameManager karateAnimalGameManager;

    public void EndGameCondition()
    {
        // Determine the winner based on scores
        if (karateAnimalPlayer2Score.score > karateAnimalScoreManager.scoreplayer1)
        {
            Debug.Log("Player 2 wins!");
            GameRumbleGameManagerForScore.instance.AddWinPoint(2);
            Invoke("GoToResultScreen", 0.5f); // Menunggu 2 detik sebelum pindah
        }
        else if (karateAnimalPlayer2Score.score < karateAnimalScoreManager.scoreplayer1)
        {
            Debug.Log("Player 1 wins!");
            GameRumbleGameManagerForScore.instance.AddWinPoint(1);
            Invoke("GoToResultScreen", 0.5f); // Menunggu 2 detik sebelum pindah
        }
        else
        {
            Debug.Log("It's a draw!");
            LoadSpecialMiniGame();
        }

        // Disable all game elements on game over
        karateAnimalGameManager.DisableAllGameElements();
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

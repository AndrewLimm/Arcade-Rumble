using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManagerTextReactionGame : MonoBehaviour
{

    [SerializeField] ReactionTestScoreManager reactionTestScoreManager;
    [SerializeField] TMP_Text resultText;  // Text UI untuk menampilkan hasil

    void Start()
    {
        resultText.gameObject.SetActive(false);  // Sembunyikan teks hasil saat game dimulai
    }

    public void EndGameCondition()
    {
        // Tampilkan hasil berdasarkan skor pemain
        if (reactionTestScoreManager.player1Score > reactionTestScoreManager.player2Score)
        {
            resultText.text = "Player 1 Menang!";
            GameRumbleGameManagerForScore.instance.AddWinPoint(1);
            Invoke("GoToResultScreen", 0.5f); // Menunggu 2 detik sebelum pindah
        }
        else if (reactionTestScoreManager.player1Score < reactionTestScoreManager.player2Score)
        {
            resultText.text = "Player 2 Menang!";
            GameRumbleGameManagerForScore.instance.AddWinPoint(2);
            Invoke("GoToResultScreen", 0.5f); // Menunggu 2 detik sebelum pindah
        }
        else
        {
            resultText.text = "Hasil Seri!";
            LoadSpecialMiniGame();
        }

        // Tampilkan teks hasil
        resultText.gameObject.SetActive(true);
    }
    public void LoadSpecialMiniGame()
    {
        SceneManager.LoadScene("MixMayhem"); // Ganti dengan nama scene mini-game khusus
    }

    private void GoToResultScreen()
    {
        SceneManager.LoadScene("ArcadeRumbleResultScreen"); // Ganti dengan nama scene layar hasil yang sesuai
    }
}

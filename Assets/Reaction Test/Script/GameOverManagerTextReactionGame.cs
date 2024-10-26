using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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
        }
        else if (reactionTestScoreManager.player1Score < reactionTestScoreManager.player2Score)
        {
            resultText.text = "Player 2 Menang!";
        }
        else
        {
            resultText.text = "Hasil Seri!";
        }

        // Tampilkan teks hasil
        resultText.gameObject.SetActive(true);
    }
}

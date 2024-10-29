using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CatchItemScoreUIPlayer1 : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText; // Referensi ke UI Text untuk Player 1

    // Memperbarui UI dengan skor terbaru
    public void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            CatchItemScoreManagerPlayer1 scoreManager = FindObjectOfType<CatchItemScoreManagerPlayer1>();
            int currentScore = scoreManager != null ? scoreManager.GetScore() : 0;
            scoreText.text = "Score: " + currentScore; // Perbarui teks dengan skor
        }
        else
        {
            Debug.LogError("Score Text is missing in the UI.");
        }
    }
}

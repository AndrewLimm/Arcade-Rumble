using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchItemScoreManagerPlayer2 : MonoBehaviour
{
    private int scorePlayer2 = 0;

    // Menambah skor untuk Player 2
    public void AddScore(int value)
    {
        scorePlayer2 += value;
        CatchItemScoreUiPlayer2 scoreUI = FindObjectOfType<CatchItemScoreUiPlayer2>();
        if (scoreUI != null)
        {
            scoreUI.UpdateScoreUI(); // Perbarui UI setelah skor diubah
        }
        else
        {
            Debug.LogError("CatchItemScoreUiPlayer2 is missing or not initialized.");
        }
    }

    // Mengambil skor Player 2
    public int GetScore()
    {
        return scorePlayer2;
    }
}

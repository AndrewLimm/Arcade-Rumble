using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchItemScoreManagerPlayer1 : MonoBehaviour
{
    private int scorePlayer1 = 0;

    // Menambah skor untuk Player 1
    public void AddScore(int value)
    {
        scorePlayer1 += value;
        CatchItemScoreUIPlayer1 scoreUI = FindObjectOfType<CatchItemScoreUIPlayer1>();
        if (scoreUI != null)
        {
            scoreUI.UpdateScoreUI(); // Perbarui UI setelah skor diubah
        }
        else
        {
            Debug.LogError("CatchItemScoreUIPlayer1 is missing or not initialized.");
        }
    }

    // Mengambil skor Player 1
    public int GetScore()
    {
        return scorePlayer1;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTetrisScoreManager : MonoBehaviour
{
    public int currentScorePlayer1 { get; private set; } = 0;
    public int currentScorePlayer2 { get; private set; } = 0;

    // Skor untuk 1, 2, 3, dan 4 garis yang dihancurkan
    private int[] scorePerLine = { 0, 100, 300, 500, 800 };

    // Menambahkan skor untuk Player 1
    public void AddScorePlayer1(int linesCleared)
    {
        if (linesCleared > 0 && linesCleared <= scorePerLine.Length)
        {
            currentScorePlayer1 += scorePerLine[linesCleared];
            Debug.Log($"Player 1 - Garis dihancurkan: {linesCleared}, Skor ditambahkan: {scorePerLine[linesCleared]}");
        }
        else
        {
            Debug.LogWarning("Player 1 - Jumlah garis yang dihancurkan tidak valid.");
        }
    }

    // Menambahkan skor untuk Player 2
    public void AddScorePlayer2(int linesCleared)
    {
        if (linesCleared > 0 && linesCleared <= scorePerLine.Length)
        {
            currentScorePlayer2 += scorePerLine[linesCleared];
            Debug.Log($"Player 2 - Garis dihancurkan: {linesCleared}, Skor ditambahkan: {scorePerLine[linesCleared]}");
        }
        else
        {
            Debug.LogWarning("Player 2 - Jumlah garis yang dihancurkan tidak valid.");
        }
    }

    // Reset skor Player 1 dan Player 2
    public void ResetScores()
    {
        currentScorePlayer1 = 0;
        currentScorePlayer2 = 0;
    }
}

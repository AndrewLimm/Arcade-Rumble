using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CatchItemScoreUIPlayer1 : MonoBehaviour
{
    public static CatchItemScoreUIPlayer1 instance; // Singleton instance

    [SerializeField] private TMP_Text scoreText; // Referensi ke UI Text untuk Player 1

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Memperbarui UI dengan skor terbaru
    public void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            int currentScore = CatchItemScoreManagerPlayer1.instance.GetScore(); // Dapatkan skor saat ini
            scoreText.text = "Score: " + currentScore; // Perbarui teks dengan skor
        }
        else
        {
            Debug.LogError("Score Text is missing in the UI.");
        }
    }
}

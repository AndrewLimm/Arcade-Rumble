using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CatchItemScoreUiPlayer2 : MonoBehaviour
{
    public static CatchItemScoreUiPlayer2 instance; // Singleton instance

    public TMP_Text scoreText; // Referensi ke UI Text untuk Player 2

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
        scoreText.text = "Player 2 Score: " + CatchItemScoreManagerPlayer2.instance.GetScore();
    }
}

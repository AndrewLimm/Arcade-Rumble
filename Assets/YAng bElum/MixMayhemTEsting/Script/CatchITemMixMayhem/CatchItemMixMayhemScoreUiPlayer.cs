using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CatchItemMixMayhemScoreUiPlayer : MonoBehaviour
{
    public static CatchItemMixMayhemScoreUiPlayer instance; // Singleton instance

    public TMP_Text scoreText; // Referensi ke UI Text untuk Player 1

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
        scoreText.text = "Player 1 Score: " + CtachItemMixmayhemScoreManagerplayer1.instance.GetScore();
    }
}

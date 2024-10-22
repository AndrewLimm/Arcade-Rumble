using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuickTapMixMayhemPlayer2ScoreUI : MonoBehaviour
{
    public TMP_Text player2ScoreText;

    public void UpdatePlayer2Score(int score)
    {
        player2ScoreText.text = "Player 2 Score: " + score.ToString();
    }
}

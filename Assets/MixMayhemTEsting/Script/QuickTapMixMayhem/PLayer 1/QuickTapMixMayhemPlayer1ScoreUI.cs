using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuickTapMixMayhemPlayer1ScoreUI : MonoBehaviour
{
    public TMP_Text player1ScoreText;
    public void UpdatePlayer1Score(int score)
    {
        player1ScoreText.text = "Player 1 Score: " + score.ToString();
    }
}

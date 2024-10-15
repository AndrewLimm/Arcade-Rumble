using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuickTapPlayer2Ui : MonoBehaviour
{
    public TMP_Text player2ScoreText;

    public void UpdatePlayer2Score(int score)
    {
        player2ScoreText.text = "Player 2 Score: " + score.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarateAnimalGameOverManager : MonoBehaviour
{
    [SerializeField] private KarateAnimalScoreManager karateAnimalScoreManager;
    [SerializeField] private KarateAnimalPlayer2Score karateAnimalPlayer2Score;
    [SerializeField] private KarateAnimalGameManager karateAnimalGameManager;

    public void EndGameCondition()
    {
        // Determine the winner based on scores
        if (karateAnimalPlayer2Score.score > karateAnimalScoreManager.scoreplayer1)
        {
            Debug.Log("Player 2 wins!");
        }
        else if (karateAnimalPlayer2Score.score < karateAnimalScoreManager.scoreplayer1)
        {
            Debug.Log("Player 1 wins!");
        }
        else
        {
            Debug.Log("It's a draw!");
        }

        // Disable all game elements on game over
        karateAnimalGameManager.DisableAllGameElements();
    }
}

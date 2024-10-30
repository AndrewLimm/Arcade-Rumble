using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickMathGameManager : MonoBehaviour
{
    [SerializeField] MathGameLogic mathGameLogic;
    [SerializeField] QuickMathGameTImer quickMathGameTImer;
    [SerializeField] QuickMathCOuntdown QuickMathCOuntdown;



    public void StartGame()
    {
        // Start the countdown when the button is pressed
        QuickMathCOuntdown.StartCountDownTimer();

        // Subscribe to the countdown finished event

    }

    public void StartGamePlay()
    {
        // After the countdown finishes, enable game logic
        mathGameLogic.MulaiPermainan();
        if (quickMathGameTImer == null)
        {
            quickMathGameTImer = FindObjectOfType<QuickMathGameTImer>();
        }

        if (quickMathGameTImer != null)
        {
            mathGameLogic.MulaiPermainan();
            quickMathGameTImer.StartTimer(); // Start the game timer
        }
        else
        {
            Debug.LogError("QuickMathGameTImer reference is still missing.");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MxiMayhemGameManagerStart : MonoBehaviour
{
    public MixMayhemCountdownTImer countdownTimer; // Referensi ke countdown timer
    public Button StartButton;

    void Start()
    {
        countdownTimer.gameObject.SetActive(false);
    }

    public void StartGame()
    {
        // Mulai countdown
        countdownTimer.gameObject.SetActive(true);
        countdownTimer.StartCountdown(); // Call the countdown coroutine

        // Set the start button to inactive
        StartButton.gameObject.SetActive(false);
    }
}

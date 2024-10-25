using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MemoryMatchGameTImer : MonoBehaviour
{
    public float gameDuration = 60f; // Total duration of the game in seconds
    private float currentTime; // Remaining time for the game
    public TMP_Text timerText; // UI Text to display the timer
    private bool isGameRunning = false; // Flag to check if the game is running

    [SerializeField] MemoryMatchGameOver gameOverManager; // Reference to the Game Over manager

    private void Update()
    {
        if (isGameRunning)
        {
            currentTime -= Time.deltaTime; // Decrease time based on the time passed per frame
            UpdateTimerUI();

            if (currentTime <= 0)
            {
                EndGame(); // Call this function if time runs out
            }
        }
    }

    public void StartGameTimer()
    {
        currentTime = gameDuration; // Set time to game duration
        isGameRunning = true; // Start the game
        UpdateTimerUI();
    }

    public void StopGameTimer()
    {
        isGameRunning = false; // Stop the game timer
    }

    private void UpdateTimerUI()
    {
        timerText.text = "Time Left: " + Mathf.Ceil(currentTime).ToString() + "s"; // Update UI display with remaining time
    }

    private void EndGame()
    {
        isGameRunning = false; // Stop the game
        Debug.Log("Game Over! Time's Up.");

        // Call the method to display the winner
        gameOverManager.EndCondition();
    }
}

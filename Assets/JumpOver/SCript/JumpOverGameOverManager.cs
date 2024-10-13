using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpOverGameOverManager : MonoBehaviour
{
    public TMP_Text gameOverText; // Text component to display Game Over message

    private void Start()
    {
        // Hide the Game Over text at the start of the game
        gameOverText.gameObject.SetActive(false);
    }

    public void TriggerGameOver()
    {
        // Show the Game Over text
        gameOverText.gameObject.SetActive(true);
        gameOverText.text = "Game Over"; // Set the text to "Game Over"
        // Stop all gameplay by pausing the game
        Time.timeScale = 0; // Pause the game
    }
}

using TMPro;
using UnityEngine;
using UnityEngine.UI;

[DefaultExecutionOrder(-1)]
public class FlappyAnimalGameManager : MonoBehaviour
{
    [SerializeField] private Button startButton; // Reference to the Start button
    [SerializeField] FlappyAnimalSpawner flappyAnimalSpawner;
    [SerializeField] FlappyAnimalPlayer1Control flappyAnimalPlayer1Control;
    [SerializeField] FlappyAnimalPlayer2Controller flappyAnimalPlayer2Controller;
    [SerializeField] FlappyAnimalGameOverManager gameOverManager; // Reference to GameOverManager
    [SerializeField] FlappyAnimalCOuntDown flappyAnimalCOuntDown;


    void Start()
    {
        // Set the game objects inactive at the start
        DisableGameComponents();

        // Add listener to the Start button
        startButton.onClick.AddListener(StartCountdown);
    }

    public void StartCountdown()
    {
        flappyAnimalCOuntDown.StartCountdown();

    }

    public void StartGame()
    {
        // Enable the players and spawner
        flappyAnimalPlayer1Control.EnableMovement();
        flappyAnimalPlayer2Controller.EnableMovement();
        flappyAnimalSpawner.EnableSpawning();

        // Reset the game state from the GameOverManager
        gameOverManager.ResetGameState();
    }

    // Disable movement and spawner (for Game Over)
    public void DisableGameComponents()
    {
        flappyAnimalPlayer1Control.DisableMovement();
        flappyAnimalPlayer2Controller.DisableMovement();
        flappyAnimalSpawner.DisableSpawning();
        StopAllSpawnedObjects();
    }

    private void StopAllSpawnedObjects()
    {
        // Temukan semua objek bertipe FlappyAnimalPipes
        FlappyAnimalPipes[] pipes = FindObjectsOfType<FlappyAnimalPipes>();

        // Hentikan gerakan setiap pipa
        foreach (FlappyAnimalPipes pipe in pipes)
        {
            pipe.StopMovement();
        }
    }
}

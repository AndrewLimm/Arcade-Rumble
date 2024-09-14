using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public KeyCode moveKey1;   // Key for moving (e.g., A for Player 1)
    public KeyCode moveKey2;   // Second key for moving (e.g., D for Player 1)
    public float moveSpeed = 2f;   // Fixed movement speed
    public Transform finishLine;   // Finish line position
    private bool hasFinished = false;  // To check if Player 1 has finished
    public GameEnded gameManager;    // Reference to the GameManager script

    private void Update()
    {
        if (hasFinished || gameManager == null)
            return;

        // Move right when either key is pressed
        if (Input.GetKeyDown(moveKey1) || Input.GetKeyDown(moveKey2))
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        }

        // Check if the player has reached the finish line
        if (transform.position.x >= finishLine.position.x)
        {
            hasFinished = true;
            gameManager.EndGame("Player 1");   // Notify GameManager that Player 1 won
        }
    }
}

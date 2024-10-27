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
    public RaceToFInishGameOverManager gameManager;    // Reference to the GameManager script

    public RaceToFinishAnimation animationController;

    public bool canMove = false;

    private void Update()
    {
        if (hasFinished || !canMove || gameManager == null)
            return;

        HandleMovementPlayer();
    }

    public void HandleMovementPlayer()
    {

        // Move right when either key is pressed
        if (Input.GetKeyDown(moveKey1) || Input.GetKeyDown(moveKey2))
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            animationController.PlayMoveAnimation();  // Trigger the move animation
        }
        else
        {
            animationController.PlayIdleAnimation();  // Trigger the idle animation
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("FinishLine")) // Pastikan tag pada garis finish diatur ke "FinishLine"
        {
            if (!hasFinished)
            {
                hasFinished = true;
                animationController.PlayIdleAnimation();  // Ensure the idle animation plays
                gameManager.RaceToFinishGameOver(gameObject.tag);   // Notify GameManager that Player 1 won
            }
        }
    }
}


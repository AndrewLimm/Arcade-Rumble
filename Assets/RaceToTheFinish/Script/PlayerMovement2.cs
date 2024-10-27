using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
    public KeyCode moveKey1;   // Key for moving (e.g., J for Player 2)
    public KeyCode moveKey2;   // Second key for moving (e.g., L for Player 2)
    public float moveSpeed = 2f;   // Fixed movement speed
    public Transform finishLine;   // Finish line position
    private bool hasFinished = false;  // To check if Player 2 has finished
    public RaceToFInishGameOverManager gameManager;    // Reference to the GameManager script

    public bool canMove = false;

    public RaceToFinishAnimation Player2Animation;


    private void Update()
    {
        if (hasFinished || !canMove || gameManager == null)
            return;

        HandleMovementPlayer2();
    }

    public void HandleMovementPlayer2()
    {
        // Move right when either key is pressed
        if (Input.GetKeyDown(moveKey1) || Input.GetKeyDown(moveKey2))
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            Player2Animation.PlayMoveAnimation();  // Trigger the move animation
        }
        else
        {
            Player2Animation.PlayIdleAnimation();  // Trigger the idle animation
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("FinishLine")) // Pastikan tag pada garis finish diatur ke "FinishLine"
        {
            if (!hasFinished)
            {
                hasFinished = true;
                Player2Animation.PlayIdleAnimation();  // Ensure the idle animation plays
                gameManager.RaceToFinishGameOver(gameObject.tag);   // Notify GameManager that Player 1 won
            }
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixMayhemRaceToFinishPlayer2Movement : MonoBehaviour
{
    public KeyCode moveKey1;   // Key for moving (e.g., J for Player 2)
    public KeyCode moveKey2;   // Second key for moving (e.g., L for Player 2)
    public float moveSpeed = 2f;   // Fixed movement speed
    public Transform finishLine;   // Finish line position
    private bool hasFinished = false;  // To check if Player 2 has finished
    public MIxMayhemRaceTofinishGameOverManager gameManager;    // Reference to the GameManager script

    public MixMayhemRaceToFInishANimator Player2Animation;

    [SerializeField] public AudioClip moveSound; // Suara saat bergerak
    public AudioSource audioSource;

    private void Update()
    {
        if (hasFinished || gameManager == null)
            return;

        // Move right when either key is pressed
        if (Input.GetKeyDown(moveKey1) || Input.GetKeyDown(moveKey2))
        {
            PlayMoveSound();
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            Player2Animation.PlayMoveAnimation();  // Trigger the move animation
        }
        else
        {
            Player2Animation.PlayIdleAnimation();  // Trigger the idle animation
        }

        // Check if the player has reached the finish line
        if (transform.position.x >= finishLine.position.x)
        {
            hasFinished = true;
            Player2Animation.PlayIdleAnimation();  // Ensure the idle animation plays
            gameManager.RaceToFinishGameOver("Player 2");   // Notify GameManager that Player 2 won
        }
    }

    private void PlayMoveSound()
    {
        if (moveSound != null)
        {
            audioSource.PlayOneShot(moveSound); // Mainkan suara gerakan
        }
    }
}

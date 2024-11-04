using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayAliveMixMayhemPlayer1Input : MonoBehaviour
{
    public float speed = 5f; // Adjust the movement speed
    private bool isFacingRight = true; // Variable to track which direction the player is facing

    [SerializeField] private AudioClip footstepSound;
    private AudioSource audioSource;
    private bool isPlayingFootstep = false;


    void Start()
    {
        // Initialize AudioSource
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = footstepSound;
        audioSource.loop = true; // Loop the footstep sound
    }

    void Update()
    {
        // Player 1 movement (WASD)
        float horizontal = 0f;
        float vertical = 0f;

        if (Input.GetKey(KeyCode.W)) vertical = 1f;
        if (Input.GetKey(KeyCode.S)) vertical = -1f;
        if (Input.GetKey(KeyCode.A)) horizontal = -1f;
        if (Input.GetKey(KeyCode.D)) horizontal = 1f;

        // Move the player based on input
        Vector3 movement = new Vector3(horizontal, vertical, 0f).normalized;
        transform.position += movement * speed * Time.deltaTime;

        // Play footstep sound if the player is moving
        if (movement.magnitude > 0 && !isPlayingFootstep)
        {
            PlayFootstepSound();
        }
        else if (movement.magnitude == 0 && isPlayingFootstep)
        {
            StopFootstepSound();
        }

        // Flip the character sprite based on movement direction
        FlipCharacter(horizontal);
    }

    private void FlipCharacter(float horizontal)
    {
        // If moving right and not facing right, flip the sprite
        if (horizontal > 0 && !isFacingRight)
        {
            Flip();
        }
        // If moving left and facing right, flip the sprite
        else if (horizontal < 0 && isFacingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        // Flip the character's facing direction
        isFacingRight = !isFacingRight;

        // Invert the X axis scale to flip the sprite
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    private void PlayFootstepSound()
    {
        isPlayingFootstep = true;
        audioSource.Play();
    }

    private void StopFootstepSound()
    {
        isPlayingFootstep = false;
        audioSource.Stop();
    }
}

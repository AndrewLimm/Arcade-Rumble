using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayAlivePlayer2Controller : MonoBehaviour
{
    public float speed = 5f; // Adjust the movement speed
    private bool isFacingRight = true; // Variable to track which direction the player is facing
    private bool canMove = false; // Flag to check if the player can move

    // Audio
    [SerializeField] private AudioClip movementSound; // Suara gerakan
    private AudioSource audioSource;
    private bool isPlayingMovementSound = false; // Cek apakah suara gerakan sedang diputar

    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>(); // Tambahkan AudioSource jika belum ada
        audioSource.clip = movementSound;
        audioSource.loop = true; // Set loop agar suara terus diputar selama bergerak
    }

    void Update()
    {
        if (canMove)
        {
            Move(); // Panggil metode Move jika kontrol diaktifkan
        }
    }

    public void StartMoving()
    {
        canMove = true; // Izinkan pemain untuk bergerak
    }

    private void Move()
    {
        // Player 2 movement (IJKL)
        float horizontal = 0f;
        float vertical = 0f;

        if (Input.GetKey(KeyCode.I)) vertical = 1f;
        if (Input.GetKey(KeyCode.K)) vertical = -1f;
        if (Input.GetKey(KeyCode.J)) horizontal = -1f;
        if (Input.GetKey(KeyCode.L)) horizontal = 1f;

        // Move the player based on input
        Vector3 movement = new Vector3(horizontal, vertical, 0f).normalized;
        transform.position += movement * speed * Time.deltaTime;


        // Start or stop movement sound based on player movement
        if (movement.magnitude > 0 && !isPlayingMovementSound)
        {
            audioSource.Play(); // Mulai suara jika pemain mulai bergerak
            isPlayingMovementSound = true;
        }
        else if (movement.magnitude == 0 && isPlayingMovementSound)
        {
            audioSource.Stop(); // Hentikan suara jika pemain berhenti
            isPlayingMovementSound = false;
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
}

﻿using UnityEngine;

public class FlappyAnimalPlayer1Control : MonoBehaviour
{
    public Sprite[] sprites;
    public float strength = 5f;
    public float gravity = -9.81f;
    public float tilt = 5f;

    private SpriteRenderer spriteRenderer;
    private Vector3 direction;
    private int spriteIndex;

    // Variable to control movement
    private bool canMove = false;

    [SerializeField] public AudioClip jumpSound; // AudioClip for the jump sound
    [SerializeField] public AudioClip collisionSound; // AudioClip for the collision sound
    public AudioSource audioSource; // AudioSource to play sounds

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }

    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }

    private void Update()
    {
        if (canMove) // Check if the player can move
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetMouseButtonDown(0))
            {
                direction = Vector3.up * strength;

                // Play jump sound
                if (jumpSound != null)
                {
                    audioSource.PlayOneShot(jumpSound);
                }
            }

            // Apply gravity and update the position
            direction.y += gravity * Time.deltaTime;
            transform.position += direction * Time.deltaTime;

            // Tilt the bird based on the direction
            Vector3 rotation = transform.eulerAngles;
            rotation.z = direction.y * tilt;
            transform.eulerAngles = rotation;
        }
    }

    private void AnimateSprite()
    {
        spriteIndex++;

        if (spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }

        if (spriteIndex < sprites.Length && spriteIndex >= 0)
        {
            spriteRenderer.sprite = sprites[spriteIndex];
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            // If Player 1 dies, call Player1GameOver in the Game Over script
            FlappyAnimalGameOverManager gameOverManager = FindObjectOfType<FlappyAnimalGameOverManager>();
            gameOverManager.Player1GameOver();

               // Play collision sound
            if (collisionSound != null)
            {
                audioSource.PlayOneShot(collisionSound);
            }
            StopSpriteAnimation();  // Stop the animation
        }
    }

    // Function to enable movement
    public void EnableMovement()
    {
        canMove = true;
    }

    // Function to disable movement
    public void DisableMovement()
    {
        canMove = false;
    }

    private void StopSpriteAnimation()
    {
        CancelInvoke(nameof(AnimateSprite));  // This will stop the InvokeRepeating for sprite animation
    }
}

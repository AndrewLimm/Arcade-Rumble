using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyAnimalPlayer2Controller : MonoBehaviour
{
    public Sprite[] sprites;
    public float strength = 5f;
    public float gravity = -9.81f;
    public float tilt = 5f;

    private SpriteRenderer spriteRenderer;
    private Vector3 direction;
    private int spriteIndex;

    public bool canMove = false;

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
        if (canMove)
        {
            // Check if Player 2 presses the "UpArrow" key or Right Mouse Button to jump
            if (Input.GetKeyDown(KeyCode.I) || Input.GetMouseButtonDown(1))
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
            // Jika Player 2 mati, panggil Player2GameOver di skrip Game Over
            FlappyAnimalGameOverManager gameOverManager = FindObjectOfType<FlappyAnimalGameOverManager>();
            gameOverManager.Player2GameOver();
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

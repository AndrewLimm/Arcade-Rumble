using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoinPlayer1Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private float originalSpeed;
    private float speedBoostTimer = 0f;

    private Rigidbody2D rb;
    private Vector2 movement;

    public SpriteRenderer spriteRenderer;

    [SerializeField] CollecCoinPlayer1Animator collecCoinPlayer1Animator;

    private void Start()
    {
        originalSpeed = moveSpeed;
        rb = GetComponent<Rigidbody2D>();
        collecCoinPlayer1Animator = GetComponent<CollecCoinPlayer1Animator>();
    }

    void Update()
    {
        ProcessInputs();
        HandleSpeedBoost();
    }

    private void FixedUpdate()
    {
        MovePlayer();
        UpdateAnimation();
        FlipSprite();
    }

    void ProcessInputs()
    {
        movement.x = 0;
        movement.y = 0;

        // Kontrol untuk Player 1 (WASD)
        if (Input.GetKey(KeyCode.W)) movement.y = 1;
        else if (Input.GetKey(KeyCode.S)) movement.y = -1;

        if (Input.GetKey(KeyCode.A)) movement.x = -1;
        else if (Input.GetKey(KeyCode.D)) movement.x = 1;

        movement = movement.normalized;
    }

    void MovePlayer()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void HandleSpeedBoost()
    {
        if (speedBoostTimer > 0)
        {
            speedBoostTimer -= Time.deltaTime;
        }
        else
        {
            moveSpeed = originalSpeed;
        }
    }

    // Aktifkan speed boost dari collectible
    public void ActivateSpeedBoost(float multiplier, float duration)
    {
        moveSpeed = originalSpeed * multiplier;
        speedBoostTimer = duration;
    }

    void UpdateAnimation()
    {
        bool isMoving = movement.x != 0 || movement.y != 0;
        collecCoinPlayer1Animator.UpdateAnimationState(isMoving);
    }

    // Flip the sprite based on movement direction
    void FlipSprite()
    {
        if (movement.x > 0)
        {
            spriteRenderer.flipX = false; // Menghadap kanan
        }
        else if (movement.x < 0)
        {
            spriteRenderer.flipX = true; // Menghadap kiri
        }
    }
}

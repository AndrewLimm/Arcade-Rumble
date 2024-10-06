using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoinPlayer2Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private float originalSpeed;
    private float speedBoostTimer = 0f;

    private Rigidbody2D rb;
    private Vector2 movement;

    private void Start()
    {
        originalSpeed = moveSpeed;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        ProcessInputs();
        HandleSpeedBoost();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    void ProcessInputs()
    {
        movement.x = 0;
        movement.y = 0;

        // Kontrol untuk Player 2 (IJKL)
        if (Input.GetKey(KeyCode.I)) movement.y = 1;
        else if (Input.GetKey(KeyCode.K)) movement.y = -1;

        if (Input.GetKey(KeyCode.J)) movement.x = -1;
        else if (Input.GetKey(KeyCode.L)) movement.x = 1;

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
}

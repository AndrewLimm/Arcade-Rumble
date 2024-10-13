using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpOverPlayer2FastFall : MonoBehaviour
{
    public float fastFallSpeed = 20f;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        HandleFastFall();
    }

    private void HandleFastFall()
    {
        if (!IsGrounded() && Input.GetKeyDown(KeyCode.K))
        {
            FastFall();
        }
    }

    private void FastFall()
    {
        rb.velocity = new Vector2(rb.velocity.x, -fastFallSpeed); // Mempercepat kejatuhan pemain
    }

    private bool IsGrounded()
    {
        // Cek apakah player menyentuh tanah
        return rb.velocity.y == 0;
    }
}

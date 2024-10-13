using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpOverPlayer2JUmp : MonoBehaviour
{
    public float jumpForce = 10f;
    private bool canDoubleJump = false;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        HandleJump();
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (IsGrounded())
            {
                Jump();
                canDoubleJump = true; // Mengizinkan double jump setelah lompatan pertama
            }
            else if (canDoubleJump)
            {
                Jump();
                canDoubleJump = false; // Menonaktifkan double jump setelah digunakan
            }
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce); // Beri gaya ke atas pada rigidbody
    }

    private bool IsGrounded()
    {
        // Cek apakah player menyentuh tanah
        return rb.velocity.y == 0;
    }
}

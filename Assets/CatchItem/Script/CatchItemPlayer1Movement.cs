using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchItemPlayer1Movement : MonoBehaviour
{
    public float moveSpeed = 5f; // Kecepatan pergerakan pemain
    private Rigidbody2D rb;
    private float movement;
    public bool isFacingRight = true;
    public SpriteRenderer spriteRenderer;
    public float jumpForce = 7f; // Kekuatan lompatan

    private bool canMove = false;
    private bool isGrounded = false; // Cek apakah pemain di tanah
    private Animator animator; // Referensi Animator

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        animator.enabled = false;
    }

    void Update()
    {
        if (canMove) // Hanya gerak jika canMove true
        {
            movement = 0;

            if (Input.GetKey(KeyCode.A))
            {
                movement = -1;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                movement = 1;
            }

            if (Input.GetKeyDown(KeyCode.W) && isGrounded)
            {
                Jump();
            }

            FlipCharacter();
        }
    }

    void FixedUpdate()
    {
        if (canMove)
        {
            rb.velocity = new Vector2(movement * moveSpeed, rb.velocity.y);
        }
    }

    void FlipCharacter()
    {
        if (movement < 0 && isFacingRight)
        {
            Flip();
        }
        else if (movement > 0 && !isFacingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        spriteRenderer.flipX = !spriteRenderer.flipX;
    }

    public void EnableMovement()
    {
        canMove = true;
        animator.enabled = true;
    }

    public void DisableMovement()
    {
        canMove = false;
        animator.enabled = false;
    }

    public void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        isGrounded = false; // Set isGrounded to false after jumping
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Cek jika player menyentuh tanah
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Reset isGrounded saat player meninggalkan tanah
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}

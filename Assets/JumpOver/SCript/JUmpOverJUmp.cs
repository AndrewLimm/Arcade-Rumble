using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JUmpOverJUmp : MonoBehaviour
{

    public float jumpForce = 10f;
    private bool canDoubleJump = false;
    private Rigidbody2D rb;

    public bool canjump = false;
    [SerializeField] public AudioClip jumpSound; // Suara untuk lompatan
    public AudioSource audioSource;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (canjump)
        {
            HandleJump();
        }
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.W))
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
        PlayJumpSound(); // Mainkan suara lompatan

    }
    public void PlayJumpSound()
    {
        if (jumpSound != null)
        {
            audioSource.PlayOneShot(jumpSound); // Mainkan suara lompatan
        }
    }


    private bool IsGrounded()
    {
        // Cek apakah player menyentuh tanah
        return rb.velocity.y == 0;
    }

    public void player1EnableJump()
    {
        canjump = true; return;
    }

    public void player1disableJump()
    {
        canjump = false; return;
    }
}

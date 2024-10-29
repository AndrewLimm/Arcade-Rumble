using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchItemMIxMayhemPlayer2 : MonoBehaviour
{
    public float moveSpeed = 5f; // Kecepatan pergerakan pemain
    private Rigidbody2D rb;
    private float movement;
    private bool isFacingRight = true;
    public SpriteRenderer spriteRenderer;
    private Animator animator; // Referensi Animator
    public float jumpForce = 7f; // Kekuatan lompatan
    private bool isGrounded = false; // Cek apakah pemain di tanah

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); // Mendapatkan komponen Animator
        animator.enabled = true; // Aktifkan animator saat permainan dimulai
    }

    void Update()
    {
        // Mengambil input horizontal dari pemain 2 (J = -1, L = 1)
        movement = 0;

        if (Input.GetKey(KeyCode.J))
        {
            movement = -1;
        }
        else if (Input.GetKey(KeyCode.L))
        {
            movement = 1;
        }
        if (Input.GetKeyDown(KeyCode.I) && isGrounded)
        {
            Jump();
        }

        FlipCharacter();
    }

    void FixedUpdate()
    {
        // Gerakkan player ke kiri/kanan berdasarkan input
        rb.velocity = new Vector2(movement * moveSpeed, rb.velocity.y);
    }

    // Fungsi untuk membalik arah hadap karakter
    void FlipCharacter()
    {
        // Jika bergerak ke kiri dan sedang menghadap kanan atau sebaliknya, maka balik arah
        if (movement > 0 && isFacingRight)
        {
            Flip();
        }
        else if (movement < 0 && !isFacingRight)
        {
            Flip();
        }
    }

    // Fungsi untuk membalik sprite karakter
    void Flip()
    {
        isFacingRight = !isFacingRight; // Balik arah hadap
        spriteRenderer.flipX = !spriteRenderer.flipX; // Membalikkan sprite secara horizontal
    }

    public void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        isGrounded = false; // Set isGrounded ke false setelah lompat
    }

    // Deteksi jika pemain menyentuh tanah
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    // Reset isGrounded saat meninggalkan tanah
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}

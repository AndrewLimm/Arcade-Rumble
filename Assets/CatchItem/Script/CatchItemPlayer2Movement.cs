using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchItemPlayer2Movement : MonoBehaviour
{
    public float moveSpeed = 5f; // Kecepatan pergerakan pemain
    private Rigidbody2D rb;
    private float movement;
    private bool isFacingRight = true;
    public SpriteRenderer spriteRenderer;

    // Menambahkan variabel untuk kontrol gerakan
    private bool canMove = false;
    private Animator animator; // Referensi Animator

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); // Mendapatkan komponen Animator

        // Nonaktifkan animator saat permainan dimulai
        animator.enabled = false;
    }

    void Update()
    {
        if (canMove) // Hanya gerak jika canMove true
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

            FlipCharacter();
        }
    }

    void FixedUpdate()
    {
        if (canMove) // Hanya gerak jika canMove true
        {
            // Gerakkan player ke kiri/kanan berdasarkan input
            rb.velocity = new Vector2(movement * moveSpeed, rb.velocity.y);
        }
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

    // Fungsi untuk mengaktifkan gerakan
    public void EnableMovement()
    {
        canMove = true;
        animator.enabled = true; // Aktifkan animator saat pemain dapat bergerak
    }

    public void DisableMovement()
    {
        canMove = false;
        animator.enabled = false; // Aktifkan animator saat pemain dapat bergerak
    }
}

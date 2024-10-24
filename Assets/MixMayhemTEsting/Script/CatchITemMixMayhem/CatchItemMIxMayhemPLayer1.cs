using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchItemMIxMayhemPLayer1 : MonoBehaviour
{
    public float moveSpeed = 5f; // Kecepatan pergerakan pemain
    private Rigidbody2D rb;
    private float movement;
    public bool isFacingRight = true;
    public SpriteRenderer spriteRenderer;
    private Animator animator; // Referensi Animator

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); // Mendapatkan komponen Animator
        animator.enabled = true; // Aktifkan animator saat permainan dimulai
    }

    void Update()
    {
        // Mengambil input horizontal dari pemain 1 (A = -1, D = 1)
        movement = 0;

        if (Input.GetKey(KeyCode.A))
        {
            movement = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            movement = 1;
        }

        // Melakukan flip
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
        if (movement < 0 && isFacingRight)
        {
            Flip();
        }
        else if (movement > 0 && !isFacingRight)
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
}

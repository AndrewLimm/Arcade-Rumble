using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpOverFastFall : MonoBehaviour
{
    public float fastFallSpeed = 20f;
    private Rigidbody2D rb;

    public bool canfastfall = false;

    [SerializeField] public AudioClip fastFallSound; // Suara untuk fast fall
    public AudioSource audioSource;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (canfastfall)
        {
            HandleFastFall();
        }

    }

    private void HandleFastFall()
    {
        if (!IsGrounded() && Input.GetKeyDown(KeyCode.S))
        {
            FastFall();
        }
    }

    private void PlayFastFallSound()
    {
        if (fastFallSound != null)
        {
            audioSource.PlayOneShot(fastFallSound); // Mainkan suara fast fall
        }
    }

    private void FastFall()
    {
        rb.velocity = new Vector2(rb.velocity.x, -fastFallSpeed); // Mempercepat kejatuhan pemain
        PlayFastFallSound();
    }

    private bool IsGrounded()
    {
        // Cek apakah player menyentuh tanah
        return rb.velocity.y == 0;
    }

    public void Player1EnableFastfall()
    {
        canfastfall = true; return;
    }

    public void Player1DisableFastfall()
    {
        canfastfall = false; return;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpMeOutPlayer1Controller : MonoBehaviour
{
    public float moveSpeed = 5f; // Kecepatan gerakan pemain
    private Vector2 movement; // Variabel untuk menyimpan arah gerakan

    private bool controlsEnabled = true; // Menyimpan status kontrol pemain

    [SerializeField] HelpMeOutGameOver helpMeOutGameOver;
    private SpriteRenderer spriteRenderer; // Reference to SpriteRenderer for flipping
    private bool isFacingRight = false; // Status menghadap awal



    void Start()
    {
        // Mendapatkan referensi GameOverManager
        // helpMeOutGameOver = FindObjectOfType<HelpMeOutGameOver>();
        if (helpMeOutGameOver == null)
        {
            Debug.LogError("HelpMeOutGameOver tidak ditemukan di scene!");
        }
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    void Update()
    {
        if (controlsEnabled) // Hanya jika kontrol diizinkan
        {
            // Input untuk Player 1 menggunakan tombol WASD
            movement.x = 0;
            movement.y = 0;

            if (Input.GetKey(KeyCode.W))
            {
                movement.y = 1; // Gerak ke atas
            }
            else if (Input.GetKey(KeyCode.S))
            {
                movement.y = -1; // Gerak ke bawah
            }

            if (Input.GetKey(KeyCode.A))
            {
                movement.x = -1; // Gerak ke kiri
                isFacingRight = false; // Update arah

            }
            else if (Input.GetKey(KeyCode.D))
            {
                movement.x = 1; // Gerak ke kanan
                isFacingRight = true; // Update arah

            }


            // Set flipX berdasarkan arah terakhir yang disimpan
            spriteRenderer.flipX = isFacingRight;
        }
    }

    void FixedUpdate()
    {
        // Menggerakkan Player 1 berdasarkan input
        transform.Translate(movement * moveSpeed * Time.fixedDeltaTime);
    }

    public void EnableControls()
    {
        controlsEnabled = true; // Aktifkan kontrol
    }

    // Metode untuk menonaktifkan kontrol
    public void DisableControls()
    {
        controlsEnabled = false; // Nonaktifkan kontrol
    }

    // private void OnTriggerEnter2D(Collider2D collide)
    // {
    //     if (collide.CompareTag("Player1"))
    //     {
    //         Debug.Log($"{collide.gameObject.name} Hit!"); // Menampilkan nama pemain yang tertabrak
    //         helpMeOutGameOver.TriggerEnd();
    //     }
    // }
}

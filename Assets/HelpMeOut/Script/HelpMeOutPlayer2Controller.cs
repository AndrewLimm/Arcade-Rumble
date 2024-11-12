using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpMeOutPlayer2Controller : MonoBehaviour
{
    public float moveSpeed = 5f; // Kecepatan gerakan pemain
    private Vector2 movement; // Variabel untuk menyimpan arah gerakan
    private Rigidbody2D rb; // Komponen Rigidbody2D untuk menggerakkan objek
    private bool controlsEnabled = true; // Menyimpan status kontrol pemain

    [SerializeField] HelpMeOutGameOver helpMeOutGameOver;
    private SpriteRenderer spriteRenderer; // Reference to SpriteRenderer for flipping


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        rb = GetComponent<Rigidbody2D>(); // Mengambil komponen Rigidbody2D dari objek
        // Mendapatkan referensi GameOverManager
        // helpMeOutGameOver = FindObjectOfType<HelpMeOutGameOver>();
        if (helpMeOutGameOver == null)
        {
            Debug.LogError("HelpMeOutGameOver tidak ditemukan di scene!");
        }
    }

    void Update()
    {
        if (controlsEnabled) // Hanya jika kontrol diizinkan
        {
            // Input untuk Player 1 menggunakan tombol WASD
            movement.x = 0;
            movement.y = 0;

            if (Input.GetKey(KeyCode.I))
            {
                movement.y = 1; // Gerak ke atas
            }
            else if (Input.GetKey(KeyCode.K))
            {
                movement.y = -1; // Gerak ke bawah
            }

            if (Input.GetKey(KeyCode.J))
            {
                movement.x = -1; // Gerak ke kiri
            }
            else if (Input.GetKey(KeyCode.L))
            {
                movement.x = 1; // Gerak ke kanan
            }
            if (movement.x != 0)
            {
                spriteRenderer.flipX = movement.x < 0;
            }
        }
    }

    void FixedUpdate()
    {
        // Menggerakkan Player 2 menggunakan Rigidbody2D untuk menjaga konsistensi fisika
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
    // Metode untuk mengaktifkan kontrol
    public void EnableControls()
    {
        controlsEnabled = true; // Aktifkan kontrol
    }

    // Metode untuk menonaktifkan kontrol
    public void DisableControls()
    {
        controlsEnabled = false; // Nonaktifkan kontrol
    }

    // private void OnTriggerEnter2D(Collider2D collider)
    // {
    //     if (collider.CompareTag("Player2"))
    //     {
    //         Debug.Log($"{collider.gameObject.name} Hit!"); // Menampilkan nama pemain yang tertabrak
    //         helpMeOutGameOver.TriggerEnd();
    //     }
    // }
}

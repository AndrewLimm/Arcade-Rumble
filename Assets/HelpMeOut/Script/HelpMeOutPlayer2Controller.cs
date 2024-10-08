using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpMeOutPlayer2Controller : MonoBehaviour
{
    public float moveSpeed = 5f; // Kecepatan gerakan pemain
    private Vector2 movement; // Variabel untuk menyimpan arah gerakan
    private Rigidbody2D rb; // Komponen Rigidbody2D untuk menggerakkan objek

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Mengambil komponen Rigidbody2D dari objek
    }

    void Update()
    {
        // Input untuk Player 2 menggunakan tombol IJKL
        movement = Vector2.zero; // Mengatur ulang nilai movement

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
    }

    void FixedUpdate()
    {
        // Menggerakkan Player 2 menggunakan Rigidbody2D untuk menjaga konsistensi fisika
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}

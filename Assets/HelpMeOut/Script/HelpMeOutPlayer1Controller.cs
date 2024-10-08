using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpMeOutPlayer1Controller : MonoBehaviour
{
  public float moveSpeed = 5f; // Kecepatan gerakan pemain
    private Vector2 movement; // Variabel untuk menyimpan arah gerakan

    void Update()
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
        }
        else if (Input.GetKey(KeyCode.D))
        {
            movement.x = 1; // Gerak ke kanan
        }
    }

    void FixedUpdate()
    {
        // Menggerakkan Player 1 berdasarkan input
        transform.Translate(movement * moveSpeed * Time.fixedDeltaTime);
    }
}

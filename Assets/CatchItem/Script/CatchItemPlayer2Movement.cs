using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchItemPlayer2Movement : MonoBehaviour
{
    public float moveSpeed = 5f; // Kecepatan pergerakan pemain

    private Rigidbody2D rb;
    private float movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
    }

    void FixedUpdate()
    {
        // Gerakkan player ke kiri/kanan berdasarkan input
        rb.velocity = new Vector2(movement * moveSpeed, rb.velocity.y);
    }
}

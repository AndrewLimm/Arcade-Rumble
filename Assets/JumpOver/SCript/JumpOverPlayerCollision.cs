using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpOverPlayerCollision : MonoBehaviour
{
    private JUmpOverGameManager gameManager;
    public string playerName; // Nama pemain (misalnya "Player 1" atau "Player 2")

    private void Start()
    {
        gameManager = FindObjectOfType<JUmpOverGameManager>(); // Mencari GameManager di scene
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Obstacle")) // Cek apakah tabrakan dengan objek yang memiliki tag "Obstacle"
        {
            if (collision.gameObject.CompareTag("Obstacle")) // Cek apakah tabrakan dengan objek yang memiliki tag "Obstacle"
            {
                // Cek tag pemain yang terkena obstacle
                if (CompareTag("Player1")) // Jika ini adalah Player 1
                {
                    gameManager.EndGame("Player 2 Wins!"); // Player 2 yang menang
                }
                else if (CompareTag("Player2")) // Jika ini adalah Player 2
                {
                    gameManager.EndGame("Player 1 Wins!"); // Player 1 yang menang
                }
            }
        }
    }
}

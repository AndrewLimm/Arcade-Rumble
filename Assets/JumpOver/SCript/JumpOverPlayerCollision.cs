using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpOverPlayerCollision : MonoBehaviour
{
    private JumpOverGameOverManager gameOverManager;

    private void Start()
    {
        gameOverManager = FindObjectOfType<JumpOverGameOverManager>(); // Mencari GameOverManager di scene
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle")) // Cek apakah tabrakan dengan objek yang memiliki tag "Obstacle"
        {
            gameOverManager.TriggerGameOver(); // Panggil fungsi Game Over
        }
    }
}

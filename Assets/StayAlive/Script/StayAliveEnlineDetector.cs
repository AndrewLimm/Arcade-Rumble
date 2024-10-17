using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayAliveEnlineDetector : MonoBehaviour
{
    [SerializeField] private StayAliveGameOverManager gameOverManager; // Referensi ke GameOverManager

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Periksa apakah collider yang bersentuhan memiliki tag "Player1" atau "Player2"
        if (collision.CompareTag("Player1") || collision.CompareTag("Player2"))
        {
            // Panggil fungsi untuk trigger game over
            gameOverManager.TriggerEnd();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpMeOutFinishiTrigger : MonoBehaviour
{
    [SerializeField] private HelpMeOutGameOver gameOverManager;
    [SerializeField] private HelpMeOutGameManager gameManager; // Referensi ke GameManager

    private void Start()
    {
        // Mendapatkan referensi GameOverManager
        gameOverManager = GetComponent<HelpMeOutGameOver>();
        if (gameOverManager == null)
        {
            Debug.LogError("HelpMeOutGameOver tidak ditemukan di scene!");
        }

        // Mendapatkan referensi GameManager
        gameManager = FindObjectOfType<HelpMeOutGameManager>();
        if (gameManager == null)
        {
            Debug.LogError("HelpMeOutGameManager tidak ditemukan di scene!");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player1") || other.CompareTag("Player2"))
        {
            Debug.Log($"{other.gameObject.name} Hit!"); // Menampilkan nama pemain yang tertabrak

            // Memanggil TriggerEnd dengan nama pemenang
            string winner = other.CompareTag("Player1") ? "Player 1" : "Player 2";
            gameOverManager.TriggerEnd(winner); // Memanggil fungsi game over dengan nama pemenang

            // Memanggil EndGame dari GameManager untuk menghentikan permainan
            gameManager.EndGame();
        }
        else
        {
            Debug.Log($"{other.gameObject.name} tidak dikenali sebagai pemain.");
        }
    }
}

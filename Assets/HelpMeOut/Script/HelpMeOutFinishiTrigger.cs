using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpMeOutFinishiTrigger : MonoBehaviour
{
    [SerializeField] private HelpMeOutGameOver gameOverManager;

    private void Start()
    {
        // Mendapatkan referensi GameOverManager
        gameOverManager = GetComponent<HelpMeOutGameOver>();
        if (gameOverManager == null)
        {
            Debug.LogError("HelpMeOutGameOver tidak ditemukan di scene!");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Memeriksa apakah yang ditabrak adalah Player1 atau Player2
        if (other.CompareTag("Player1") || other.CompareTag("Player2"))
        {
            Debug.Log($"{other.gameObject.name} Hit!"); // Menampilkan nama pemain yang tertabrak
            gameOverManager.TriggerEnd(); // Memanggil fungsi game over
        }
        else
        {
            Debug.Log($"{other.gameObject.name} tidak dikenali sebagai pemain.");
        }
    }
}

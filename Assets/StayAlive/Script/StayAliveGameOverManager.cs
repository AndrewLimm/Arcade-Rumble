using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayAliveGameOverManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverUI; // Referensi ke panel Game Over UI

    void Start()
    {
        // Pastikan Game Over UI tersembunyi saat permainan dimulai
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(false);
        }
    }

    // Metode untuk memicu kondisi game over
    public void TriggerEnd()
    {
        // Tampilkan Game Over UI
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true);
        }

        // Logika tambahan untuk game over, seperti menghentikan pergerakan pemain atau permainan
        Debug.Log("Game Over! Pemain telah mencapai garis akhir.");

        // Hentikan permainan dengan menghentikan waktu (opsional)
        Time.timeScale = 0f; // Menghentikan permainan
    }
}

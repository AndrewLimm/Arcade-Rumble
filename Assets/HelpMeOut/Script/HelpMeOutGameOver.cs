using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HelpMeOutGameOver : MonoBehaviour
{
    [SerializeField] private GameObject gameOverUI; // Referensi ke panel Game Over UI
    [SerializeField] private HelpMeOUtPlayerTimeController helpMeOUtPlayerTimeController;
    void Start()
    {
        // Pastikan Game Over UI tersembunyi saat permainan dimulai
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(false);
            Debug.Log("Game Over UI disembunyikan saat permainan dimulai.");
        }
        else
        {
            Debug.LogWarning("Game Over UI tidak terhubung!");
        }
        
    }

    // Metode untuk memicu kondisi game over
    public void TriggerEnd()
    {
        // Tampilkan Game Over UI
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true);
            Debug.Log("Game Over UI ditampilkan.");
        }

        // Logika tambahan untuk game over, seperti menghentikan pergerakan pemain atau permainan
        Debug.Log("Game Over! Pemain telah mencapai garis akhir.");

        // Hentikan permainan dengan menghentikan waktu (opsional)
        Time.timeScale = 0f; // Menghentikan permainan
        helpMeOUtPlayerTimeController.StopAllTimers();
        Debug.Log("Permainan dihentikan.");
    }
}

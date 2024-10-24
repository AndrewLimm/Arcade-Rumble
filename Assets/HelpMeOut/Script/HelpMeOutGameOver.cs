using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HelpMeOutGameOver : MonoBehaviour
{
    [SerializeField] private HelpMeOUtPlayerTimeController helpMeOUtPlayerTimeController;
    [SerializeField] private TextMeshProUGUI winMessageText; // Referensi untuk TextMeshPro


    void Start()
    {
        // Menyembunyikan pesan kemenangan saat permainan dimulai
        if (winMessageText != null)
        {
            winMessageText.gameObject.SetActive(false); // Menyembunyikan teks kemenangan
            Debug.Log("Pesan kemenangan disembunyikan saat permainan dimulai.");
        }
        else
        {
            Debug.LogWarning("winMessageText tidak terhubung!");
        }
    }

    // Metode untuk memicu kondisi game over
    public void TriggerEnd(string winner)
    {
        // Menampilkan pesan pemenang
        if (winMessageText != null)
        {
            winMessageText.text = $"{winner} Win!"; // Tampilkan nama pemenang
            winMessageText.gameObject.SetActive(true); // Menampilkan teks kemenangan
        }
        else
        {
            Debug.LogWarning("winMessageText tidak terhubung!");
        }

        // Logika tambahan untuk game over, seperti menghentikan pergerakan pemain atau permainan
        Debug.Log("Game Over! Pemain telah mencapai garis akhir.");

        // Hentikan permainan dengan menghentikan waktu (opsional)
        Time.timeScale = 0f; // Menghentikan permainan
        helpMeOUtPlayerTimeController.StopAllTimers();
        Debug.Log("Permainan dihentikan.");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayAliveMixMayhemGameOverManager : MonoBehaviour
{
    public void TriggerEnd()
    {
        // Logika tambahan untuk game over, seperti menghentikan pergerakan pemain atau permainan
        Debug.Log("Game Over! Pemain telah mencapai garis akhir.");

        // Hentikan permainan dengan menghentikan waktu (opsional)
        Time.timeScale = 0f; // Menghentikan permainan
    }
}

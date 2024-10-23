using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MixmAyhemGameOverManager : MonoBehaviour
{
    [SerializeField] MixMayhemPlayerLifeManager mixMayhemPlayerlifeManager;
    public void EndGameMixMayhem()
    {
        // Memeriksa jumlah nyawa pemain
        if (mixMayhemPlayerlifeManager.player1Lives < mixMayhemPlayerlifeManager.player2Lives)
        {
            // Pemain 2 menang
            Debug.Log("Pemain 2 menang!");
            // Panggil fungsi untuk menampilkan hasil atau melakukan tindakan akhir
            EndGame();
        }
        else if (mixMayhemPlayerlifeManager.player1Lives > mixMayhemPlayerlifeManager.player2Lives)
        {
            // Pemain 1 menang
            Debug.Log("Pemain 1 menang!");
            // Panggil fungsi untuk menampilkan hasil atau melakukan tindakan akhir
            EndGame();
        }
    }
    public void EndGame()
    {
        // Hentikan semua aktivitas game
        Time.timeScale = 0; // Menghentikan semua waktu dalam permainan

        // Logika untuk mengakhiri permainan, seperti menampilkan menu akhir atau kembali ke menu utama
        // Contoh:
        // ShowEndGameMenu();
        Debug.Log("Permainan berakhir. Tampilkan menu akhir.");
    }
}


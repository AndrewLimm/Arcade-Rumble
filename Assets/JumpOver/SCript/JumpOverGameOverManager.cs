using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpOverGameOverManager : MonoBehaviour
{
    public TMP_Text winnerText; // Komponen Teks untuk menampilkan pemenang

    private void Start()
    {
        // Menyembunyikan teks pemenang saat permainan dimulai
        winnerText.gameObject.SetActive(false);
    }

    public void TriggerGameOver(string winner)
    {
        // Menampilkan pemenang
        winnerText.gameObject.SetActive(true);
        winnerText.text = winner; // Menampilkan siapa pemenangnya

        // Hentikan semua gameplay dengan menghentikan game
        Time.timeScale = 0; // Pause permainan
    }
}

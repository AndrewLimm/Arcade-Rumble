using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RaceToFInishGameOverManager : MonoBehaviour
{
    [SerializeField] private Transform finishLine;  // Referensi ke garis finish
    [SerializeField] private TMP_Text winnerText;  // Teks untuk menampilkan pemenang
    private bool gameEnded = false; // Menyimpan status apakah permainan telah berakhir

    private void Start()
    {
        winnerText.gameObject.SetActive(false);
    }


    public void RaceToFinishGameOver(string playerTag)
    {
        if (gameEnded) return; // Mencegah pemanggilan berulang jika permainan sudah selesai
        gameEnded = true;  // Menandakan bahwa permainan telah selesai
        Debug.Log("Race Finished by: " + playerTag); // Debug log untuk melacak pemenang

        // Cek pemain mana yang mencapai garis finish
        if (playerTag == "Player1")
        {
            winnerText.text = "Player 1 Wins!"; // Menampilkan teks "Player 1 Wins!"
            GameRumbleGameManagerForScore.instance.AddWinPoint(1);
            Invoke("GoToResultScreen", 0.5f); // Menunggu 2 detik sebelum pindah
        }
        else if (playerTag == "Player2")
        {
            winnerText.text = "Player 2 Wins!"; // Menampilkan teks "Player 2 Wins!"
            GameRumbleGameManagerForScore.instance.AddWinPoint(2);
            Invoke("GoToResultScreen", 0.5f); // Menunggu 2 detik sebelum pindah
        }

        // Aktifkan teks pemenang agar terlihat
        winnerText.gameObject.SetActive(true);
    }
    public void LoadSpecialMiniGame()
    {
        SceneManager.LoadScene("MixMayhem"); // Ganti dengan nama scene mini-game khusus
    }
    private void GoToResultScreen()
    {
        SceneManager.LoadScene("ArcadeRumbleResultScreen"); // Ganti dengan nama scene layar hasil yang sesuai
    }
}

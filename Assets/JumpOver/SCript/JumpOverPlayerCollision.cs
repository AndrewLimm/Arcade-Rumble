using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpOverPlayerCollision : MonoBehaviour
{
    private JUmpOverGameManager gameManager;
    public string playerName; // Nama pemain (misalnya "Player 1" atau "Player 2")

    private void Start()
    {
        gameManager = FindObjectOfType<JUmpOverGameManager>(); // Mencari GameManager di scene
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle")) // Cek apakah tabrakan dengan objek yang memiliki tag "Obstacle"
        {
            bool isPlayer1 = CompareTag("Player1"); // Apakah ini Player 1
            bool isPlayer2 = CompareTag("Player2"); // Apakah ini Player 2

            // Cek kondisi ketika kedua pemain mati bersamaan
            if (isPlayer1 && GameObject.FindGameObjectWithTag("Player2").GetComponent<JumpOverPlayerCollision>().IsDead())
            {
                // Kedua pemain mati bersamaan
                LoadSpecialMiniGame(); // Panggil mini-game khusus
            }
            else if (isPlayer1) // Jika ini adalah Player 1
            {
                gameManager.EndGame("Player 2 Wins!"); // Player 2 yang menang
                GameRumbleGameManagerForScore.instance.AddWinPoint(2); // Tambahkan poin untuk Player 2
                Invoke("GoToResultScreen", 0.1f); // Menunggu 0.5 detik sebelum pindah
            }
            else if (isPlayer2) // Jika ini adalah Player 2
            {
                gameManager.EndGame("Player 1 Wins!"); // Player 1 yang menang
                GameRumbleGameManagerForScore.instance.AddWinPoint(1); // Tambahkan poin untuk Player 1
                Invoke("GoToResultScreen", 0.1f); // Menunggu 0.5 detik sebelum pindah
            }
        }
    }
    public void LoadSpecialMiniGame()
    {
        SceneManager.LoadScene("RaceToTheFinish"); // Ganti dengan nama scene mini-game khusus
    }

    private void GoToResultScreen()
    {
        SceneManager.LoadScene("ArcadeRumbleResultScreen"); // Ganti dengan nama scene layar hasil yang sesuai
    }

    public bool IsDead()
    {
        // Ganti dengan logika untuk menentukan apakah pemain ini mati
        // Misalnya, jika ada variabel yang menyimpan status pemain
        return false; // Kembalikan true jika pemain mati
    }
}

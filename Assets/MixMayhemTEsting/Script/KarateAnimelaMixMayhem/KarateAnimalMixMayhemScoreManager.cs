using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KarateAnimalMixMayhemScoreManager : MonoBehaviour
{
    public int scorePlayer1 = 0; // Skor untuk Player 1
    public TMP_Text scoreText; // Referensi ke TextMeshPro untuk menampilkan skor

    void Start()
    {
        // Update skor pertama kali saat game mulai
        UpdateScoreUI();
    }

    // Fungsi untuk menambahkan skor
    public void AddScorePlayer1(int amount)
    {
        scorePlayer1 += amount;
        Debug.Log("Player 1 Score: " + scorePlayer1);
        UpdateScoreUI(); // Update tampilan skor
    }

    // Fungsi untuk memperbarui teks skor di UI
    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Player 2 Score: " + scorePlayer1.ToString();
        }
    }
}

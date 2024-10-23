using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KarateAnimalMixMayhemScoreManagerPlayer2 : MonoBehaviour
{
    public int scorePlayer2 = 0; // Skor untuk Player 2
    public TMP_Text scoreText; // Referensi ke TextMeshPro untuk menampilkan skor

    void Start()
    {
        // Update skor pertama kali saat game mulai
        UpdateScoreUI();
    }

    // Fungsi untuk menambahkan skor
    public void AddScorePlayer2(int amount)
    {
        scorePlayer2 += amount;
        Debug.Log("Player 2 Score: " + scorePlayer2);
        UpdateScoreUI(); // Update tampilan skor
    }

    // Fungsi untuk memperbarui teks skor di UI
    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Player 2 Score: " + scorePlayer2.ToString();
        }
    }
}

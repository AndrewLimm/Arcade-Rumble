using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KarateAnimalScoreManager : MonoBehaviour
{
    public int scoreplayer1 = 0; // Skor untuk Player 1
    public TMP_Text scoreText; // Referensi ke TextMeshPro untuk menampilkan skor

    void Start()
    {
        // Update skor pertama kali saat game mulai
        UpdateScoreUI();
    }

    // Fungsi untuk menambahkan skor
    public void AddScore(int amount)
    {
        scoreplayer1 += amount;
        Debug.Log("Player 1 Score: " + scoreplayer1);
        UpdateScoreUI(); // Update tampilan skor
    }

    // Fungsi untuk memperbarui teks skor di UI
    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Player 1 Score: " + scoreplayer1.ToString();
        }
    }
}

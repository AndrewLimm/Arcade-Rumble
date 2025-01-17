using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuickMathMixMayhemScoreManager : MonoBehaviour
{
    public int skorPemain1 { get; private set; }  // Skor untuk pemain 1
    public int skorPemain2 { get; private set; }  // Skor untuk pemain 2
    public int poinBenar = 1;                     // Poin yang didapat jika menjawab benar, bisa diatur di editor

    public TMP_Text scorePlayer1Text;
    public TMP_Text scorePlayer2Text;

    // Menambahkan poin ke pemain 1
    public void TambahSkorPemain1(int poin)
    {
        skorPemain1 += poin;
        Debug.Log("Skor Pemain 1: " + skorPemain1);
        UpdateUISkor(); // Perbarui UI skor jika ada
    }

    // Menambahkan poin ke pemain 2
    public void TambahSkorPemain2(int poin)
    {
        skorPemain2 += poin;
        Debug.Log("Skor Pemain 2: " + skorPemain2);
        UpdateUISkor(); // Perbarui UI skor jika ada
    }

    // Memperbarui UI skor jika ada
    private void UpdateUISkor()
    {
        // Tambahkan logika di sini jika Anda memiliki UI untuk menampilkan skor
        if (scorePlayer1Text != null)
        {
            scorePlayer1Text.text = "Skor Pemain 1: " + skorPemain1;  // Perbarui skor pemain 1 di UI
        }

        if (scorePlayer2Text != null)
        {
            scorePlayer2Text.text = "Skor Pemain 2: " + skorPemain2;  // Perbarui skor pemain 2 di UI
        }
    }

    // Reset skor jika permainan di-reset atau dimulai ulang
    public void ResetSkor()
    {
        skorPemain1 = 0;
        skorPemain2 = 0;
        UpdateUISkor();
    }
}

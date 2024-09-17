using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickMathScoreManager : MonoBehaviour
{
    private int skorPemain1 = 0; // Skor untuk pemain 1
    private int skorPemain2 = 0; // Skor untuk pemain 2

    // Event untuk ketika skor berubah
    public delegate void SkorDiupdate(int skorPemain1, int skorPemain2);
    public event SkorDiupdate OnSkorDiupdate;

    // Menambah skor untuk pemain 1
    public void TambahSkorPemain1()
    {
        skorPemain1++;
        SkorDiupdateCallback(); // Memanggil event ketika skor berubah
    }

    // Menambah skor untuk pemain 2
    public void TambahSkorPemain2()
    {
        skorPemain2++;
        SkorDiupdateCallback(); // Memanggil event ketika skor berubah
    }

    // Memanggil event untuk memperbarui skor di UI
    private void SkorDiupdateCallback()
    {
        if (OnSkorDiupdate != null)
        {
            OnSkorDiupdate(skorPemain1, skorPemain2); // Panggil event untuk UI atau logic
        }
    }

    // Mengambil skor pemain 1
    public int GetSkorPemain1()
    {
        return skorPemain1;
    }

    // Mengambil skor pemain 2
    public int GetSkorPemain2()
    {
        return skorPemain2;
    }
}

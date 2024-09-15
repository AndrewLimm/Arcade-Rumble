using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathGameLogic : MonoBehaviour
{
    private int skorPemain1 = 0;
    private int skorPemain2 = 0;

    private int posisiJawabanBenar;

    public delegate void SoalDibuat(string soal, string[] pilihan);
    public event SoalDibuat OnSoalDibuat;

    public delegate void SkorDiperbarui(int skor1, int skor2);
    public event SkorDiperbarui OnSkorDiperbarui;

    public void MulaiPermainan()
    {
        GenerateQuestion();
    }

    public void GenerateQuestion()
    {
        int angka1 = Random.Range(1, 10);
        int angka2 = Random.Range(1, 10);
        int operasi = Random.Range(0, 4); // 0 = penjumlahan, 1 = pengurangan, 2 = perkalian, 3 = pembagian

        string soal = "";
        int jawabanBenar = 0;

        switch (operasi)
        {
            case 0:
                soal = angka1 + " + " + angka2;
                jawabanBenar = angka1 + angka2;
                break;
            case 1:
                soal = angka1 + " - " + angka2;
                jawabanBenar = angka1 - angka2;
                break;
            case 2:
                soal = angka1 + " * " + angka2;
                jawabanBenar = angka1 * angka2;
                break;
            case 3:
                soal = angka1 + " / " + angka2;
                jawabanBenar = angka1 / angka2;
                break;
        }

        posisiJawabanBenar = Random.Range(0, 3);
        string[] pilihanJawaban = new string[3];
        pilihanJawaban[posisiJawabanBenar] = jawabanBenar.ToString();

        for (int i = 0; i < pilihanJawaban.Length; i++)
        {
            if (i != posisiJawabanBenar)
            {
                int jawabanSalah = Random.Range(1, 100);
                while (jawabanSalah == jawabanBenar)
                {
                    jawabanSalah = Random.Range(1, 100);
                }
                pilihanJawaban[i] = jawabanSalah.ToString();
            }
        }

        OnSoalDibuat?.Invoke(soal, pilihanJawaban);
    }

    public void PeriksaJawaban(int posisiDipilih, int pemain)
    {
        if (posisiDipilih == posisiJawabanBenar)
        {
            if (pemain == 1)
            {
                skorPemain1++;
            }
            else if (pemain == 2)
            {
                skorPemain2++;
            }

            OnSkorDiperbarui?.Invoke(skorPemain1, skorPemain2);
            GenerateQuestion();
        }
    }
}

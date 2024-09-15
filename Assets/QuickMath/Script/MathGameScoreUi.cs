using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MathGameScoreUi : MonoBehaviour
{
    public TextMeshProUGUI soalText;
    public TextMeshProUGUI[] jawabanTexts; // Array untuk tiga pilihan jawaban
    public TMP_Text skorPemain1Teks;
    public TMP_Text skorPemain2Teks;

    private MathGameLogic gameLogic;

    void Start()
    {
        gameLogic = FindObjectOfType<MathGameLogic>();
        gameLogic.OnSoalDibuat += UpdateSoal;
        gameLogic.OnSkorDiperbarui += UpdateSkor;
        gameLogic.MulaiPermainan();
    }

    void UpdateSoal(string soal, string[] pilihanJawaban)
    {
        soalText.text = soal;
        for (int i = 0; i < jawabanTexts.Length; i++)
        {
            jawabanTexts[i].text = pilihanJawaban[i];
        }
    }

    void UpdateSkor(int skorPemain1, int skorPemain2)
    {
        skorPemain1Teks.text = "Player 1: " + skorPemain1;
        skorPemain2Teks.text = "Player 2: " + skorPemain2;
    }
}

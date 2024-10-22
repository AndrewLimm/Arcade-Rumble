using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickMatchMixMayhemPlayer1Input : MonoBehaviour
{
    public QuickMathMIxmayhemLogic mathGameLogic; // Referensi ke MathGameLogic untuk memeriksa jawaban

    void Update()
    {
        // Input untuk Player 1
        if (Input.GetKeyDown(KeyCode.A)) CekJawaban(0);
        if (Input.GetKeyDown(KeyCode.S)) CekJawaban(1);
        if (Input.GetKeyDown(KeyCode.D)) CekJawaban(2);
    }

    void CekJawaban(int pilihanDipilih)
    {
        if (mathGameLogic != null)
        {
            Debug.Log($"Player 1 memilih jawaban {pilihanDipilih}.");
            mathGameLogic.CekJawaban(pilihanDipilih, 1); // 1 menunjukkan Player 1
        }
        else
        {
            Debug.LogError("MathGameLogic belum disambungkan ke QuickMathPlayer1Input.");
        }
    }
}

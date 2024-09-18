using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickMathPlayer2Input : MonoBehaviour
{
    public MathGameLogic mathGameLogic; // Referensi ke MathGameLogic untuk memeriksa jawaban

    void Update()
    {
        // Input untuk Player 2
        if (Input.GetKeyDown(KeyCode.J)) CekJawaban(0);
        if (Input.GetKeyDown(KeyCode.K)) CekJawaban(1);
        if (Input.GetKeyDown(KeyCode.L)) CekJawaban(2);
    }

    void CekJawaban(int pilihanDipilih)
    {
        if (mathGameLogic != null)
        {
            Debug.Log($"Player 2 memilih jawaban {pilihanDipilih}.");
            mathGameLogic.CekJawaban(pilihanDipilih, 2); // 2 menunjukkan Player 2
        }
        else
        {
            Debug.LogError("MathGameLogic belum disambungkan ke QuickMathPlayer2Input.");
        }
    }
}

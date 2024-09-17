using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickMathPlayerInput : MonoBehaviour
{
    public MathGameLogic mathGameLogic; // Referensi ke MathGameLogic untuk memeriksa jawaban

    void Update()
    {
        // Input untuk Player 1
        if (Input.GetKeyDown(KeyCode.A)) CekJawaban(0, 1);
        if (Input.GetKeyDown(KeyCode.S)) CekJawaban(1, 1);
        if (Input.GetKeyDown(KeyCode.D)) CekJawaban(2, 1);

        // Input untuk Player 2
        if (Input.GetKeyDown(KeyCode.J)) CekJawaban(0, 2);
        if (Input.GetKeyDown(KeyCode.K)) CekJawaban(1, 2);
        if (Input.GetKeyDown(KeyCode.L)) CekJawaban(2, 2);
    }

    void CekJawaban(int pilihanDipilih, int pemain)
    {
        if (mathGameLogic != null)
        {
            mathGameLogic.CekJawaban(pilihanDipilih, pemain);
        }
        else
        {
            Debug.LogError("MathGameLogic belum disambungkan ke QuickMathPlayerInput.");
        }
    }

}

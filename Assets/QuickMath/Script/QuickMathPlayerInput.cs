using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickMathPlayerInput : MonoBehaviour
{
    private MathGameLogic gameLogic;

    void Start()
    {
        // Mencari komponen MathGameLogic di seluruh scene
        gameLogic = FindObjectOfType<MathGameLogic>();
        if (gameLogic == null)
        {
            Debug.LogError("MathGameLogic tidak ditemukan di scene.");
        }
    }

    void Update()
    {
        // Input untuk Player 1
        if (Input.GetKeyDown(KeyCode.A)) gameLogic.PeriksaJawaban(0, 1);
        if (Input.GetKeyDown(KeyCode.S)) gameLogic.PeriksaJawaban(1, 1);
        if (Input.GetKeyDown(KeyCode.D)) gameLogic.PeriksaJawaban(2, 1);

        // Input untuk Player 2
        if (Input.GetKeyDown(KeyCode.J)) gameLogic.PeriksaJawaban(0, 2);
        if (Input.GetKeyDown(KeyCode.K)) gameLogic.PeriksaJawaban(1, 2);
        if (Input.GetKeyDown(KeyCode.L)) gameLogic.PeriksaJawaban(2, 2);
    }
}

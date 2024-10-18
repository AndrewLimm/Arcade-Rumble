using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryMatchPlayer1Input : MonoBehaviour
{
    private AnswerImage _answerImage;

    void Start()
    {
        _answerImage = FindObjectOfType<AnswerImage>();
    }

    // Fungsi untuk memeriksa input dari Player 1
    public void PeriksaInputPlayer1()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            _answerImage.PilihJawabanPlayer1(0); // Pilihan kiri
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            _answerImage.PilihJawabanPlayer1(1); // Pilihan tengah
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            _answerImage.PilihJawabanPlayer1(2); // Pilihan kanan
        }
    }
}

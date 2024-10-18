using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryMatchPlayer2Input : MonoBehaviour
{
    private AnswerImage _answerImage;

    void Start()
    {
        _answerImage = FindObjectOfType<AnswerImage>();
    }

    // Fungsi untuk memeriksa input dari Player 2
    public void PeriksaInputPlayer2()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            _answerImage.PilihJawabanPlayer2(0); // Pilihan kiri
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            _answerImage.PilihJawabanPlayer2(1); // Pilihan tengah
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            _answerImage.PilihJawabanPlayer2(2); // Pilihan kanan
        }
    }
}

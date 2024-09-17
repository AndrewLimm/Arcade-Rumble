using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickMathRandomRequestor : MonoBehaviour
{
    public RandomPool randomPool;  // Referensi ke RandomPool

    // Meminta soal dari RandomPool tanpa menggunakan index
    public Soal RequestSoal()
    {
        if (randomPool != null)
        {
            Soal soal = randomPool.AmbilSoalRandom();
            if (soal != null)
            {
                Debug.Log("Soal yang diminta: " + soal.pertanyaan);
            }
            else
            {
                Debug.LogWarning("Soal yang diminta adalah null.");
            }
            return soal;
        }
        else
        {
            Debug.LogError("RandomPool belum disambungkan ke RandomRequestor.");
            return null;
        }
    }
}

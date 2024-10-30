using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickMathRandomRequestor : MonoBehaviour
{
    public RandomPool randomPool;  // Referensi ke RandomPool

    // Meminta soal dari RandomPool tanpa menggunakan index
    private void Awake()
    {
        // Automatically find and assign RandomPool in the scene
        randomPool = FindObjectOfType<RandomPool>();
        if (randomPool == null)
        {
            Debug.LogError("RandomPool tidak ditemukan di scene. Pastikan RandomPool ada di scene dan aktif.");
        }
    }

    public Soal RequestSoal()
    {
        if (randomPool == null)
        {
            Debug.LogError("RandomPool belum disambungkan ke RandomRequestor.");
            return null;
        }

        Soal soal = randomPool.AmbilSoalRandom();
        if (soal != null)
        {
            Debug.Log("Soal yang diminta: " + soal.pertanyaan);
        }
        else
        {
            Debug.LogError("Tidak ada soal yang tersedia di RandomPool.");
        }
        return soal;
    }
}

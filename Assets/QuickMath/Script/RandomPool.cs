using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Soal
{
    public string pertanyaan;           // Text yang akan ditampilkan sebagai pertanyaan
    public string jawabanBenar;         // Jawaban benar dalam bentuk teks
    public List<string> jawabanSalah;   // Pilihan jawaban lainnya (salah) dalam bentuk teks
}

public class RandomPool : MonoBehaviour
{
    public List<Soal> soalList = new List<Soal>();  // List berisi soal-soal yang dimasukkan via Inspector

    // Mengambil soal secara acak dari pool
    public Soal AmbilSoalRandom()
    {
        if (soalList.Count == 0)
        {
            Debug.LogWarning("Tidak ada soal di dalam pool.");
            return null;
        }

        Soal soal = soalList[Random.Range(0, soalList.Count)];

        // Debugging tambahan untuk memastikan soal valid
        if (soal == null)
        {
            Debug.LogError("Soal yang diambil adalah null.");
            return null;
        }

        if (string.IsNullOrEmpty(soal.pertanyaan))
        {
            Debug.LogError("Soal memiliki pertanyaan yang kosong atau null.");
            return null;
        }

        if (string.IsNullOrEmpty(soal.jawabanBenar))
        {
            Debug.LogError("Soal memiliki jawaban benar yang kosong atau null.");
            return null;
        }

        if (soal.jawabanSalah == null || soal.jawabanSalah.Count == 0)
        {
            Debug.LogError("Soal memiliki daftar jawaban salah yang null atau kosong.");
            return null;
        }

        // Debug untuk memastikan daftar jawaban salah tidak mengandung nilai null atau kosong
        foreach (string jawaban in soal.jawabanSalah)
        {
            if (string.IsNullOrEmpty(jawaban))
            {
                Debug.LogError("Daftar jawaban salah mengandung nilai kosong atau null.");
                return null;
            }
        }

        Debug.Log("Soal yang diambil: " + soal.pertanyaan);
        return soal; // Ambil soal secara acak
    }
}

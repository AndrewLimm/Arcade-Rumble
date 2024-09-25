using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Soal
{
    public Sprite pertanyaan;           // Gambar yang akan ditampilkan sebagai pertanyaan
    public Sprite jawabanBenar;         // Gambar jawaban benar
    public List<Sprite> jawabanSalah;        // Pilihan gambar lainnya (selain yang benar)

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

        if (soal.pertanyaan == null)
        {
            Debug.LogError("Soal memiliki gambar pertanyaan yang null.");
            return null;
        }

        if (soal.jawabanBenar == null)
        {
            Debug.LogError("Soal memiliki gambar jawaban benar yang null.");
            return null;
        }

        if (soal.jawabanSalah == null || soal.jawabanSalah.Count == 0)
        {
            Debug.LogError("Soal memiliki daftar jawaban salah yang null atau kosong.");
            return null;
        }

        // Debug untuk memastikan daftar jawaban salah tidak mengandung nilai null
        foreach (Sprite jawaban in soal.jawabanSalah)
        {
            if (jawaban == null)
            {
                Debug.LogError("Daftar jawaban salah mengandung nilai null.");
                return null;
            }
        }

        Debug.Log("Soal yang diambil: " + soal.pertanyaan.name);
        return soal; // Ambil soal secara acak
    }
}

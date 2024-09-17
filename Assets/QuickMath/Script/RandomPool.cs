using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Soal
{
    public Sprite pertanyaan;           // Gambar yang akan ditampilkan sebagai pertanyaan
    public Sprite jawabanBenar;         // Gambar jawaban benar
    public List<Sprite> jawaban;        // Pilihan gambar lainnya (selain yang benar)

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
        Debug.Log("Soal yang diambil: " + soal.pertanyaan);
        return soal; // Ambil soal secara acak
    }
}

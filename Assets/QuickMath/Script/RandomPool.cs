using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Soal
{
    public string pertanyaan;           // Text yang akan ditampilkan sebagai pertanyaan
    public string jawabanBenar;         // Jawaban benar dalam bentuk teks
    public List<string> jawabanSalah;   // Pilihan jawaban lainnya (salah) dalam bentuk teks

    // Konstruktor untuk kelas Soal
    public Soal(string pertanyaan, string jawabanBenar, List<string> jawabanSalah)
    {
        this.pertanyaan = pertanyaan;
        this.jawabanBenar = jawabanBenar;
        this.jawabanSalah = jawabanSalah;
    }

}

public class RandomPool : MonoBehaviour
{
    public List<Soal> soalList = new List<Soal>();  // List berisi soal-soal yang dimasukkan via Inspector
    private void Start()
    {
        if (soalList.Count == 0)
        {
            // Tambahkan soal contoh
            soalList.Add(new Soal("Contoh Pertanyaan 1", "Jawaban 1", new List<string> { "Jawaban 2", "Jawaban 3" }));
            soalList.Add(new Soal("Contoh Pertanyaan 2", "Jawaban 1", new List<string> { "Jawaban 2", "Jawaban 3" }));
            // Tambahkan lebih banyak soal jika perlu
        }
    }


    // Mengambil soal secara acak dari pool
    public Soal AmbilSoalRandom()
    {
        if (soalList.Count > 0)
        {
            int index = Random.Range(0, soalList.Count);
            Soal soalTerpilih = soalList[index];
            Debug.Log("Soal yang diambil: " + soalTerpilih.pertanyaan); // Menampilkan soal yang terpilih
            return soalTerpilih;
        }
        else
        {
            Debug.LogError("Tidak ada soal yang tersedia di RandomPool.");
            return null;
        }
    }
}
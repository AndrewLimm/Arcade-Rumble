using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MathGameLogic : MonoBehaviour
{
    public QuickMathRandomRequestor randomRequestor;  // Referensi ke RandomRequestor untuk mengambil soal
    public Image soalImage;                           // Referensi ke Image untuk menampilkan gambar soal
    public Image[] pilihanJawabanImages;              // Referensi ke Image untuk menampilkan pilihan jawaban

    private Soal soalAktif;                         // Soal yang sedang aktif

    // Memulai permainan dengan meminta soal baru

    void Start()
    {
        MulaiPermainan();                            // Mulai permainan saat script mulai
    }

    public void MulaiPermainan()
    {
        if (randomRequestor != null)
        {
            RequestSoalBaru();                       // Meminta soal baru dari RandomPool
        }
        else
        {
            Debug.LogError("RandomRequestor belum disambungkan ke MathGameLogic.");
        }
    }

    // Meminta soal baru dan menyimpannya di soalAktif
    public void RequestSoalBaru()
    {
        soalAktif = randomRequestor.RequestSoal();  // Dapatkan soal dari RandomPool
        UpdateUI();  // Perbarui UI dengan soal dan pilihan jawaban baru
    }

    // Memperbarui UI dengan soal dan pilihan jawaban
    private void UpdateUI()
    {
        if (soalAktif != null)
        {
            soalImage.sprite = soalAktif.pertanyaan;  // Tampilkan gambar soal

            // Mengacak pilihan jawaban
            List<Sprite> jawaban = new List<Sprite>(soalAktif.jawaban);
            jawaban.Add(soalAktif.jawabanBenar);
            jawaban.Shuffle(); // Jika Anda memiliki metode Shuffle

            for (int i = 0; i < pilihanJawabanImages.Length; i++)
            {
                if (i < jawaban.Count)
                {
                    pilihanJawabanImages[i].sprite = jawaban[i];
                    pilihanJawabanImages[i].gameObject.SetActive(true); // Tampilkan gambar
                }
                else
                {
                    pilihanJawabanImages[i].gameObject.SetActive(false); // Sembunyikan jika tidak ada cukup jawaban
                }
            }
        }
    }

    // Memeriksa apakah jawaban yang dipilih benar
    public void CekJawaban(int pilihanDipilih, int pemain)
    {
        if (soalAktif != null)
        {
            // Periksa apakah jawaban yang dipilih benar
            Sprite jawabanDipilih = pilihanJawabanImages[pilihanDipilih].sprite;
            bool benar = jawabanDipilih == soalAktif.jawabanBenar;
            if (benar)
            {
                Debug.Log("Player " + pemain + " memilih jawaban yang benar!");
                // Lanjutkan logika untuk mereset soal atau lanjutkan game
            }
            else
            {
                Debug.Log("Player " + pemain + " memilih jawaban yang salah.");
            }
        }
        else
        {
            Debug.LogError("SoalAktif null.");
        }
    }
}

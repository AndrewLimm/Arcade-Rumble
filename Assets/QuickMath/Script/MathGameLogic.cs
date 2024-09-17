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

    [SerializeField] QuickMathScoreManager scoreManager;

    // Memulai permainan dengan meminta soal baru
    void Start()
    {
        MulaiPermainan();                            // Mulai permainan saat script mulai
    }

    public void MulaiPermainan()
    {
        if (randomRequestor != null)
        {
            scoreManager.ResetSkor();                 // Reset skor
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
        if (soalAktif == null)
        {
            Debug.LogError("SoalAktif null. Tidak ada soal yang tersedia.");
            return;
        }
        UpdateUI();  // Perbarui UI dengan soal dan pilihan jawaban baru
    }

    // Memperbarui UI dengan soal dan pilihan jawaban
    private void UpdateUI()
    {
        if (soalAktif != null)
        {
            soalImage.sprite = soalAktif.pertanyaan;  // Tampilkan gambar soal

            // Mengambil semua jawaban yang tersedia termasuk jawaban yang benar
            List<Sprite> jawaban = new List<Sprite>();

            // Tambahkan jawaban yang salah terlebih dahulu, cek agar tidak ada yang sama dengan jawaban benar
            foreach (var jawabanSalah in soalAktif.jawaban)
            {
                if (jawabanSalah != soalAktif.jawabanBenar) // Pastikan tidak sama dengan jawaban benar
                {
                    jawaban.Add(jawabanSalah);
                }
            }

            // Tambahkan jawaban yang benar
            jawaban.Add(soalAktif.jawabanBenar);

            // Mengacak daftar jawaban
            jawaban.Shuffle(); // Jika Anda memiliki metode Shuffle

            // Menampilkan jawaban di UI
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
                if (pemain == 1)
                {
                    scoreManager.TambahSkorPemain1(scoreManager.poinBenar); // Tambah poin untuk pemain 1
                    Debug.Log("Player 1 memilih jawaban yang benar!");
                }
                else if (pemain == 2)
                {
                    scoreManager.TambahSkorPemain2(scoreManager.poinBenar); // Tambah poin untuk pemain 2
                    Debug.Log("Player 2 memilih jawaban yang benar!");
                }
            }
            else
            {
                if (pemain == 1)
                {
                    scoreManager.KurangiSkorPemain1(scoreManager.poinBenar); // Kurangi poin untuk pemain 1
                    Debug.Log("Player 1 memilih jawaban yang salah.");
                }
                else if (pemain == 2)
                {
                    scoreManager.KurangiSkorPemain2(scoreManager.poinBenar); // Kurangi poin untuk pemain 2
                    Debug.Log("Player 2 memilih jawaban yang salah.");
                }
            }

            // Meminta soal baru tanpa menunggu
            RequestSoalBaru();
        }
        else
        {
            Debug.LogError("SoalAktif null.");
        }
    }
}

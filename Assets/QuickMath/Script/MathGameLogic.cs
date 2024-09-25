using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MathGameLogic : MonoBehaviour
{
    public QuickMathRandomRequestor randomRequestor;
    public Image soalImage;
    public Image[] pilihanJawabanImages; // Asumsikan Anda memiliki dua gambar pilihan
    private Soal soalAktif;
    public float jedaSebelumSoalBaru = 1f;

    [SerializeField] QuickMathScoreManager scoreManager;

    private bool isAnswered = false; // Variabel untuk mencegah input ganda
    private bool gameEnded = false;  // Variabel untuk menghentikan input setelah permainan berakhir

    void OnEnable()
    {
        QuickMathGameTImer.OnTimeUp += AkhiriPermainan;
    }

    void OnDisable()
    {
        QuickMathGameTImer.OnTimeUp -= AkhiriPermainan;
    }

    void Start()
    {
        MulaiPermainan();
    }

    public void MulaiPermainan()
    {
        scoreManager.ResetSkor();
        RequestSoalBaru();
        QuickMathGameTImer timer = FindObjectOfType<QuickMathGameTImer>();
        timer.StartTimer();  // Mulai timer saat permainan dimulai
        gameEnded = false;   // Reset status permainan
    }

    public void RequestSoalBaru()
    {
        if (gameEnded) return;  // Jika permainan berakhir, hentikan permintaan soal baru

        soalAktif = randomRequestor.RequestSoal();
        if (soalAktif == null)
        {
            Debug.LogError("Tidak ada soal yang tersedia.");
            return;
        }

        UpdateUI();
        isAnswered = false;  // Reset status jawaban setiap soal baru dimulai
    }

    private void UpdateUI()
    {
        soalImage.sprite = soalAktif.pertanyaan;

        // Buat list yang akan diacak, termasuk jawaban benar dan jawaban salah
        List<Sprite> pilihanJawaban = new List<Sprite> { soalAktif.jawabanBenar };
        pilihanJawaban.AddRange(soalAktif.jawabanSalah);

        // Acak daftar jawaban
        pilihanJawaban.Shuffle(); // Memanggil metode ekstensi Shuffle

        // Menampilkan jawaban pada UI
        for (int i = 0; i < pilihanJawabanImages.Length; i++)
        {
            if (i < pilihanJawaban.Count)
            {
                pilihanJawabanImages[i].sprite = pilihanJawaban[i];
                pilihanJawabanImages[i].gameObject.SetActive(true);
            }
            else
            {
                pilihanJawabanImages[i].gameObject.SetActive(false);
            }
        }
    }

    // Menangani input pemain, hanya satu pemain bisa menjawab setiap soal
    public void CekJawaban(int pilihanDipilih, int pemain)
    {
        if (gameEnded) return;  // Jika permainan berakhir, hentikan input
        if (isAnswered) return; // Cek apakah sudah ada pemain yang menjawab

        if (soalAktif != null)
        {
            Sprite jawabanDipilih = pilihanJawabanImages[pilihanDipilih].sprite;
            bool benar = jawabanDipilih == soalAktif.jawabanBenar;

            if (benar)
            {
                isAnswered = true;  // Tandai soal sebagai sudah dijawab

                // Pemain yang menjawab lebih dulu mendapatkan poin
                if (pemain == 1)
                {
                    scoreManager.TambahSkorPemain1(scoreManager.poinBenar);
                    Debug.Log("Player 1 mendapat poin!");
                }
                else if (pemain == 2)
                {
                    scoreManager.TambahSkorPemain2(scoreManager.poinBenar);
                    Debug.Log("Player 2 mendapat poin!");
                }

                StartCoroutine(JedaSebelumSoalBaru());
            }
        }
    }

    private IEnumerator JedaSebelumSoalBaru()
    {
        yield return new WaitForSeconds(jedaSebelumSoalBaru);
        if (!gameEnded)
        {
            RequestSoalBaru();  // Minta soal baru jika permainan belum berakhir
        }
    }

    // Fungsi untuk mengakhiri permainan ketika waktu habis
    private void AkhiriPermainan()
    {
        Debug.Log("Waktu habis! Permainan selesai.");
        gameEnded = true;  // Permainan berakhir, hentikan semua input
        // Anda bisa menambahkan logika tambahan seperti menampilkan UI hasil akhir di sini.
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerImage : MonoBehaviour
{
    [SerializeField] private ImageDisplay _imageDisplay;
    [SerializeField] private MemoryMatchPlayer1Input player1Input;
    [SerializeField] private MemoryMatchPlayer2Input player2Input;
    [SerializeField] private MemoryMatchINputIndicator inputIndicator; // Referensi ke MemoryMatchInputIndicator

    public List<SpriteRenderer> answerRenderers = new List<SpriteRenderer>();
    public List<Sprite> answerSprites = new List<Sprite>();
    public List<string> correctAnswerOrder = new List<string>();

    private bool gameStarted = false;
    private List<string> player1Answers = new List<string>();
    private List<string> player2Answers = new List<string>();

    private bool player1InputAllowed = true;
    private bool player2InputAllowed = true;

    void Start()
    {
        StartCoroutine(TungguTampilanSoal());
    }

    IEnumerator TungguTampilanSoal()
    {
        while (true) // Tambahkan loop agar permainan terus berulang
        {
            while (!_imageDisplay.IsGameStarted())
            {
                yield return null;
            }

            List<int> shuffledIndices = _imageDisplay.GetShuffledIndices();
            correctAnswerOrder.Clear();

            foreach (var index in shuffledIndices)
            {
                correctAnswerOrder.Add(_imageDisplay.sprites[index].name);
            }

            TampilkanJawaban();
            gameStarted = true;

            // Mulai memeriksa input pemain setelah soal ditampilkan
            yield return StartCoroutine(PeriksaInput());

            yield return new WaitForSeconds(1f); // Tunggu sebentar sebelum memulai soal baru
        }
    }

    void TampilkanJawaban()
    {
        for (int i = 0; i < answerRenderers.Count; i++)
        {
            if (i < answerSprites.Count)
            {
                answerRenderers[i].sprite = answerSprites[i];
            }
            Debug.Log($"AnswerRenderer {i} diatur ke {answerSprites[i].name}");
        }
    }

    // Coroutine untuk memeriksa input pemain
    private IEnumerator PeriksaInput()
    {
        player1Answers.Clear();
        player2Answers.Clear();
        bool correctAnswerGiven = false;

        TampilkanPaketSoal(); // Menampilkan soal baru

        while (!correctAnswerGiven)
        {
            player1Input.PeriksaInputPlayer1();
            player2Input.PeriksaInputPlayer2();
            yield return null; // Tunggu frame berikutnya

            // Cek apakah Player 1 sudah menginputkan jawaban sebanyak jumlah yang dibutuhkan
            if (player1Answers.Count == correctAnswerOrder.Count)
            {
                if (CekJawaban(1))
                {
                    Debug.Log("Player 1 berhasil menjawab dengan benar!");
                    correctAnswerGiven = true; // Jawaban benar, keluar dari loop
                }
                else
                {
                    Debug.Log("Jawaban Player 1 salah. Silakan coba lagi.");
                    player1Answers.Clear(); // Reset jawaban Player 1 jika salah, memungkinkan input lagi
                }
            }

            // Cek apakah Player 2 sudah menginputkan jawaban sebanyak jumlah yang dibutuhkan
            if (player2Answers.Count == correctAnswerOrder.Count)
            {
                if (CekJawaban(2))
                {
                    Debug.Log("Player 2 berhasil menjawab dengan benar!");
                    correctAnswerGiven = true; // Jawaban benar, keluar dari loop
                }
                else
                {
                    Debug.Log("Jawaban Player 2 salah. Silakan coba lagi.");
                    player2Answers.Clear(); // Reset jawaban Player 2 jika salah, memungkinkan input lagi
                }
            }
        }

        yield return new WaitForSeconds(1f); // Tunggu sebentar sebelum memulai soal baru
        StartCoroutine(PeriksaInput()); // Mulai paket soal baru setelah soal lama terselesaikan
    }


    private void TampilkanPaketSoal()
    {
        // Logika untuk menampilkan soal dan jawaban baru
        Debug.Log("Menampilkan paket soal baru...");
        // Pastikan untuk memanggil fungsi yang menampilkan soal baru di sini
    }

    public void PilihJawabanPlayer1(int indeksJawaban)
    {

        if (!gameStarted || !player1InputAllowed || player1Answers.Count >= correctAnswerOrder.Count) return;

        player1Answers.Add(answerSprites[indeksJawaban].name);
        inputIndicator.IndicateInput(player1Answers.Count - 1); // Menyala lampu untuk jawaban Player 1

        Debug.Log("Player 1 memilih: " + answerSprites[indeksJawaban].name);
        StartCoroutine(DebouncePlayer1Input());
    }

    public void PilihJawabanPlayer2(int indeksJawaban)
    {
        if (!gameStarted || !player2InputAllowed || player2Answers.Count >= correctAnswerOrder.Count) return;

        player2Answers.Add(answerSprites[indeksJawaban].name);
        inputIndicator.IndicateInput(player2Answers.Count - 1); // Menyala lampu untuk jawaban Player 2

        Debug.Log("Player 2 memilih: " + answerSprites[indeksJawaban].name);
        StartCoroutine(DebouncePlayer2Input());

    }

    private bool CekJawaban(int pemain)
    {
        List<string> jawabanPemain = (pemain == 1) ? player1Answers : player2Answers;
        bool benar = true;

        Debug.Log("Jawaban Benar: " + string.Join(", ", correctAnswerOrder));
        Debug.Log("Jawaban Player " + pemain + ": " + string.Join(", ", jawabanPemain));

        for (int i = 0; i < correctAnswerOrder.Count; i++)
        {
            if (jawabanPemain[i] != correctAnswerOrder[i])
            {
                benar = false;
                break;
            }
        }

        if (benar)
        {
            Debug.Log("Player " + pemain + " benar!");
            _imageDisplay.CheckAnswer(true); // Memanggil fungsi CheckAnswer di sini
        }
        else
        {
            Debug.Log("Player " + pemain + " salah!");
        }

        return benar; // Kembalikan nilai apakah jawabannya benar atau tidak
    }
    private IEnumerator DebouncePlayer1Input()
    {
        player1InputAllowed = false;
        yield return new WaitForSeconds(0.2f); // Jeda 0.2 detik untuk mencegah input ganda
        player1InputAllowed = true;
    }

    private IEnumerator DebouncePlayer2Input()
    {
        player2InputAllowed = false;
        yield return new WaitForSeconds(0.2f); // Jeda 0.2 detik untuk mencegah input ganda
        player2InputAllowed = true;
    }
}

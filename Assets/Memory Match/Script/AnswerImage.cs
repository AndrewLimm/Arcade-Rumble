using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerImage : MonoBehaviour
{
    [SerializeField] ImageDisplay _imageDisplay;
    public List<SpriteRenderer> answerRenderers = new List<SpriteRenderer>(); // List untuk gambar jawaban
    public List<Sprite> answerSprites = new List<Sprite>(); // Sprite untuk pilihan jawaban yang bisa dipilih pemain
    public List<string> correctAnswerOrder = new List<string>(); // Urutan jawaban yang benar

    private bool gameStarted = false; // Cek apakah permainan sudah dimulai
    private List<string> player1Answers = new List<string>(); // Urutan jawaban dari Player 1
    private List<string> player2Answers = new List<string>(); // Urutan jawaban dari Player 2

    void Start()
    {
        StartCoroutine(WaitForQuestionDisplay()); // Menampilkan soal di awal permainan
    }

    // Coroutine untuk menunggu sampai soal selesai ditampilkan
    IEnumerator WaitForQuestionDisplay()
    {
        // Tunggu sampai soal selesai ditampilkan
        while (!_imageDisplay.IsGameStarted())
        {
            yield return null;
        }

        // Ambil urutan soal yang sudah diacak dari _ImageDisplay
        List<int> shuffledIndices = _imageDisplay.GetShuffledIndices();
        correctAnswerOrder.Clear();

        // Simpan urutan soal yang benar berdasarkan urutan yang diacak
        foreach (var index in shuffledIndices)
        {
            correctAnswerOrder.Add(_imageDisplay.sprites[index].name);
        }

        // Tampilkan pilihan jawaban secara acak
        DisplayAnswers();
        gameStarted = true; // Permainan dimulai
    }

    // Menampilkan gambar jawaban yang bisa dipilih pemain
    void DisplayAnswers()
    {
        for (int i = 0; i < answerRenderers.Count; i++)
        {
            if (i < answerSprites.Count)
            {
                answerRenderers[i].sprite = answerSprites[i]; // Tampilkan sprite jawaban sesuai urutan di answerSprites
            }
            Debug.Log($"AnswerRenderer {i} diatur ke {answerSprites[i].name}");
        }
    }

    void Update()
    {
        if (!gameStarted)
            return;

        // Player 1 input
        if (Input.GetKeyDown(KeyCode.A)) SelectAnswer(1, 0); // Kiri
        if (Input.GetKeyDown(KeyCode.S)) SelectAnswer(1, 1); // Tengah
        if (Input.GetKeyDown(KeyCode.D)) SelectAnswer(1, 2); // Kanan

        // Player 2 input
        if (Input.GetKeyDown(KeyCode.J)) SelectAnswer(2, 0); // Kiri
        if (Input.GetKeyDown(KeyCode.K)) SelectAnswer(2, 1); // Tengah
        if (Input.GetKeyDown(KeyCode.L)) SelectAnswer(2, 2); // Kanan
    }

    // Fungsi untuk menangani pilihan jawaban pemain
    void SelectAnswer(int player, int answerIndex)
    {
        if (player == 1)
        {
            player1Answers.Add(answerSprites[answerIndex].name); // Simpan jawaban Player 1
            Debug.Log("Player 1 memilih: " + answerSprites[answerIndex].name);

            if (player1Answers.Count == correctAnswerOrder.Count)
            {
                CheckAnswers(1); // Cek jawaban Player 1 jika sudah memilih semua
            }
        }
        else if (player == 2)
        {
            player2Answers.Add(answerSprites[answerIndex].name); // Simpan jawaban Player 2
            Debug.Log("Player 2 memilih: " + answerSprites[answerIndex].name);

            if (player2Answers.Count == correctAnswerOrder.Count)
            {
                CheckAnswers(2); // Cek jawaban Player 2 jika sudah memilih semua
            }
        }
    }

    // Fungsi untuk mengecek apakah jawaban pemain sesuai dengan urutan yang benar
    void CheckAnswers(int player)
    {
        List<string> playerAnswers = (player == 1) ? player1Answers : player2Answers;
        bool isCorrect = true;

        for (int i = 0; i < correctAnswerOrder.Count; i++)
        {
            if (playerAnswers[i] != correctAnswerOrder[i])
            {
                isCorrect = false;
                break;
            }
        }

        if (isCorrect)
        {
            Debug.Log("Player " + player + " benar!");
            // Tambahkan logika untuk jawaban yang benar
        }
        else
        {
            Debug.Log("Player " + player + " salah!");
            // Tambahkan logika untuk jawaban yang salah
        }

        // Reset jawaban pemain setelah pengecekan
        if (player == 1)
        {
            player1Answers.Clear();
        }
        else
        {
            player2Answers.Clear();
        }
    }

    void Shuffle(List<Sprite> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int randomIndex = Random.Range(0, list.Count);
            Sprite temp = list[i];
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }
}

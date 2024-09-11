using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerImage : MonoBehaviour
{
    public List<SpriteRenderer> answerRenderers = new List<SpriteRenderer>(); // List untuk gambar jawaban
    public List<Sprite> answerSprites = new List<Sprite>(); // Sprite untuk jawaban
    public string correctAnswer; // Jawaban benar yang perlu diurutkan

    private bool gameStarted = false; // Cek apakah permainan sudah dimulai
    private string player1Answer = ""; // Jawaban dari Player 1
    private string player2Answer = ""; // Jawaban dari Player 2

    void Start()
    {
        DisplayAnswers(); // Tampilkan jawaban ketika permainan dimulai
    }

    // Menampilkan gambar jawaban di layar (kiri, tengah, kanan)
    void DisplayAnswers()
    {
        for (int i = 0; i < answerRenderers.Count; i++)
        {
            if (i < answerSprites.Count)
            {
                answerRenderers[i].sprite = answerSprites[i]; // Tampilkan sprite di layar
            }
        }
        gameStarted = true; // Menandakan bahwa game dimulai dan pemain bisa menjawab
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
            player1Answer = answerSprites[answerIndex].name; // Set jawaban Player 1
            Debug.Log("Player 1 memilih: " + player1Answer);
        }
        else if (player == 2)
        {
            player2Answer = answerSprites[answerIndex].name; // Set jawaban Player 2
            Debug.Log("Player 2 memilih: " + player2Answer);
        }

        // Anda bisa menambahkan logika tambahan untuk mengecek jawaban yang benar di sini
    }
}

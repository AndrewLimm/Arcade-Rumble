using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CatchItemGameManager : MonoBehaviour
{
    public Button startButton; // Referensi ke tombol yang memulai game
    public GameObject[] bots; // Array untuk menyimpan referensi bot yang ada di scene
    public CatchItemCOuntDownDUration countdown; // Referensi ke script countdown
    public CatchItemPlayer1Movement player1Movement; // Referensi ke script player 1
    public CatchItemPlayer2Movement player2Movement; // Referensi ke script player 2
    [SerializeField] private CatchItemTImer timer; // Referensi ke Timer

    private bool gameStarted = false; // Status permainan

    public CatchItemScoreUIPlayer1 player1ScoreUI; // Referensi ke skrip UI Player 1
    public CatchItemScoreUiPlayer2 player2ScoreUI; // Referensi ke skrip UI Player 2

    private CatchItemScoreManagerPlayer1 scoreManagerPlayer1; // Referensi untuk mengakses skor Player 1
    private CatchItemScoreManagerPlayer2 scoreManagerPlayer2; // Referensi untuk mengakses skor Player 2

    private void Awake()
    {
        scoreManagerPlayer1 = FindObjectOfType<CatchItemScoreManagerPlayer1>();
        scoreManagerPlayer2 = FindObjectOfType<CatchItemScoreManagerPlayer2>();

        if (scoreManagerPlayer1 == null || scoreManagerPlayer2 == null)
        {
            Debug.LogError("Score Manager for one or both players is missing in the scene.");
        }
    }
    void Start()
    {
        // Menambahkan listener untuk tombol start
        startButton.onClick.AddListener(StartGame);

        // Sembunyikan semua bot di awal permainan
        SetBotsActive(false);
    }

    public void StartGame()
    {
        // Tampilkan semua bot ketika permainan dimulai
        SetBotsActive(true);

        // Menonaktifkan kemampuan menembak bot
        foreach (GameObject bot in bots)
        {
            CatchItemBotThrower botThrower = bot.GetComponent<CatchItemBotThrower>();
            if (botThrower != null)
            {
                botThrower.StopThrowing(); // Menonaktifkan kemampuan menembak
            }
        }

        // Mulai countdown
        countdown.StartCountdown();
        // Mengaktifkan gerakan pemain setelah countdown selesai
        StartCoroutine(WaitForCountdown());

    }

    private IEnumerator WaitForCountdown()
    {
        yield return new WaitForSeconds(countdown.countdownDuration); // Tunggu sampai countdown selesai
        timer.StartCoroutine("StartTimer"); // Memulai timer setelah permainan dimulai

        // Aktifkan gerakan pemain
        player1Movement.EnableMovement();
        player2Movement.EnableMovement();

        // Tandai bahwa permainan telah dimulai
        gameStarted = true;

        // Mengizinkan bot untuk bergerak dan mulai menembak setelah permainan dimulai
        foreach (GameObject bot in bots)
        {
            CatchItemBotMovement botMovement = bot.GetComponent<CatchItemBotMovement>();
            if (botMovement != null)
            {
                botMovement.StartMoving(); // Mengaktifkan gerakan bot
            }

            CatchItemBotThrower botThrower = bot.GetComponent<CatchItemBotThrower>();
            if (botThrower != null)
            {
                botThrower.StartThrowing(); // Mengizinkan bot untuk menembak setelah countdown
            }
        }
    }

    private void SetBotsActive(bool isActive)
    {
        foreach (GameObject bot in bots)
        {
            bot.SetActive(isActive); // Mengatur status aktif bot
        }
    }

    public bool IsGameStarted() // Method untuk mendapatkan status permainan
    {
        return gameStarted;
    }

    public void DisableAllGameObjects() // Metode untuk menghentikan semua objek di permainan
    {
        // Menonaktifkan gerakan pemain
        player1Movement.DisableMovement();
        player2Movement.DisableMovement();

        // Menonaktifkan semua bot
        foreach (GameObject bot in bots)
        {
            bot.SetActive(false); // Menonaktifkan bot
        }

        // Jika ada objek lain yang perlu dinonaktifkan, tambahkan logika di sini
        // Contoh: jika ada objek item yang bisa ditangkap, nonaktifkan juga
    }
    public void Player1Scores()
    {
        if (scoreManagerPlayer1 != null)
        {
            scoreManagerPlayer1.AddScore(1); // Menambahkan skor ke Player 1
            player1ScoreUI.UpdateScoreUI(); // Memperbarui UI untuk Player 1
        }
    }

    public void Player2Scores()
    {
        if (scoreManagerPlayer2 != null)
        {
            scoreManagerPlayer2.AddScore(1); // Menambahkan skor ke Player 2
            player2ScoreUI.UpdateScoreUI(); // Memperbarui UI untuk Player 2
        }
    }
}

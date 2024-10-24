using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTembakGameManager : MonoBehaviour
{
    public Button StartButton;
    [SerializeField] private EnemyControllerGameTembek enemyControllerGameTembek;
    [SerializeField] private EnemyShooterGameTembak enemyShooterGameTembak;
    [SerializeField] private EnemySpawnerTetris enemySpawnerTetris;
    [SerializeField] private Player1Control player1Control;
    [SerializeField] private Player2ControllerGameTembak Player2Control;
    [SerializeField] private GameTembakTImer TembakTImer;
    [SerializeField] private GameTembakCOuntDown countdownTimer; // Tambahkan referensi ke CountdownTimer

    void Start()
    {
        player1Control.DisableMovement();
        player1Control.DisableShooting();
        Player2Control.DisableMovement();
        Player2Control.DisableShooting();
        StartButton.onClick.AddListener(StartGame); // Ubah untuk memanggil StartCountdown
    }

    private void StartGame()
    {
        StartButton.interactable = false; // Nonaktifkan tombol Start
        countdownTimer.StartCountdown(); // Mulai countdown dan panggil StartGame setelah selesai
        StartCoroutine(WaitForCountdown());
    }

    private IEnumerator WaitForCountdown()
    {
        yield return new WaitForSeconds(countdownTimer.countdownDuration); // Tunggu sampai countdown selesai

        TembakTImer.StartTimer(); // Memulai timer setelah permainan dimulai

        player1Control.EnableMovement();
        player1Control.EnableShooting();
        Player2Control.EnableMovement();
        Player2Control.EnableShooting();

        enemySpawnerTetris.StartSpawning(); // Mulai spawn musuh saat game dimulai
        enemyShooterGameTembak.StartShooting(); // Mulai penembakan musuh
        enemyControllerGameTembek.StartMoving();
    }

    public void StopGame()
    {
        player1Control.DisableMovement();
        player1Control.DisableShooting();
        Player2Control.DisableMovement();
        Player2Control.DisableShooting();

        enemySpawnerTetris.StopSpawning(); // Hentikan spawn musuh
        enemyShooterGameTembak.StopShooting(); // Hentikan penembakan musuh
        enemyControllerGameTembek.StopMoving(); // Hentikan pergerakan musuh
    }
}

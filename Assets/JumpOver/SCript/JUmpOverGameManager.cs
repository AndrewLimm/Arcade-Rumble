using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JUmpOverGameManager : MonoBehaviour
{
    public Button ButtonGame;
    [SerializeField] JUmpOverJUmp JUmpOverJUmp;
    [SerializeField] JumpOverPlayer2JUmp jumpOverPlayer2JUmp;
    [SerializeField] JumpOverFastFall jumpOverFastFall;
    [SerializeField] JumpOverPlayer2FastFall jumpOverPlayer2FastFall;
    [SerializeField] JumpOverObstacleSpawnerManager jumpOverObstacleSpawnerManager;
    [SerializeField] Parallax JumpOverparallax;
    [SerializeField] JumpOverCOuntDown countdown; // Tambahkan referensi ke countdown
    [SerializeField] JumpOverGameOverManager jumpOverGameOverManager;


    void Start()
    {
        JUmpOverJUmp.player1disableJump();
        jumpOverPlayer2JUmp.disablePlayer2Jump();
        jumpOverFastFall.Player1DisableFastfall();
        jumpOverPlayer2FastFall.disablePlayer2Fasfall();
        jumpOverObstacleSpawnerManager.DisableSpawning();
        JumpOverparallax.disableParallax();

        ButtonGame.onClick.AddListener(StartCountdown); // Panggil countdown saat tombol ditekan

        // Berlangganan ke event countdown selesai
        JumpOverCOuntDown.OnCountdownFinished += StartGame;
    }

    public void StartCountdown()
    {
        countdown.StartCountDown(); // Mulai countdown
    }

    public void StartGame()
    {
        JUmpOverJUmp.player1EnableJump();
        jumpOverPlayer2JUmp.EnablePlayer2Jump();
        jumpOverFastFall.Player1EnableFastfall();
        jumpOverPlayer2FastFall.EnablePlayer2FastFall();
        jumpOverObstacleSpawnerManager.EnableSpawning();
        JumpOverparallax.enableParallax();
    }

    public void EndGame(string winner)
    {
        Debug.Log("Game Over!");
        JUmpOverJUmp.player1disableJump();
        jumpOverPlayer2JUmp.disablePlayer2Jump();
        jumpOverFastFall.Player1DisableFastfall();
        jumpOverPlayer2FastFall.disablePlayer2Fasfall();
        jumpOverObstacleSpawnerManager.DisableSpawning();
        JumpOverparallax.disableParallax();

        jumpOverGameOverManager.TriggerGameOver(winner); // Panggil fungsi GameOverManager untuk menampilkan pemenang
    }
}

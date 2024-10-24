using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectCoinGameManager : MonoBehaviour
{
    public Button StartButton;
    [SerializeField] CollecCoinPotionSpawner collecCoinPotionSpawner;

    [SerializeField] CollectCoinPlayer1Movement collectCoinPlayer1Movement;
    [SerializeField] CollectCoinPlayer2Movement collectCoinPlayer2Movement;
    [SerializeField] CollectTheCoinCountdown collectTheCoinCountdown;
    [SerializeField] CollectTheCointTImer collectTheCointTImer;

    void Start()
    {
        // Nonaktifkan gerakan player sebelum game dimulai
        collectCoinPlayer1Movement.canMove = false;
        collectCoinPlayer2Movement.canMove = false;

        // Menambahkan listener untuk tombol start
        StartButton.onClick.AddListener(StartGame);
    }

    void StartGame()
    {
        // Mulai countdown ketika tombol start ditekan
        collectTheCoinCountdown.StartCountdown();

        // Menunggu countdown selesai sebelum mulai game
        StartCoroutine(WaitCountdown());
    }

    // Coroutine untuk menunggu sampai countdown selesai
    IEnumerator WaitCountdown()
    {
        // Tunggu durasi countdown
        yield return new WaitForSecondsRealtime(collectTheCoinCountdown.CountdownTime + 1f); // Countdown + 1 detik untuk "GO!"

        // Mulai spawning potion
        collecCoinPotionSpawner.StartSpawning();

        // Aktifkan gerakan pemain setelah countdown selesai
        collectCoinPlayer1Movement.EnableMovementplayer1();
        collectCoinPlayer2Movement.EnableMovementplayer2();

        //mulai timersetelah coutdown slesai
        collectTheCointTImer.StartTimer();

        // Sembunyikan tombol start
        StartButton.gameObject.SetActive(false);
    }
}

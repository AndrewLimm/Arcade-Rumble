using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayAliveGameManager : MonoBehaviour
{
    [SerializeField] StayAlivePlayer1Controller stayAlivePlayer1Controller;
    [SerializeField] StayAlivePlayer2Controller StayAlivePlayer2Controller;
    [SerializeField] StayAliveBotItemSpawner[] stayAliveBotItemSpawner;
    [SerializeField] StayAliveBotMovement[] stayAliveBotMovements; // Array untuk banyak bot horizontal
    [SerializeField] StayAliveBotMovementVertical[] stayAliveBotMovementVerticals; // Array untuk banyak bot vertikal
    [SerializeField] StayAliveCountDown stayAliveCountDown;

    public void StartGame()
    {
        stayAliveCountDown.StartCountDown();

        StayAliveCountDown.OnCountdownFinished += OnCountdownFinished;
    }

    private void OnCountdownFinished()
    {
        stayAlivePlayer1Controller.StartMoving(); // Izinkan kontrol pemain 1
        StayAlivePlayer2Controller.StartMoving(); // Izinkan kontrol pemain 2
        foreach (var botMovement in stayAliveBotMovements)
        {
            botMovement.StartMoving();
        }

        // Mulai pergerakan semua bot vertikal
        foreach (var botMovementVertical in stayAliveBotMovementVerticals)
        {
            botMovementVertical.StartMoving();
        }
        foreach (var itemSpawner in stayAliveBotItemSpawner)
        {
            itemSpawner.StartSpawning(); // Start item spawning
        }
    }

}

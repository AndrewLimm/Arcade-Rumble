using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceToFinishGameManager : MonoBehaviour
{
    [SerializeField] RaceToFInishCOuntDown raceToFInishCOuntDown;
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] PlayerMovement2 playerMovement2;

    public void StartGame()

    {
        raceToFInishCOuntDown.StartCountDown();
        RaceToFInishCOuntDown.OnCountdownFinished += OnCountdownFinished;
    }

    public void OnCountdownFinished()
    {
        playerMovement.canMove = true;
        playerMovement2.canMove = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickTapGameManager : MonoBehaviour
{
    [SerializeField] EdibleInput edibleInput;
    [SerializeField] TrashInput trashInput;
    [SerializeField] QuickTapPlayer2EdibleInput quickTapPlayer2EdibleInput;
    [SerializeField] QuickTapPlayer2TrashInput quickTapPlayer2TrashInput;
    [SerializeField] QuickTapCOuntDOwn countdown; // Reference to countdown script
    [SerializeField] QuickTapTImer timer; // Reference to the timer script

    public void StartGamePlay()
    {
        // Start the countdown
        countdown.StartCountDown();

    }

    // This method is called when the countdown finishes
    public void OnCountdownFinished()
    {
        // Allow player inputs and start the game timer
        edibleInput.StartEdibleInputCoroutine();
        trashInput.StartTrashInputCoroutine();
        // spawnerManager.StartCallFood();
        quickTapPlayer2EdibleInput.StartPlayer2EdibleInputCoroutine();
        // quickTapPlayer2Spawner.callFoodPlayer2();
        quickTapPlayer2TrashInput.StartPlayer2TrashInputCoroutine();

        // Start the game timer
        timer.StartTimer();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactionTestGameManager : MonoBehaviour
{
    [SerializeField] Player1Mechanic player1Mechanic;
    [SerializeField] Player2Mechanic Player2Mechanic;
    [SerializeField] ReactionMechanic reactionMechanic;
    [SerializeField] ReactionTestCountDOwn reactionTestCountDOwn;
    [SerializeField] ReactionTestTimer reactionTestTimer;

    public void StartGame()
    {
        reactionTestCountDOwn.StartCountDown();
    }

    public void OnCountdownFinished()
    {
        Debug.Log("Memulai Game...");
        player1Mechanic.EnableInput(); // Mengaktifkan input untuk pemain 1
        Player2Mechanic.EnableInput(); // Mengaktifkan input untuk pemain 2
        reactionMechanic.StartGameLoop();
        reactionTestTimer.StartTimer();
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HelpMeOUtPlayerTimeController : MonoBehaviour
{
    public TMP_Text player1TimerText; // UI Text untuk waktu Player 1
    public TMP_Text player2TimerText; // UI Text untuk waktu Player 2

    private float player1ElapsedTime = 0f;
    private float player2ElapsedTime = 0f;

    private bool isPlayer1Active = false;
    private bool isPlayer2Active = false;



    private void OnEnable()
    {
        HelpMeOUtCountdown.OnCountdownFinished += StartTimers; // Daftar ke event countdown
    }

    private void OnDisable()
    {
        HelpMeOUtCountdown.OnCountdownFinished -= StartTimers; // Unregister dari event countdown
    }

    private void Update()
    {
        if (isPlayer1Active)
        {
            player1ElapsedTime += Time.deltaTime;
        }

        if (isPlayer2Active)
        {
            player2ElapsedTime += Time.deltaTime;
        }

        UpdateTimerUI();
    }

    public void StartTimers()
    {
        isPlayer1Active = true;
        isPlayer2Active = true;
    }

    public void StopPlayer1Timer()
    {
        isPlayer1Active = false;
        Debug.Log("Player 1 finished! Time: " + player1ElapsedTime.ToString("F2") + " seconds");
    }

    public void StopPlayer2Timer()
    {
        isPlayer2Active = false;
        Debug.Log("Player 2 finished! Time: " + player2ElapsedTime.ToString("F2") + " seconds");
    }

    private void UpdateTimerUI()
    {
        player1TimerText.text = "Player 1 Time: " + player1ElapsedTime.ToString("F2") + " s";
        player2TimerText.text = "Player 2 Time: " + player2ElapsedTime.ToString("F2") + " s";
    }

    public void StopAllTimers()
    {
        StopPlayer1Timer();
        StopPlayer2Timer();
    }

}

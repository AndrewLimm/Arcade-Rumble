using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpMeOutGameManager : MonoBehaviour
{
    public Button Startbutton;
    [SerializeField] HelpMeOUtCountdown HelpMeOUtCountdown;
    [SerializeField] HelpMeOutPlayer1Controller HelpMeOutPlayer1;
    [SerializeField] HelpMeOutPlayer2Controller helpMeOutPlayer2Controller;
    [SerializeField] HelpMeOUtPlayerTimeController TimeController;

    void Start()
    {
        Startbutton.onClick.AddListener(gameStart);

        HelpMeOutPlayer1.DisableControls();
        helpMeOutPlayer2Controller.DisableControls();
    }

    public void gameStart()
    {
        HelpMeOUtCountdown.StartCountDown();

        HelpMeOUtCountdown.OnCountdownFinished += EnablePlayerControls;
    }
    public void EnablePlayerControls()
    {
        HelpMeOutPlayer1.EnableControls();
        helpMeOutPlayer2Controller.EnableControls();

        TimeController.StartTimers();

        // Unsubscribe from the event after enabling controls and starting timers
        HelpMeOUtCountdown.OnCountdownFinished -= EnablePlayerControls;
    }
    public void EndGame()
    {
        // Menonaktifkan kontrol pemain
        HelpMeOutPlayer1.DisableControls();
        helpMeOutPlayer2Controller.DisableControls();

        // Menghentikan semua timer
        TimeController.StopAllTimers();

        Debug.Log("Permainan dihentikan: Kontrol pemain dinonaktifkan dan timer dihentikan.");
    }
}

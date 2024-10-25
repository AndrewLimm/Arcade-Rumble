using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuickMathGameTImer : MonoBehaviour
{
    public float totalTime = 60f; // Total waktu permainan
    public bool isGameRunning = false;

    private float timeRemaining;
    private Coroutine timerCoroutine;

    // Referensi ke skrip GameOver
    public QUickmathgameover gameOverScript;

    // Referensi ke TMP Text untuk UI timer
    public TMP_Text timerText;

    // Event untuk memberitahu akhir permainan
    public static event System.Action OnTimeUp;

    private void Start()
    {
        timeRemaining = totalTime;
        UpdateTimerText(); // Perbarui tampilan timer pada awal permainan
    }

    public void StartTimer()
    {
        if (!isGameRunning)
        {
            isGameRunning = true;
            timerCoroutine = StartCoroutine(UpdateTimer());
        }
    }

    private IEnumerator UpdateTimer()
    {
        while (timeRemaining > 0 && isGameRunning)
        {
            yield return new WaitForSeconds(1f);
            timeRemaining--;
            UpdateTimerText();

            if (timeRemaining <= 0)
            {
                isGameRunning = false;
                EndGame();
            }
        }
    }

    private void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60f);
        int seconds = Mathf.FloorToInt(timeRemaining % 60f);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void EndGame()
    {
        if (gameOverScript != null)
        {
            gameOverScript.CheckWinner();
        }

        OnTimeUp?.Invoke(); // Memanggil event untuk memberitahu akhir permainan
    }
}

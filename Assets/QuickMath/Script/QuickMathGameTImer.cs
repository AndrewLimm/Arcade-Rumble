using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickMathGameTImer : MonoBehaviour
{
    public float totalTime = 60f;  // Total waktu permainan dalam detik (default: 60 detik)
    public bool isGameRunning = false;  // Untuk melacak apakah permainan sedang berjalan

    private float timeRemaining;

    // Event yang dapat di-trigger ketika waktu habis
    public delegate void TimeUpEvent();
    public static event TimeUpEvent OnTimeUp;

    // Event untuk meng-update UI Timer (Anda bisa menghubungkannya ke UI Timer script)
    public delegate void TimeUpdatedEvent(float timeRemaining);
    public static event TimeUpdatedEvent OnTimeUpdated;

    void Start()
    {
        timeRemaining = totalTime;  // Set waktu awal menjadi total waktu yang diatur
    }

    // Memulai timer
    public void StartTimer()
    {
        if (!isGameRunning)
        {
            isGameRunning = true;
            StartCoroutine(UpdateTimer());
        }
    }

    // Menghentikan timer
    public void StopTimer()
    {
        isGameRunning = false;
    }

    // Coroutine untuk meng-update timer
    private IEnumerator UpdateTimer()
    {
        while (timeRemaining > 0 && isGameRunning)
        {
            yield return new WaitForSeconds(1f);  // Menunggu satu detik
            timeRemaining--;

            // Trigger event untuk meng-update UI
            if (OnTimeUpdated != null)
            {
                OnTimeUpdated(timeRemaining);
            }

            // Jika waktu habis, stop timer dan trigger event waktu habis
            if (timeRemaining <= 0)
            {
                timeRemaining = 0;
                isGameRunning = false;

                if (OnTimeUp != null)
                {
                    OnTimeUp();  // Trigger event waktu habis
                }
            }
        }
    }

    // Mengembalikan waktu yang tersisa
    public float GetRemainingTime()
    {
        return timeRemaining;
    }
}

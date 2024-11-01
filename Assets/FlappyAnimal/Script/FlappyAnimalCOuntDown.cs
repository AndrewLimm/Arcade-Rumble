using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FlappyAnimalCOuntDown : MonoBehaviour
{

    public float countdownDuration = 5f;
    public TMP_Text countdownText;
    [SerializeField] private FlappyAnimalGameManager flappyAnimalGameManager;

    private void Start()
    {
        countdownText.gameObject.SetActive(false);
    }

    public void StartCountdown()
    {
        StartCoroutine(Countdown());
    }

    private IEnumerator Countdown()
    {
        countdownText.gameObject.SetActive(true);
        float realTimeCountdown = countdownDuration;

        while (realTimeCountdown > 0)
        {
            countdownText.text = Mathf.Ceil(realTimeCountdown).ToString();
            yield return new WaitForSecondsRealtime(1f);
            realTimeCountdown--;
        }

        countdownText.text = "GO!";
        yield return new WaitForSecondsRealtime(1f);

        countdownText.gameObject.SetActive(false);

        // Notify GameManager that the countdown is complete
        flappyAnimalGameManager.StartGame();
    }
}

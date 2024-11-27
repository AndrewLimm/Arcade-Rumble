using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FlappyAnimalCOuntDown : MonoBehaviour
{

    public float countdownDuration = 5f;
    public TMP_Text countdownText;
    [SerializeField] private FlappyAnimalGameManager flappyAnimalGameManager;

    public GameObject attentionObject1; // Objek yang muncul di awal dan menghilang setelah countdown
    public GameObject attentionObject2; // Objek kedua yang muncul sebelum "GO!"

    private void Start()
    {
        countdownText.gameObject.SetActive(false);

        if (attentionObject1 != null)
            attentionObject1.SetActive(false);

        if (attentionObject2 != null)
            attentionObject2.SetActive(false);
    }

    public void StartCountdown()
    {
        if (attentionObject1 != null)
            attentionObject1.SetActive(true); // Menampilkan objek perhatian di awal

        if (attentionObject2 != null)
            attentionObject2.SetActive(true); // Menampilkan objek perhatian di awal
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

        if (countdownText != null)
            countdownText.gameObject.SetActive(false); // Sembunyikan teks countdown

        if (attentionObject1 != null)
            attentionObject1.SetActive(false); // Sembunyikan objek perhatian setelah countdown

        if (attentionObject2 != null)
            attentionObject2.SetActive(false); // Sembunyikan objek perhatian setelah countdown


        // Notify GameManager that the countdown is complete
        flappyAnimalGameManager.StartGame();
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountDown : MonoBehaviour
{
    public TMP_Text _countdownText;
    public float _countdownTime = 5f;

    [SerializeField] ImageDisplay _display;
    [SerializeField] MemoryMatchGameTImer gameTImer;

    void Start()
    {
    }

    public void StartCountdownCoroutine()
    {
        StartCoroutine(StartCountdown());
    }

    IEnumerator StartCountdown()
    {
        while (_countdownTime > 0)
        {
            _countdownText.text = _countdownTime.ToString("F0");
            yield return new WaitForSeconds(1f);
            _countdownTime--;
        }
        _countdownText.text = "GO!";
        yield return new WaitForSeconds(1f);
        _countdownText.gameObject.SetActive(false);
        // Start the game

        // Mulai permainan setelah countdown selesai
        _display.StartGame();
        gameTImer.StartGameTimer(); // Memulai timer permainan di sini
    }
}

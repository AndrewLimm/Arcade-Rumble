using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoryMatchGameManager : MonoBehaviour
{

    [SerializeField] CountDown countdown; // Reference to the CountDown script
    [SerializeField] Button startButton; // Reference to the Button component


    void Start()
    {
        // You can optionally disable the countdown at the start
        countdown.gameObject.SetActive(false);
    }

    public void StartGame()
    {
        // Activate the countdown object
        countdown.gameObject.SetActive(true);
        countdown.StartCountdownCoroutine(); // Call the countdown coroutine

        startButton.gameObject.SetActive(false);

    }
}

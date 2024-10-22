using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixMayhemGameManager : MonoBehaviour
{
    public MixMayhemPoolRequestor requestor;
    public float miniGameDuration = 15f;
    public float transitionDuration = 8f;
    public float transitionDurationPanel1 = 2f;

    private GameObject currentMiniGame1;
    private GameObject currentMiniGame2;

    private void Start()
    {
        StartMiniGame1();
    }

    private void StartMiniGame1()
    {
        // Nonaktifkan mini-game yang sedang aktif di panel 1
        DeactivateCurrentMiniGame(currentMiniGame1);

        // Meminta game acak dari panel 1
        currentMiniGame1 = requestor.RequestPanel1Game();
        currentMiniGame1.SetActive(true);

        // Panggil mini-game kedua setelah durasi tertentu
        Invoke("StartMiniGame2", transitionDuration);

        // Durasi untuk mini-game pertama
        Invoke("EndMiniGame1", miniGameDuration);
    }

    private void StartMiniGame2()
    {
        // Nonaktifkan mini-game yang sedang aktif di panel 2
        DeactivateCurrentMiniGame(currentMiniGame2);

        // Meminta game acak dari panel 2
        currentMiniGame2 = requestor.RequestPanel2Game();
        currentMiniGame2.SetActive(true);
    }

    private void EndMiniGame1()
    {
        // Nonaktifkan mini-game pertama
        DeactivateCurrentMiniGame(currentMiniGame1);

        // Tunggu cooldown sebelum mengulang mini-game 1
        Invoke("RestartMiniGame1", transitionDurationPanel1);

        // Durasi total untuk mini-game kedua
        Invoke("EndMiniGame2", miniGameDuration);
    }

    private void EndMiniGame2()
    {
        // Nonaktifkan mini-game kedua
        DeactivateCurrentMiniGame(currentMiniGame2);

        // Mulai ulang mini-game 1 setelah cooldown
        Invoke("RestartMiniGame1", transitionDurationPanel1);
    }

    private void RestartMiniGame1()
    {
        StartMiniGame1();
    }

    private void DeactivateCurrentMiniGame(GameObject miniGame)
    {
        // Jika mini-game yang diberikan tidak null, nonaktifkan
        if (miniGame != null)
        {
            miniGame.SetActive(false);
        }
    }
}

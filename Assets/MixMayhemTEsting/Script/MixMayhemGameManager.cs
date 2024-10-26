using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixMayhemGameManager : MonoBehaviour
{
    public MixMayhemPoolRequestor requestor;
    public float miniGameDuration = 15f; // Durasi mini-game panel 1
    public float transitionDuration = 2f; // Durasi transisi antara mini-games
    public float panel2StartDelay = 7f; // Delay untuk memulai panel 2 setelah panel 1 dimulai

    private GameObject currentMiniGame1;
    private GameObject currentMiniGame2;

    [SerializeField] QuickMathMixMayhemGameOverManager QuickMathgameOverManager;
    [SerializeField] KarateAnimalMixMayhemGameOverManager KarateAnimalMixMayhemGameOver;
    [SerializeField] ReactionTestMixMayhemGameOverManager ReactionTestMixMayhemGameOverManager;
    [SerializeField] CatchITemMixMayhemGameOver catchITemMixMayhemGameOver;
    [SerializeField] MIxMayhemRaceTofinishGameOverManager mIxMayhemRaceTofinishGameOverManager;
    [SerializeField] private MixMayhemCountdownTImer countdownTimer;


    private void Start()
    {
        // Memulai countdown sebelum memulai mini-game
        countdownTimer.gameObject.SetActive(true); // Pastikan objek countdown aktif
    }

    public void StartMiniGame1()
    {
        // Nonaktifkan mini-game yang sedang aktif di panel 1
        DeactivateCurrentMiniGame(currentMiniGame1);

        // Meminta game acak dari panel 1
        currentMiniGame1 = requestor.RequestPanel1Game();

        if (currentMiniGame1 != null)
        {
            currentMiniGame1.SetActive(true);
            // Panggil EndMiniGame1 setelah durasi mini-game panel 1
            Invoke("EndMiniGame1", miniGameDuration);
        }
        else
        {
            Debug.LogWarning("Tidak ada game yang tersedia di Panel 1.");
        }

        // Panggil StartMiniGame2 setelah 7 detik dari StartMiniGame1
        Invoke("StartMiniGame2", panel2StartDelay);
    }

    private void StartMiniGame2()
    {
        // Nonaktifkan mini-game yang sedang aktif di panel 2
        DeactivateCurrentMiniGame(currentMiniGame2);

        // Meminta game acak dari panel 2
        currentMiniGame2 = requestor.RequestPanel2Game();
        if (currentMiniGame2 != null)
        {
            currentMiniGame2.SetActive(true);
            // Panggil EndMiniGame2 setelah durasi mini-game panel 2
            Invoke("EndMiniGame2", miniGameDuration);
        }
        else
        {
            Debug.LogWarning("Tidak ada game yang tersedia di Panel 2.");
        }
    }

    private void EndMiniGame1()
    {
        // Panggil game over manager yang sesuai berdasarkan mini-game aktif
        if (currentMiniGame1 != null)
        {
            if (currentMiniGame1.CompareTag("QuickMath"))
            {
                QuickMathgameOverManager.TriggerEnd(gameObject.tag);
            }
            else if (currentMiniGame1.CompareTag("KarateAnimal"))
            {
                KarateAnimalMixMayhemGameOver.KarateAnimalTriggerEnd(gameObject.tag);
            }
        }

        // Nonaktifkan mini-game pertama
        DeactivateCurrentMiniGame(currentMiniGame1);

        // Tunggu selama 2 detik sebelum memulai mini-game baru di panel 1
        Invoke("StartMiniGame1", transitionDuration);
    }

    private void EndMiniGame2()
    {
        // Panggil game over manager yang sesuai berdasarkan mini-game aktif
        if (currentMiniGame2 != null)
        {
            if (currentMiniGame2.CompareTag("Catch"))
            {
                catchITemMixMayhemGameOver.CatchItemTriggerEnd(gameObject.tag);
            }
            else if (currentMiniGame2.CompareTag("ReactionTest"))
            {
                ReactionTestMixMayhemGameOverManager.ReactionTestEndTrigger(gameObject.tag);
            }
            else if (currentMiniGame2.CompareTag("RaceToFinish"))
            {
                mIxMayhemRaceTofinishGameOverManager.RaceToFinishGameOver(gameObject.tag);
            }
        }

        // Nonaktifkan mini-game kedua
        DeactivateCurrentMiniGame(currentMiniGame2);

        // Tunggu selama 2 detik sebelum memulai mini-game baru di panel 2
        Invoke("StartMiniGame2", transitionDuration);
    }

    // Fungsi untuk menonaktifkan mini-game yang sedang aktif
    private void DeactivateCurrentMiniGame(GameObject miniGame)
    {
        if (miniGame != null)
        {
            miniGame.SetActive(false);
        }
    }
}

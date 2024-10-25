using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KarateAnimalGameManager : MonoBehaviour
{
    public Button StartButton;
    // [SerializeField] KarateAnimalEnemyControlplayer2 karateAnimalEnemyControlplayer2;
    // [SerializeField] EnemyController enemyController;
    [SerializeField] PlayerController1 playerController1;
    [SerializeField] PlayerController2 playerController2;
    [SerializeField] TargetSpawner[] targetSpawner; // Array for multiple TargetSpawners
    [SerializeField] KarateAnimalTimerGamer karateAnimalTimerGamer;

    [SerializeField] KarateAnimalCoutnDown karateAnimalCoutnDown;

    void Start()
    {
        // karateAnimalEnemyControlplayer2.DisableEnemyCOntrolPlayer2();
        // enemyController.DisableEnemyCOntrolPlayer1();
        playerController1.DisableMove();
        playerController2.DisableMovePlayer2();
        DisableAllSpawners();
        StartButton.onClick.AddListener(InitialCountDown);
        KarateAnimalCoutnDown.OnCountdownFinished += StartGame;

    }
    private void OnDestroy()
    {
        // Unsubscribe from the event when the object is destroyed
        KarateAnimalCoutnDown.OnCountdownFinished -= StartGame;
    }

    public void InitialCountDown()
    {
        karateAnimalCoutnDown.StartCountDown();
    }

    public void StartGame()
    {
        // karateAnimalEnemyControlplayer2.EnableEnemyCOntrolPlayer2();
        // enemyController.EnableEnemyCOntrolPlayer1();
        playerController1.EnableMove();
        playerController2.EnableMovePlayer2();
        EnableAllSpawners();
        karateAnimalTimerGamer.StartTimer();

    }

    public void DisableAllGameElements()
    {
        // karateAnimalEnemyControlplayer2.DisableEnemyCOntrolPlayer2();
        // enemyController.DisableEnemyCOntrolPlayer1();
        playerController1.DisableMove();
        playerController2.DisableMovePlayer2();
        DisableAllSpawners();
    }

    // Enable all TargetSpawners
    private void EnableAllSpawners()
    {
        foreach (var spawner in targetSpawner)
        {
            spawner.enableSpawn();
        }
    }

    // Disable all TargetSpawners
    private void DisableAllSpawners()
    {
        foreach (var spawner in targetSpawner)
        {
            spawner.disableSpawn();
        }
    }
}

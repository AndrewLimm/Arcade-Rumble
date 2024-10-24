using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTembakGameManager : MonoBehaviour
{
    public Button StartButton;
    [SerializeField] EnemyControllerGameTembek enemyControllerGameTembek;
    [SerializeField] EnemyShooterGameTembak enemyShooterGameTembak;
    [SerializeField] EnemySpawnerTetris enemySpawnerTetris;
    [SerializeField] Player1Control player1Control;
    [SerializeField] Player2ControllerGameTembak Player2Control;

    void Start()
    {
        StartButton.onClick.AddListener(StartGame);
    }

    public void StartGame()
    {

    }
}

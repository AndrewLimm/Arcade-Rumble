using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopTheBalloonGameManager : MonoBehaviour
{
    public BalloonSpawner balloonSpawner;
    public float roundTime = 10f;
    private float roundTimer;

    private void Start()
    {
        StartRound();
    }

    private void Update()
    {
        roundTimer -= Time.deltaTime;
        if (roundTimer <= 0)
        {
            balloonSpawner.EndRound();
        }
    }

    void StartRound()
    {
        roundTimer = roundTime;
        balloonSpawner.SpawnBalloon();
    }
}

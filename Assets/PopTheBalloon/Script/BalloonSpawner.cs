using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonSpawner : MonoBehaviour
{
    public List<GameObject> balloonPrefabs; // Daftar prefabs untuk berbagai jenis balon
    public Transform spawnPoint;
    public Transform destroyPoint;
    public float spawnInterval = 2f; // Interval untuk spawn balon
    public float roundTime = 10f; // Waktu aktif ronde
    public float waitTime = 8f; // Waktu tunggu jika tidak ada jawaban

    private float timer;
    private float waitTimer;
    private GameObject currentBalloon;
    private bool balloonActive;
    private bool waitingForInput;
    private bool roundEnded;

    private void Start()
    {
        timer = spawnInterval;
        waitTimer = waitTime;
        balloonActive = false;
        waitingForInput = false;
        roundEnded = false;
    }

    private void Update()
    {
        if (balloonActive)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                EndRound();
            }
        }
        else if (waitingForInput)
        {
            waitTimer -= Time.deltaTime;
            if (waitTimer <= 0)
            {
                EndRound(); // Akhiri ronde setelah waktu tunggu jika tidak ada jawaban
            }
        }
        else
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                SpawnBalloon();
                timer = spawnInterval; // Set timer untuk spawn berikutnya
            }
        }
    }

    public void SpawnBalloon()
    {
        if (balloonPrefabs.Count == 0)
        {
            Debug.LogWarning("Tidak ada prefab balon dalam daftar!");
            return;
        }

        // Jika sudah ada balon aktif, hapus sebelum membuat yang baru
        if (currentBalloon != null)
        {
            Destroy(currentBalloon);
        }

        // Pilih balon dari daftar secara acak
        GameObject balloonPrefab = balloonPrefabs[Random.Range(0, balloonPrefabs.Count)];
        GameObject balloon = Instantiate(balloonPrefab, spawnPoint.position, Quaternion.identity);

        Balloon balloonScript = balloon.GetComponent<Balloon>();
        balloonScript.destroyPoint = destroyPoint; // Set destroyPoint dari balon
        currentBalloon = balloon;
        balloonActive = true;
        waitingForInput = true; // Set untuk menunggu input dari pemain
        roundEnded = false;
        timer = roundTime; // Set timer untuk ronde aktif
    }

    public void EndRound()
    {
        if (currentBalloon != null)
        {
            Destroy(currentBalloon);
        }
        balloonActive = false;
        waitingForInput = false;
        waitTimer = waitTime; // Reset timer tunggu
        // Logic to end the current round and proceed to the next round.
    }

    // public void DestroyBalloon(GameObject balloon)
    // {
    //     Destroy(balloon); // Hancurkan balon yang diberikan
    //     balloonActive = false; // Set balon tidak aktif
    //     Debug.Log("Balloon destroyed");
    // }

    // public void PlayerAnswered()
    // {
    //     if (!roundEnded)
    //     {
    //         EndRound(); // Akhiri ronde jika salah satu pemain menjawab
    //     }
    // }
}

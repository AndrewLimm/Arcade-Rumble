using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    public string balloonType; // Jenis balon, misalnya "Red", "Yellow", "Green"
    public float speed = 5f;
    public Transform destroyPoint;

    private void Update()
    {
        if (destroyPoint != null)
        {
            // Gerakkan balon menuju destroyPoint dengan kecepatan tetap
            float step = speed * Time.deltaTime; // Calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, destroyPoint.position, step);

            // Debugging: Log posisi balon dan destroyPoint
            Debug.Log($"Balloon Position: {transform.position}, Destroy Point Position: {destroyPoint.position}");

            // Jika balon sudah dekat dengan destroyPoint, hancurkan balon
            if (Vector3.Distance(transform.position, destroyPoint.position) < 0.1f)
            {
                Debug.Log("Balloon reached destroyPoint, destroying...");
                Destroy(gameObject); // Hancurkan balon
                FindObjectOfType<BalloonSpawner>().EndRound(); // Akhiri ronde
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player1") || other.CompareTag("Player2"))
        {
            // Ambil skrip input dari pemain yang berinteraksi
            PopTheBalloonPlayerInput1 player1Input = other.GetComponent<PopTheBalloonPlayerInput1>();
            PopTheBalloonPlayerInput2 player2Input = other.GetComponent<PopTheBalloonPlayerInput2>();

            bool correctInput = false;
            if (player1Input != null)
            {
                correctInput = player1Input.IsInputCorrect(balloonType);
            }
            else if (player2Input != null)
            {
                correctInput = player2Input.IsInputCorrect(balloonType);
            }

            // Debugging: Log hasil deteksi input
            Debug.Log($"BalloonType: {balloonType}, Player Input Correct: {correctInput}");

            if (correctInput)
            {
                Debug.Log("Correct input detected, destroying balloon...");
                Destroy(gameObject); // Hancurkan balon
                FindObjectOfType<BalloonSpawner>().EndRound(); // Akhiri ronde
            }
        }
    }
}


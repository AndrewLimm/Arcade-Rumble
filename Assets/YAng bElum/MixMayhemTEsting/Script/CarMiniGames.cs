using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMiniGames : MonoBehaviour
{
    public float speed = 10f; // Kecepatan mobil
    public float laneChangeSpeed = 2f; // Kecepatan pindah jalur

    void Update()
    {
        // Gerakkan mobil maju
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Pindah jalur dengan tombol A/D atau panah kiri/kanan
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * laneChangeSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * laneChangeSpeed * Time.deltaTime);
        }
    }
}

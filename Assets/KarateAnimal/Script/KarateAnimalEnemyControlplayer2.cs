using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarateAnimalEnemyControlplayer2 : MonoBehaviour
{

    public float speed = 2f; // Kecepatan pergerakan musuh
    private Vector3 laneTarget; // Posisi tujuan di jalur tetap

    public bool CanMoveenemyPlayer2 = false;

    public void SetLane(Vector3 lanePosition)
    {
        laneTarget = lanePosition; // Tetapkan jalur tetap saat musuh di-spawn

    }

    void Update()
    {
        if (CanMoveenemyPlayer2)
        { // Gerakkan musuh lurus menuju arah atas layar (top-down)
            transform.position += Vector3.up * speed * Time.deltaTime;

            // Cek apakah musuh sudah mencapai ujung layar
            if (transform.position.y > laneTarget.y + 10f) // Atur jarak untuk destroy
            {
                Destroy(gameObject);
            }
        }

    }

    // Fungsi untuk mendeteksi tabrakan dengan player
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Jika musuh menyentuh pemain
        if (other.CompareTag("Player2"))
        {
            // Hancurkan musuh
            Destroy(gameObject);
            // Kamu juga bisa menambahkan efek lain seperti suara atau animasi di sini
            Debug.Log("Enemy collided with player and destroyed");
        }
    }

    public void EnableEnemyCOntrolPlayer2()
    {
        CanMoveenemyPlayer2 = true; return;
    }

    public void DisableEnemyCOntrolPlayer2()
    {
        CanMoveenemyPlayer2 = false; return;
    }
}

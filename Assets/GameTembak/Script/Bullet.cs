using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 5f;

    void Start()
    {
        // Menghancurkan peluru setelah waktu tertentu
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        // Menggerakkan peluru ke atas
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Memeriksa apakah peluru mengenai musuh
        if (other.CompareTag("Enemy"))
        {
            // Alih-alih langsung menghancurkan musuh, panggil fungsi yang menangani kematian musuh
            EnemyControllerGameTembek enemy = other.GetComponent<EnemyControllerGameTembek>();
            if (enemy != null)
            {
                enemy.HandleDeath(); // Panggil fungsi untuk menangani kematian musuh
            }

            // Hancurkan peluru
            Destroy(gameObject);
        }

        if (other.CompareTag("Wall"))
        {
            Debug.Log("Peluru terkena tembok!"); // Debug untuk tembok
            Destroy(gameObject); // Hancurkan peluru jika menyentuh boundary
        }
    }
}

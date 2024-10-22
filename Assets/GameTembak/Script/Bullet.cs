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
            // Hancurkan musuh
            Destroy(other.gameObject);
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

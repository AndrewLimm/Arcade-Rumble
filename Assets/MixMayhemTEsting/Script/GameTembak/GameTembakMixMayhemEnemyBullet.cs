using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTembakMixMayhemEnemyBullet : MonoBehaviour
{
    public float speed = 5f;  // Kecepatan peluru
    public float lifetime = 3f;  // Waktu hidup peluru sebelum dihancurkan

    void Start()
    {
        // Menghancurkan peluru setelah beberapa detik
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        // Menggerakkan peluru ke bawah
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        // Jika peluru mengenai objek dengan tag "Player1"
        if (other.CompareTag("Player1"))
        {
            FindObjectOfType<GameTembakMixMayhemGameCOntroll>().OnPlayerHit("Player1");
            Debug.Log("Peluru mengenai Player 1!");
            Destroy(gameObject); // Hancurkan peluru
        }
        // Jika peluru mengenai objek dengan tag "Player2"
        else if (other.CompareTag("Player2"))
        {
            FindObjectOfType<GameTembakMixMayhemGameCOntroll>().OnPlayerHit("Player2");
            Debug.Log("Peluru mengenai Player 2!");
            Destroy(gameObject); // Hancurkan peluru
        }
        // Jika peluru mengenai boundary
        else if (other.CompareTag("Boundary"))
        {
            Destroy(gameObject); // Hancurkan peluru jika menyentuh boundary
        }
    }
}

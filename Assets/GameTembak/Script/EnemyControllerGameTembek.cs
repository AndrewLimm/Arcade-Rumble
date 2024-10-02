using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerGameTembek : MonoBehaviour
{
    public float speed = 1f;
    public float moveDownDistance = 0.5f;

    private bool movingRight = true;
    public int pointsForKill = 10; // Jumlah poin yang diberikan ketika musuh terbunuh

    [SerializeField] ScoreManagerGameTembak scoreManagerGameTembak;

    void Awake()
    {
        // Temukan ScoreManagerGameTembak di scene
        scoreManagerGameTembak = FindObjectOfType<ScoreManagerGameTembak>();

        // Periksa jika tidak ditemukan
        if (scoreManagerGameTembak == null)
        {
            Debug.LogError("ScoreManagerGameTembak tidak ditemukan di scene!");
        }
    }


    void Update()
    {
        MoveEnemy();
    }

    void MoveEnemy()
    {
        // Gerakan ke kanan
        if (movingRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Jika musuh mencapai batas, ganti arah dan turun
        if (other.CompareTag("Boundary"))
        {
            movingRight = !movingRight;
            transform.position = new Vector2(transform.position.x, transform.position.y - moveDownDistance);
        }
        else if (other.CompareTag("PlayerBullet"))
        {
            // Ketika terkena peluru dari pemain, musuh akan mati dan memberikan poin
            Destroy(other.gameObject); // Hancurkan peluru

            if (other.gameObject.layer == LayerMask.NameToLayer("Player1Bullet"))
            {
                // Tambahkan poin untuk Player 1
                scoreManagerGameTembak.AddScorePlayer1(pointsForKill);
            }
            else if (other.gameObject.layer == LayerMask.NameToLayer("Player2Bullet"))
            {
                // Tambahkan poin untuk Player 2
                scoreManagerGameTembak.AddScorePlayer2(pointsForKill);
            }

            Destroy(gameObject); // Hancurkan musuh
        }
    }
}

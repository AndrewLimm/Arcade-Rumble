using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerGameTembek : MonoBehaviour
{
    public float speed = 1f;
    public float moveDownDistance = 0.5f;

    private bool movingRight = true;
    private bool canMove = true; // Flag untuk mengontrol gerakan musuh
    public int pointsForKill = 10; // Jumlah poin yang diberikan ketika musuh terbunuh

    [SerializeField] ScoreManagerGameTembak scoreManagerGameTembak;
    // Audio variables
    [SerializeField] public AudioClip deathSound; // AudioClip untuk suara kematian musuh
    public AudioSource audioSource;
    void Awake()
    {

        // Temukan ScoreManagerGameTembak di scene
        scoreManagerGameTembak = FindObjectOfType<ScoreManagerGameTembak>();

        // Periksa jika tidak ditemukan
        if (scoreManagerGameTembak == null)
        {
            Debug.LogError("ScoreManagerGameTembak tidak ditemukan di scene!");
        }
        // Tambahkan AudioSource dan atur clip ke deathSound
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = deathSound; // Atur clip untuk audio source
        audioSource.playOnAwake = false;
    }

    void Update()
    {
        // Panggil MoveEnemy hanya jika canMove bernilai true
        if (canMove)
        {
            MoveEnemy();
        }
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
            PlayDeathSoundAndDestroy(); // Mainkan suara dan hancurkan musuh
        }
    }


    private void PlayDeathSoundAndDestroy()
    {
        // Pastikan audio source tersedia sebelum diputar
        if (deathSound != null)
        {
            audioSource.PlayOneShot(deathSound);
            Invoke(nameof(DestroyEnemy), deathSound.length); // Hancurkan musuh setelah durasi suara
        }
        else
        {
            Destroy(gameObject); // Hancurkan segera jika tidak ada suara
        }
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject); // Hancurkan musuh sepenuhnya
    }

    // Fungsi untuk memulai gerakan musuh
    public void StartMoving()
    {
        canMove = false;
        return; // Aktifkan gerakan
    }

    public void StopMoving()

    {
        canMove = true;
        return;
    }
}

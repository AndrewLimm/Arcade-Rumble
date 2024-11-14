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

    private Animator animator; // Referensi ke komponen Animator
    private bool isDestroyed = false; // Untuk mencegah beberapa kali pemanggilan saat musuh sudah dihancurkan


    void Awake()
    {

        // Temukan ScoreManagerGameTembak di scene
        scoreManagerGameTembak = FindObjectOfType<ScoreManagerGameTembak>();

        // Periksa jika tidak ditemukan
        if (scoreManagerGameTembak == null)
        {
            Debug.LogError("ScoreManagerGameTembak tidak ditemukan di scene!");
        }

        // **Mendapatkan komponen Animator**
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator tidak ditemukan pada musuh!");
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
            if (!isDestroyed) // Cegah pemanggilan berulang
            {
                isDestroyed = true;
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

                TriggerExplosion(); // Mainkan animasi ledakan
            }
        }
    }
    // Fungsi untuk menangani kematian musuh
    public void HandleDeath()
    {
        if (!isDestroyed) // Cegah pemanggilan berulang
        {
            isDestroyed = true;
            TriggerExplosion(); // Mainkan animasi ledakan dan suara
        }
    }

    // Method untuk memicu animasi ledakan
    private void TriggerExplosion()
    {
        if (animator != null)
        {
            animator.SetTrigger("Explode"); // Aktifkan animasi ledakan
        }
        PlayDeathSound(); // Mainkan suara kematian
        StartCoroutine(DestroyAfterAnimation()); // Hancurkan setelah animasi selesai
    }

    // Coroutine untuk menghancurkan musuh setelah animasi selesai
    private IEnumerator DestroyAfterAnimation()
    {
        // Tunggu hingga durasi animasi (sesuaikan dengan panjang animasi ledakan)
        yield return new WaitForSeconds(0.5f); // Sesuaikan waktu dengan durasi animasi ledakan

        Destroy(gameObject); // Hancurkan musuh sepenuhnya
    }

    private void PlayDeathSound()
    {
        // Pastikan audio source tersedia sebelum diputar
        if (audioSource != null && deathSound != null)
        {
            audioSource.PlayOneShot(deathSound);
        }
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

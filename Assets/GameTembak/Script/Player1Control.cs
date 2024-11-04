using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Control : MonoBehaviour
{
    public float speed = 5f;
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer; // Komponen SpriteRenderer untuk mengatur flip
    private float lastShootTime; // Waktu tembakan terakhir
    public float shootCooldown = 0.3f; // Durasi cooldown tembakan

    public bool canMove = false; // Variabel untuk mengontrol kapan bisa bergerak
    public bool canShoot = false; // Variabel untuk mengontrol kapan bisa menembak

    [SerializeField] ImmunePlayer1GameTembak immunePlayer; // Referensi ke script immune

    [SerializeField] public AudioClip shootSound; // AudioClip untuk suara tembakan
    public AudioSource audioSource; // AudioSource untuk memainkan suara

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>(); // Mendapatkan komponen SpriteRenderer
        immunePlayer = GetComponent<ImmunePlayer1GameTembak>();

        // Awal game, tidak bisa bergerak atau menembak
        canMove = false;
        canShoot = false;
    }

    void Update()
    {
        // Hanya bisa bergerak jika canMove bernilai true
        if (canMove)
        {
            float move = 0;
            if (Input.GetKey(KeyCode.A))
            {
                move = -1; // Bergerak ke kiri
                spriteRenderer.flipX = false; // Membalik sprite ke arah kiri
            }
            else if (Input.GetKey(KeyCode.D))
            {
                move = 1; // Bergerak ke kanan
                spriteRenderer.flipX = true; // Mengembalikan sprite ke arah kanan
            }

            rb.velocity = new Vector2(move * speed, 0); // Gerakan horizontal
        }
        else
        {
            rb.velocity = Vector2.zero; // Jika tidak bisa bergerak, hentikan pergerakan
        }

        // Hanya bisa menembak jika canShoot bernilai true dan cooldown telah berlalu
        if (canShoot && Input.GetKeyDown(KeyCode.W) && Time.time >= lastShootTime + shootCooldown)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Menembakkan peluru dari posisi pemain
        Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
        lastShootTime = Time.time;

        // Play shooting sound
        if (shootSound != null)
        {
            audioSource.PlayOneShot(shootSound);
        }
    }

    // Method untuk mengatur kapan Player1 bisa bergerak
    public void EnableMovement()
    {
        canMove = true;
    }

    // Method untuk mengatur kapan Player1 tidak bisa bergerak
    public void DisableMovement()
    {
        canMove = false;
    }

    // Method untuk mengatur kapan Player1 bisa menembak
    public void EnableShooting()
    {
        canShoot = true;
    }

    // Method untuk mengatur kapan Player1 tidak bisa menembak
    public void DisableShooting()
    {
        canShoot = false;
    }

    public void ReceiveDamagePlayer1()
    {
        immunePlayer.TakeDamagePlayer1(); // Memanggil metode TakeDamage() dari script immune
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Control : MonoBehaviour
{
    public float speed = 5f;
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public bool canShoot = false; // Variabel untuk mengontrol kapan bisa menembak

    [SerializeField] ImmunePlayer1GameTembak immunePlayer; // Referensi ke script immune

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer; // Komponen SpriteRenderer untuk mengatur flip
    private float lastShootTime; // Waktu tembakan terakhir
    public float shootCooldown = 0.3f; // Durasi cooldown tembakan

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>(); // Mendapatkan komponen SpriteRenderer
        canShoot = true;
        // Mendapatkan referensi ke Immune
        immunePlayer = GetComponent<ImmunePlayer1GameTembak>();
    }

    void Update()
    {
        // Gerakan Player 1 menggunakan A dan D
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

        // Menembak dengan tombol W, hanya jika canShoot bernilai true dan cooldown telah berlalu
        if (Input.GetKeyDown(KeyCode.W) && canShoot && Time.time >= lastShootTime + shootCooldown)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Menembakkan peluru dari posisi pemain
        Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
        lastShootTime = Time.time;
    }

    public void ReceiveDamagePlayer1()
    {
        immunePlayer.TakeDamagePlayer1(); // Memanggil metode TakeDamage() dari script immune
    }
}

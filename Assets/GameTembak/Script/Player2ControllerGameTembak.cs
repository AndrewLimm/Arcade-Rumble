using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2ControllerGameTembak : MonoBehaviour
{
    public float speed = 5f;
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public bool canShoot = false; // Variabel untuk mengontrol kapan bisa menembak
    [SerializeField] ImmunePlayer2GameTembak immunePlayer2GameTembak;

    private Rigidbody2D rb;

    private float lastShootTime; // Waktu tembakan terakhir
    public float shootCooldown = 0.3f; // Durasi cooldown tembakan

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        canShoot = true;
        // Mendapatkan referensi ke Immmune
        immunePlayer2GameTembak = GetComponent<ImmunePlayer2GameTembak>();
    }

    void Update()
    {
        // Gerakan Player 2 menggunakan J dan L
        float move = 0;
        if (Input.GetKey(KeyCode.J))
        {
            move = -1; // Bergerak ke kiri
        }
        else if (Input.GetKey(KeyCode.L))
        {
            move = 1; // Bergerak ke kanan
        }

        rb.velocity = new Vector2(move * speed, 0); // Gerakan horizontal

        // Menembak dengan tombol I, hanya jika canShoot bernilai true
        if (Input.GetKeyDown(KeyCode.I) && canShoot && Time.time >= lastShootTime + shootCooldown)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Menembakkan peluru dari posisi pemain
        Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
        lastShootTime = Time.time; // Mengatur waktu tembakan terakhir

    }
    public void ReceiveDamagePlayer2()
    {
        immunePlayer2GameTembak.TakeDamagePlayer2(); // Memanggil metode TakeDamage() dari script immune
    }
}

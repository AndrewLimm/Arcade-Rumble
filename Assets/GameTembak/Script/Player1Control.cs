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

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        canShoot = true;
        // Mendapatkan referensi ke Immmune
        immunePlayer = GetComponent<ImmunePlayer1GameTembak>();
    }

    void Update()
    {
        // Gerakan Player 1 menggunakan A dan D
        float move = 0;
        if (Input.GetKey(KeyCode.A))
        {
            move = -1; // Bergerak ke kiri
        }
        else if (Input.GetKey(KeyCode.D))
        {
            move = 1; // Bergerak ke kanan
        }

        rb.velocity = new Vector2(move * speed, 0); // Gerakan horizontal

        // Menembak dengan tombol W, hanya jika canShoot bernilai true
        if (Input.GetKeyDown(KeyCode.W) && canShoot)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Menembakkan peluru dari posisi pemain
        Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
    }

    public void ReceiveDamagePlayer1()
    {
        immunePlayer.TakeDamagePlayer1(); // Memanggil metode TakeDamage() dari script immune
    }
}

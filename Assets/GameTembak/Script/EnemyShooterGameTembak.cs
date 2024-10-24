using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooterGameTembak : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float shootInterval = 2f;

    private float shootTimer;
    public bool canShoot = false; // Flag untuk mengontrol kapan bisa menembak


    void Start()
    {
        // Spawn musuh tidak langsung dimulai saat Start, harus diaktifkan secara manual
        canShoot = false;
    }

    void Update()
    {
        // Menjalankan penembakan hanya jika canShoot bernilai true
        if (!canShoot)
        {
            shootTimer += Time.deltaTime;

            if (shootTimer >= shootInterval)
            {
                Shoot();
                shootTimer = 0;
            }
        }
    }

    public void Shoot()
    {
        // Menembakkan peluru dari posisi enemy
        Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
    }

    // Fungsi untuk memulai penembakan musuh
    public void StartShooting()
    {
        canShoot = false; // Mengaktifkan penembakan
    }

    // Fungsi untuk menghentikan penembakan musuh
    public void StopShooting()
    {
        canShoot = true; // Menonaktifkan penembakan
    }
}

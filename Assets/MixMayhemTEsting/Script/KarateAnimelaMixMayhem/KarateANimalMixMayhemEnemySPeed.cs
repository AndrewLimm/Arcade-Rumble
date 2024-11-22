using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarateANimalMixMayhemEnemySPeed : MonoBehaviour
{
    public float speed = 2f; // Kecepatan pergerakan musuh
    private Vector3 laneTarget; // Posisi tujuan di jalur tetap
    public AudioClip deathSound; // Suara saat musuh mati
    public AudioSource audioSource; // Sumber audio untuk memainkan suara
    public Animator animator; // Animator untuk musuh

    // Flag untuk mencegah penghancuran ganda
    private bool isDestroyed = false;

    void Start()
    {
        // Inisialisasi komponen Animator jika belum diset di Inspector
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }

        // Inisialisasi komponen AudioSource jika belum diset di Inspector
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    public void SetLane(Vector3 lanePosition)
    {
        laneTarget = lanePosition; // Tetapkan jalur tetap saat musuh di-spawn

    }

    void Update()
    {
        // Gerakkan musuh lurus menuju arah atas layar (top-down)
        transform.position += Vector3.up * speed * Time.deltaTime;

        // Cek apakah musuh sudah mencapai ujung layar
        if (transform.position.y > laneTarget.y + 10f) // Atur jarak untuk destroy
        {
            Destroy(gameObject);
        }
    }

    // Fungsi untuk mendeteksi tabrakan dengan player
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Jika musuh menyentuh pemain
        if (other.CompareTag("Player"))
        {
            // Pastikan musuh hanya dihancurkan satu kali
            if (!isDestroyed)
            {
                DestroyEnemy();
            }
            // Kamu juga bisa menambahkan efek lain seperti suara atau animasi di sini
            Debug.Log("Enemy collided with player and destroyed");
        }
    }

    // Fungsi untuk menghancurkan musuh dengan animasi dan suara
    public void DestroyEnemy()
    {
        if (isDestroyed) return; // Cegah penghancuran ganda
        isDestroyed = true;

        // Aktifkan animasi kematian jika ada animator
        if (animator != null)
        {
            animator.SetTrigger("Explode");
        }

        // Mainkan suara kematian jika ada audio source dan clip
        if (audioSource != null && deathSound != null)
        {
            audioSource.PlayOneShot(deathSound);
        }

        // Hancurkan objek setelah suara selesai (jika ada suara)
        float destroyDelay = (deathSound != null) ? deathSound.length : 0f;
        Destroy(gameObject, destroyDelay); // Hancurkan objek setelah durasi suara selesai
    }
}

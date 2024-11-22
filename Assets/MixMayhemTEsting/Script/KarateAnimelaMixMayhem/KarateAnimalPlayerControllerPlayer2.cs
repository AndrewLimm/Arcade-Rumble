using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarateAnimalPlayerControllerPlayer2 : MonoBehaviour
{
    public KeyCode attackKey1 = KeyCode.J; // Tombol untuk baris 1
    public KeyCode attackKey2 = KeyCode.K; // Tombol untuk baris 2
    public KeyCode attackKey3 = KeyCode.L; // Tombol untuk baris 3

    public Transform attackPoint1; // Titik serangan baris 1
    public Transform attackPoint2; // Titik serangan baris 2
    public Transform attackPoint3; // Titik serangan baris 3

    public float attackRange = 0.5f; // Jarak serangan
    public LayerMask targetLayer; // Layer untuk objek yang bisa diserang

    public KarateAnimalPlayer2Animator playerAnimator; // Referensi ke skrip animator

    [SerializeField] private KarateAnimalMixMayhemScoreManagerPlayer2 karateAnimalPlayer2Score;

    // Audio for attack
    [SerializeField] private AudioClip attackSound;
    private AudioSource audioSource;

    public float attackCooldown = 0.5f; // Durasi cooldown serangan
    private float lastAttackTime = 0f; // Waktu terakhir serangan dilakukan


    void Start()
    {
        playerAnimator = GetComponent<KarateAnimalPlayer2Animator>();
        karateAnimalPlayer2Score = FindObjectOfType<KarateAnimalMixMayhemScoreManagerPlayer2>();
        // Initialize AudioSource

        audioSource = gameObject.AddComponent<AudioSource>();
        if (attackSound != null)
        {
            audioSource.clip = attackSound;
        }
        else
        {
            Debug.LogWarning("Attack sound not set in Inspector.");
        }

        if (karateAnimalPlayer2Score == null)
        {
            Debug.LogError("KarateAnimalPlayer2Score tidak ditemukan! Pastikan script ini ada di scene.");
        }
        else
        {
            Debug.Log("KarateAnimalPlayer2Score berhasil ditemukan.");
        }


        if (karateAnimalPlayer2Score == null)
        {
            Debug.LogError("KarateAnimalPlayer2Score tidak ditemukan! Pastikan script ini ada di scene.");
        }
        else
        {
            Debug.Log("KarateAnimalPlayer2Score berhasil ditemukan.");
        }
    }

    void Update()
    {
        if (Time.time >= lastAttackTime + attackCooldown)
        {// Cek input pemain untuk setiap baris
            if (Input.GetKeyDown(attackKey1))
            {
                Debug.Log("Player 2 menyerang baris 1");
                playerAnimator.TriggerAttackAnimation(1); // Panggil animasi serangan untuk baris 1
                Attack(attackPoint1); // Serang di baris 1
                PlayAttackSound(); // Mainkan suara serangan
                lastAttackTime = Time.time; // Update waktu serangan terakhir

            }
            else if (Input.GetKeyDown(attackKey2))
            {
                Debug.Log("Player 2 menyerang baris 2");
                playerAnimator.TriggerAttackAnimation(2); // Panggil animasi serangan untuk baris 2
                Attack(attackPoint2); // Serang di baris 2
                PlayAttackSound(); // Mainkan suara serangan
                lastAttackTime = Time.time; // Update waktu serangan terakhir

            }
            else if (Input.GetKeyDown(attackKey3))
            {
                Debug.Log("Player 2 menyerang baris 3");
                playerAnimator.TriggerAttackAnimation(3); // Panggil animasi serangan untuk baris 3
                Attack(attackPoint3); // Serang di baris 3
                PlayAttackSound(); // Mainkan suara serangan
                lastAttackTime = Time.time; // Update waktu serangan terakhir

            }
        }


    }

    public void Attack(Transform attackPoint)
    {
        // Deteksi objek di area serangan berdasarkan posisi
        Collider2D[] hitTargets = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, targetLayer);

        foreach (Collider2D target in hitTargets)
        {
            KarateANimalMixMayhemEnemySPeed enemy = target.GetComponent<KarateANimalMixMayhemEnemySPeed>();

            // Hancurkan musuh jika mereka berada dalam jangkauan
            if (enemy != null)
            {
                Debug.Log("Enemy destroyed at position " + attackPoint.position);
                Destroy(enemy.gameObject);

                if (karateAnimalPlayer2Score != null)
                {
                    karateAnimalPlayer2Score.AddScorePlayer2(10);
                    Debug.Log("Player 2 Score increased!"); // Debug log
                }
                else
                {
                    Debug.LogWarning("KarateAnimalPlayer2Score not found!");
                }
            }
            else
            {
                Debug.Log("Target found but not an enemy.");
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint1 == null || attackPoint2 == null || attackPoint3 == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint1.position, attackRange);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(attackPoint2.position, attackRange);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(attackPoint3.position, attackRange);
    }

    private void PlayAttackSound()
    {
        if (attackSound != null)
        {
            audioSource.PlayOneShot(attackSound); // Mainkan suara serangan
        }
    }
}

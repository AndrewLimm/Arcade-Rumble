using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    public KeyCode attackKey1 = KeyCode.A; // Tombol untuk baris 1
    public KeyCode attackKey2 = KeyCode.S; // Tombol untuk baris 2
    public KeyCode attackKey3 = KeyCode.D; // Tombol untuk baris 3
    public Transform attackPoint1; // Titik serangan baris 1
    public Transform attackPoint2; // Titik serangan baris 2
    public Transform attackPoint3; // Titik serangan baris 3
    public float attackRange = 0.5f; // Jarak serangan
    public LayerMask targetLayer; // Layer untuk objek yang bisa diserang
    public int score = 0; // Skor pemain

    public KarateAnimalPlayer1Animator playerAnimator; // Referensi ke skrip animator

    void Start()
    {
        // Mendapatkan referensi ke skrip KarateAnimalPlayer1Animator dari GameObject ini
        playerAnimator = GetComponent<KarateAnimalPlayer1Animator>();
    }

    void Update()
    {
        // Cek input pemain untuk setiap baris
        if (Input.GetKeyDown(attackKey1))
        {
            Debug.Log("Attacking lane 1");
            playerAnimator.TriggerAttackAnimation(1); // Panggil animasi serangan untuk lane 1
            Attack(attackPoint1); // Serang di baris 1
        }
        else if (Input.GetKeyDown(attackKey2))
        {
            Debug.Log("Attacking lane 2");
            playerAnimator.TriggerAttackAnimation(2); // Panggil animasi serangan untuk lane 2
            Attack(attackPoint2); // Serang di baris 2
        }
        else if (Input.GetKeyDown(attackKey3))
        {
            Debug.Log("Attacking lane 3");
            playerAnimator.TriggerAttackAnimation(3); // Panggil animasi serangan untuk lane 3
            Attack(attackPoint3); // Serang di baris 3
        }
    }

    void Attack(Transform attackPoint)
    {
        // Deteksi objek di area serangan berdasarkan posisi
        Collider2D[] hitTargets = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, targetLayer);

        foreach (Collider2D target in hitTargets)
        {
            EnemyController enemy = target.GetComponent<EnemyController>();

            // Hancurkan musuh jika mereka berada dalam jangkauan
            if (enemy != null)
            {
                Debug.Log("Enemy destroyed at position " + attackPoint.position);
                Destroy(enemy.gameObject);
                score += 1; // Tambahkan skor setiap kali objek dihancurkan
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint1 == null || attackPoint2 == null || attackPoint3 == null) return;
        Gizmos.DrawWireSphere(attackPoint1.position, attackRange);
        Gizmos.DrawWireSphere(attackPoint2.position, attackRange);
        Gizmos.DrawWireSphere(attackPoint3.position, attackRange);
    }
}


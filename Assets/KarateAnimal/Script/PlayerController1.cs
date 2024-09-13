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

    // public Animator animator; // Animator untuk animasi serangan

    void Update()
    {
        if (Input.GetKeyDown(attackKey1))
        {
            Attack(attackPoint1, "AttackLine1");
        }
        else if (Input.GetKeyDown(attackKey2))
        {
            Attack(attackPoint2, "AttackLine2");
        }
        else if (Input.GetKeyDown(attackKey3))
        {
            Attack(attackPoint3, "AttackLine3");
        }
    }

    void Attack(Transform attackPoint, string attackAnimation)
    {
        // Menjalankan animasi serangan
        // animator.SetTrigger(attackAnimation);

        // Deteksi objek di area serangan
        Collider2D[] hitTargets = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, targetLayer);

        foreach (Collider2D target in hitTargets)
        {
            Destroy(target.gameObject); // Menghancurkan objek yang terkena serangan
            score += 1; // Tambahkan skor setiap kali objek dihancurkan
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


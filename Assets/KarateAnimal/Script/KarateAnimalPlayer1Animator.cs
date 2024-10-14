using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarateAnimalPlayer1Animator : MonoBehaviour
{
    private Animator animator; // Referensi ke komponen Animator

    void Start()
    {
        // Mendapatkan komponen Animator dari GameObject ini
        animator = GetComponent<Animator>();
    }

    public void TriggerAttackAnimation(int lane)
    {
        // Set parameter AttackLane sesuai dengan lane yang dipilih
        animator.SetInteger("AttackLane", lane);

        // Gunakan coroutine untuk reset animasi kembali ke idle setelah serangan selesai
        StartCoroutine(ResetAttackAnimation());
    }

    private IEnumerator ResetAttackAnimation()
    {
        // Tunggu sebentar untuk memberi waktu pada animasi berjalan (sesuaikan dengan durasi animasi serangan Anda)
        yield return new WaitForSeconds(0.5f);
        animator.SetInteger("AttackLane", 0); // Reset ke animasi idle
    }
}

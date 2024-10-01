using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImmunePlayer1GameTembak : MonoBehaviour
{
    public bool canReceiveDamage = true; // Mendeteksi apakah player dapat menerima damage
    public float damageCooldown = 3f; // Durasi cooldown setelah menerima damage

    // Metode untuk menerima damage
    public void TakeDamagePlayer1()
    {
        if (canReceiveDamage)
        {
            Debug.Log("Player menerima damage!");
            // Logika pengurangan health di sini

            canReceiveDamage = false;
            StartCoroutine(DamageCooldown());
        }
    }

    // Coroutine untuk mengatur cooldown damage
    private IEnumerator DamageCooldown()
    {
        yield return new WaitForSeconds(damageCooldown); // Tunggu selama durasi cooldown
        canReceiveDamage = true; // Aktifkan kembali kemampuan menerima damage
        Debug.Log("Player dapat menerima damage lagi.");
    }
}

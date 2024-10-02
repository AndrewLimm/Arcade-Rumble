using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImmunePlayer2GameTembak : MonoBehaviour
{
    public bool canReceiveDamage = true; // Mendeteksi apakah player dapat menerima damage
    public float damageCooldown = 3f; // Durasi cooldown setelah menerima damage

    // Metode untuk menerima damage
    public void TakeDamagePlayer2()
    {
        if (canReceiveDamage)
        {
            Debug.Log("Player 2 menerima damage!");
            // Logika pengurangan health di sini

            canReceiveDamage = false; // Nonaktifkan kemampuan menerima damage
            StartCoroutine(DamageCooldown()); // Memulai coroutine untuk cooldown
        }
        else
        {
            Debug.Log("Player 2 sedang imun dan tidak menerima damage.");
        }
    }

    // Coroutine untuk mengatur cooldown damage
    private IEnumerator DamageCooldown()
    {
        yield return new WaitForSeconds(damageCooldown); // Tunggu selama durasi cooldown
        canReceiveDamage = true; // Aktifkan kembali kemampuan menerima damage
        Debug.Log("Player 2 dapat menerima damage lagi.");
    }
}

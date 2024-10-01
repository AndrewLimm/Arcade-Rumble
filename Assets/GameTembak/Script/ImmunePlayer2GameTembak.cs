using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImmunePlayer2GameTembak : MonoBehaviour
{
    public bool isInvulnerable = false; // Variabel untuk mengontrol invulnerabilitas
    public float invulnerabilityDuration = 3f; // Durasi invulnerabilitas

    // Metode untuk mengambil damage
    public void TakeDamagePlayer2()
    {
        if (!isInvulnerable)
        {
            // Logika untuk menerima damage di sini
            Debug.Log("Player 2 menerima damage!");
            // Tambahkan logika damage yang sesuai, seperti mengurangi health

            // Memanggil metode untuk memulai status imun
            StartCoroutine(ActivateInvulnerability());
        }
        else
        {
            Debug.Log("Player 2 sedang imun dan tidak menerima damage.");
        }
    }

    // Coroutine untuk mengatur status imun
    private IEnumerator ActivateInvulnerability()
    {
        isInvulnerable = true; // Aktifkan status imun
        yield return new WaitForSeconds(invulnerabilityDuration); // Tunggu selama durasi yang ditentukan
        isInvulnerable = false; // Nonaktifkan status imun
        Debug.Log("Imun selesai, Player 2 bisa menerima damage lagi.");
    }
}

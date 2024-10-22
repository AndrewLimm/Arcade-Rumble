using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTembakMixMayhemDisableAttackPlayer2 : MonoBehaviour
{
    public GameTembakMixMayhemPlayer2 player2Controller; // Referensi ke Player2Control
    private Coroutine disableCoroutine; // Menyimpan referensi ke coroutine yang berjalan

    private void Awake()
    {
        // Mencari Player2Control di scene
        player2Controller = FindObjectOfType<GameTembakMixMayhemPlayer2>();

        // Cek apakah player2Controller berhasil ditemukan
        if (player2Controller == null)
        {
            Debug.LogError("Player 2 Controller is not assigned or found!");
        }
    }

    void Start()
    {
        Debug.Log("DisableAttackPlayer2GameTembak script is active!");
    }

    // Nonaktifkan serangan Player 2
    public void DisablePlayer2Attack()
    {
        if (player2Controller != null)
        {
            // Jika coroutine sudah berjalan, hentikan sebelum memulai yang baru
            if (disableCoroutine != null)
            {
                StopCoroutine(disableCoroutine);
            }

            Debug.Log("Menonaktifkan serangan Player 2");
            disableCoroutine = StartCoroutine(DisableAttackCoroutine());
        }
        else
        {
            Debug.LogError("Player 2 Controller is null, cannot disable attack!");
        }
    }

    // Coroutine untuk menonaktifkan serangan Player 2
    private IEnumerator DisableAttackCoroutine()
    {
        player2Controller.canShoot = false; // Menonaktifkan serangan

        yield return new WaitForSeconds(2f); // Tunggu 2 detik

        player2Controller.canShoot = true; // Mengizinkan pemain untuk menembak lagi
        disableCoroutine = null; // Reset referensi coroutine
        Debug.Log("Serangan Player 2 diaktifkan kembali");
    }
}

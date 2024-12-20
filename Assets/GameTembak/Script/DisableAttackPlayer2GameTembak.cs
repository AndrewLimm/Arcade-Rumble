using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAttackPlayer2GameTembak : MonoBehaviour
{
    public Player2ControllerGameTembak player2Controller; // Referensi ke Player2Control
    private Coroutine disableCoroutine; // Menyimpan referensi ke coroutine yang berjalan
    private SpriteRenderer player2SpriteRenderer;

    private void Awake()
    {
        // Mencari Player2Control di scene
        player2Controller = FindObjectOfType<Player2ControllerGameTembak>();

        // Cek apakah player2Controller berhasil ditemukan

        if (player2Controller == null)
        {
            Debug.LogError("Player 1 Controller is not assigned or found!");
        }
        else
        {
            // Dapatkan komponen SpriteRenderer dari Player 1
            player2SpriteRenderer = player2Controller.GetComponent<SpriteRenderer>();
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

        // Mengubah warna sprite menjadi merah
        if (player2SpriteRenderer != null)
        {
            player2SpriteRenderer.color = Color.red;
        }

        yield return new WaitForSeconds(1.5f); // Tunggu 2 detik

        // Mengubah warna sprite menjadi merah
        if (player2SpriteRenderer != null)
        {
            player2SpriteRenderer.color = Color.white;
        }

        player2Controller.canShoot = true; // Mengizinkan pemain untuk menembak lagi
        disableCoroutine = null; // Reset referensi coroutine
        Debug.Log("Serangan Player 2 diaktifkan kembali");
    }
}

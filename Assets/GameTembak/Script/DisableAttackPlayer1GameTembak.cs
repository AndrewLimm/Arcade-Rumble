using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAttackPlayer1GameTembak : MonoBehaviour
{
    public Player1Control player1Controller; // Referensi ke Player1Control
    private Coroutine disableCoroutine; // Menyimpan referensi ke coroutine yang berjalan
    private SpriteRenderer player1SpriteRenderer; // Referensi ke SpriteRenderer Player 1

    private void Awake()
    {

        // Mencari Player1Control di scene
        player1Controller = FindObjectOfType<Player1Control>();

        // Cek apakah player1Controller berhasil ditemukan
        if (player1Controller == null)
        {
            Debug.LogError("Player 1 Controller is not assigned or found!");
        }
        else
        {
            // Dapatkan komponen SpriteRenderer dari Player 1
            player1SpriteRenderer = player1Controller.GetComponent<SpriteRenderer>();
        }
    }

    void Start()
    {
        Debug.Log("DisableAttackPlayer1GameTembak script is active!");
    }

    // Nonaktifkan serangan Player 1
    public void DisablePlayer1Attack()
    {
        if (player1Controller != null)
        {
            // Jika coroutine sudah berjalan, hentikan sebelum memulai yang baru
            if (disableCoroutine != null)
            {
                StopCoroutine(disableCoroutine);
            }

            Debug.Log("Menonaktifkan serangan Player 1");
            disableCoroutine = StartCoroutine(DisableAttackCoroutine());
        }
        else
        {
            Debug.LogError("Player 1 Controller is null, cannot disable attack!");
        }
    }

    // Coroutine untuk menonaktifkan serangan Player 1
    private IEnumerator DisableAttackCoroutine()
    {
        player1Controller.canShoot = false; // Menonaktifkan serangan

        // Mengubah warna sprite menjadi merah
        if (player1SpriteRenderer != null)
        {
            player1SpriteRenderer.color = Color.red;
        }

        yield return new WaitForSeconds(1.5f); // Tunggu 2 detik


        // Mengembalikan warna sprite ke warna asli (putih)
        if (player1SpriteRenderer != null)
        {
            player1SpriteRenderer.color = Color.white;
        }

        player1Controller.canShoot = true; // Mengizinkan pemain untuk menembak lagi
        disableCoroutine = null; // Reset referensi coroutine
        Debug.Log("Serangan Player 1 diaktifkan kembali");
    }
}

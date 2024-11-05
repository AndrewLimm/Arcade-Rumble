using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickMathPlayer2Input : MonoBehaviour
{
    public MathGameLogic mathGameLogic; // Referensi ke MathGameLogic untuk memeriksa jawaban
    private AudioSource audioSource; // Audio source for playing sounds
    public AudioClip selectionSound; // Clip to play on selection

    public float cooldown = 1f; // Waktu cooldown dalam detik
    private float timeSinceLastInput = 0f; // Waktu sejak input terakhir


    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component
    }
    void Update()
    {
        // Perbarui waktu sejak input terakhir
        timeSinceLastInput += Time.deltaTime;

        // Cek apakah cooldown telah habis
        if (timeSinceLastInput >= cooldown)
        {
            // Input untuk Player 1
            if (Input.GetKeyDown(KeyCode.J))
            {
                CekJawaban(0);
            }
            if (Input.GetKeyDown(KeyCode.K))
            {
                CekJawaban(1);
            }
            if (Input.GetKeyDown(KeyCode.L))
            {
                CekJawaban(2);
            }
        }
    }

    void CekJawaban(int pilihanDipilih)
    {
        if (mathGameLogic != null)
        {
            Debug.Log($"Player 2 memilih jawaban {pilihanDipilih}.");
            mathGameLogic.CekJawaban(pilihanDipilih, 2); // 2 menunjukkan Player 2
            PlaySelectionSound(); // Play selection sound
            timeSinceLastInput = 0f; // Reset waktu untuk cooldown
        }
        else
        {
            Debug.LogError("MathGameLogic belum disambungkan ke QuickMathPlayer2Input.");
        }
    }
    private void PlaySelectionSound()
    {
        if (selectionSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(selectionSound); // Play the selection sound
        }
        else
        {
            Debug.LogWarning("Selection sound not assigned or AudioSource is missing!");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickMathMixMayhemPlayer2Input : MonoBehaviour
{
    public QuickMathMIxmayhemLogic mathGameLogic; // Referensi ke MathGameLogic untuk memeriksa jawaban
    private AudioSource audioSource; // Audio source for playing sounds
    public AudioClip selectionSound; // Clip to play on selection

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component
    }
    void Update()
    {
        // Input untuk Player 1
        if (Input.GetKeyDown(KeyCode.J)) CekJawaban(0);
        if (Input.GetKeyDown(KeyCode.K)) CekJawaban(1);
        if (Input.GetKeyDown(KeyCode.L)) CekJawaban(2);
    }

    void CekJawaban(int pilihanDipilih)
    {
        if (mathGameLogic != null)
        {
            Debug.Log($"Player 2 memilih jawaban {pilihanDipilih}.");
            mathGameLogic.CekJawaban(pilihanDipilih, 2); // 1 menunjukkan Player 1
            PlaySelectionSound(); // Play selection sound

        }
        else
        {
            Debug.LogError("MathGameLogic belum disambungkan ke QuickMathPlayer1Input.");
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

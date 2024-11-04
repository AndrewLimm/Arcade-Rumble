using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Mechanic : MonoBehaviour
{

    public ReactionMechanic reactionMechanic;
    private bool isInputEnabled = false; // Flag untuk mengendalikan input

    [SerializeField] public AudioClip inputSound; // Suara saat input
    public AudioSource audioSource;

    void Update()
    {
        if (isInputEnabled)
        {
            HandlePlayer2Input(); // Hanya periksa input jika diizinkan
        }
    }

    public void EnableInput() // Memungkinkan input
    {
        isInputEnabled = true;
    }

    void HandlePlayer2Input()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            PlayInputSound(); // Mainkan suara saat input

            Debug.Log("Pemain 2 menekan L");
            reactionMechanic.PlayerWin(2); // Panggil untuk menangani kemenangan Pemain 2
        }
    }

    private void PlayInputSound()
    {
        if (inputSound != null)
        {
            audioSource.PlayOneShot(inputSound); // Mainkan suara input
        }
    }
}

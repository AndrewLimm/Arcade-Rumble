using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Mechanic : MonoBehaviour
{

    public ReactionMechanic reactionMechanic;
    private bool isInputEnabled = false; // Flag untuk mengendalikan input

    [SerializeField] public AudioClip inputSound; // Suara saat input
    public AudioSource audioSource;

    void Update()
    {
        if (isInputEnabled)
        {
            HandlePlayer1Input(); // Hanya periksa input jika diizinkan
        }
    }

    public void EnableInput() // Memungkinkan input
    {
        isInputEnabled = true;
    }

    void HandlePlayer1Input()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            PlayInputSound(); // Mainkan suara saat input

            Debug.Log("Pemain 1 menekan A");
            reactionMechanic.PlayerWin(1); // Panggil untuk menangani kemenangan Pemain 1
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

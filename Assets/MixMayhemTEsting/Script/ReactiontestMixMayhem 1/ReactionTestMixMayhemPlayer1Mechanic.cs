using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactionTestMixMayhemPlayer1Mechanic : MonoBehaviour
{
    public ReactionTestMixMayhemGameManager reactionMechanic;


    [SerializeField] public AudioClip inputSound; // Suara saat input
    public AudioSource audioSource;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Player 1 pressed A");
            PlayInputSound();
            reactionMechanic.PlayerWin(1);
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

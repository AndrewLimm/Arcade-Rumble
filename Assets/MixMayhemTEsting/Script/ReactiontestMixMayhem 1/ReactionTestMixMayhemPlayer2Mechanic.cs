using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactionTestMixMayhemPlayer2Mechanic : MonoBehaviour
{
    public ReactionTestMixMayhemGameManager reactionMechanic;

    [SerializeField] public AudioClip inputSound; // Suara saat input
    public AudioSource audioSource;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("Player 1 pressed L");
            PlayInputSound();

            reactionMechanic.PlayerWin(2);
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

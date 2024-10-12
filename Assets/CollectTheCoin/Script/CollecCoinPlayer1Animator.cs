using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollecCoinPlayer1Animator : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Metode untuk memperbarui animasi berdasarkan status pergerakan pemain
    public void UpdateAnimationState(bool isMoving)
    {
        if (isMoving)
        {
            animator.SetInteger("isRunning", 1); //untuk animasi run
        }
        else
        {
            animator.SetInteger("isRunning", 0); //untuk animasi idle
        }
    }
}

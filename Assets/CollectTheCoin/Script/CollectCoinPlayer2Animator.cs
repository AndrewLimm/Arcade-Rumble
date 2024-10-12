using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoinPlayer2Animator : MonoBehaviour
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
            animator.SetInteger("AnimationState", 1); // 1 untuk animasi run
        }
        else
        {
            animator.SetInteger("AnimationState", 0); // 0 untuk animasi idle
        }
    }
}

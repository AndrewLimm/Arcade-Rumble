using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixMayhemRaceToFInishANimator : MonoBehaviour
{
    private Animator animator;   // Reference to the Animator component

    private void Start()
    {
        animator = GetComponent<Animator>();  // Get the Animator component attached to this object
    }

    // Method to set the animation state using integers
    public void SetAnimationState(int state)
    {
        animator.SetInteger("animationState", state);
    }

    // Method to trigger the idle animation
    public void PlayIdleAnimation()
    {
        SetAnimationState(0);
    }

    // Method to trigger the move animation
    public void PlayMoveAnimation()
    {
        SetAnimationState(1);
    }
}

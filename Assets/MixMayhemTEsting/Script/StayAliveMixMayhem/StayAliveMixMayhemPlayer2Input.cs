using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayAliveMixMayhemPlayer2Input : MonoBehaviour
{
    public float speed = 5f; // Adjust the movement speed
    private bool isFacingRight = true; // Variable to track which direction the player is facing

    void Update()
    {
        // Player 2 movement (IJKL)
        float horizontal = 0f;
        float vertical = 0f;

        if (Input.GetKey(KeyCode.I)) vertical = 1f;
        if (Input.GetKey(KeyCode.K)) vertical = -1f;
        if (Input.GetKey(KeyCode.J)) horizontal = -1f;
        if (Input.GetKey(KeyCode.L)) horizontal = 1f;

        // Move the player based on input
        Vector3 movement = new Vector3(horizontal, vertical, 0f).normalized;
        transform.position += movement * speed * Time.deltaTime;

        // Flip the character sprite based on movement direction
        FlipCharacter(horizontal);
    }

    private void FlipCharacter(float horizontal)
    {
        // If moving right and not facing right, flip the sprite
        if (horizontal > 0 && !isFacingRight)
        {
            Flip();
        }
        // If moving left and facing right, flip the sprite
        else if (horizontal < 0 && isFacingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        // Flip the character's facing direction
        isFacingRight = !isFacingRight;

        // Invert the X axis scale to flip the sprite
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}

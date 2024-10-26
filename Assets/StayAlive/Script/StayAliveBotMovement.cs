using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayAliveBotMovement : MonoBehaviour
{
    public float speed = 3f; // Speed of the bot's movement
    public float leftLimit = -5f; // Left boundary for movement
    public float rightLimit = 5f; // Right boundary for movement

    private bool movingRight = false; // Direction of bot movement

    public void StartMoving()
    {
        // Start the movement coroutine
        StartCoroutine(MoveBot());
    }

    private IEnumerator MoveBot()
    {
        while (true) // Infinite loop to keep the bot moving
        {
            if (movingRight)
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
                if (transform.position.x >= rightLimit)
                {
                    movingRight = false;
                }
            }
            else
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
                if (transform.position.x <= leftLimit)
                {
                    movingRight = true;
                }
            }
            yield return null; // Wait for the next frame
        }
    }

    public void StopMoving()
    {
        StopAllCoroutines(); // Stop all movement
    }
}

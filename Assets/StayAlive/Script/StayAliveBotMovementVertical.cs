using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayAliveBotMovementVertical : MonoBehaviour
{

    public float speed = 3f; // Speed of the bot's movement
    public float topLimit = 5f; // Top boundary for movement
    public float bottomLimit = -5f; // Bottom boundary for movement

    private bool movingUp = true; // Direction of bot movement

    public void StartMoving()
    {
        // Start the movement coroutine
        StartCoroutine(MoveBot());
    }

    private IEnumerator MoveBot()
    {
        while (true) // Infinite loop to keep the bot moving
        {
            if (movingUp)
            {
                transform.position += Vector3.up * speed * Time.deltaTime;
                if (transform.position.y >= topLimit)
                {
                    movingUp = false;
                }
            }
            else
            {
                transform.position += Vector3.down * speed * Time.deltaTime;
                if (transform.position.y <= bottomLimit)
                {
                    movingUp = true;
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
